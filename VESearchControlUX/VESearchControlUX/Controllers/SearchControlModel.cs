using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VESearchControlUX.Models;
using VESearchControlUX.Models.Internal;
using System.Threading;

namespace VESearchControlUX.Controllers
{
    public class SearchControlModel<TElement> where TElement : class, IFirmDataElement
    {
        private readonly List<TElement> _results;
        public SearchControlModel(IEnumerable<TElement> resultset = null)
        {
            if (resultset == null)
                _results = new List<TElement>(resultset);
            else
                _results = new List<TElement>();
        }

        public ReadOnlyCollection<TElement> Results
        {
            get { return new ReadOnlyCollection<TElement>(_results); }
        }

        public Task StartSearch(string operation = "search-all", object[] args = null)
        {
            var cts = new CancellationTokenSource();
            var factory = new TaskFactory(cts.Token);
            Task t = new Task<SearchControlModel<TElement>>(() => {
                return this;
            });
            switch(operation)
            {
                default:
                    t = new Task<SearchControlModel<TElement>>(() =>
                    {
                        this._results.Add(OperationFailedDataElement.ThrowNewException("Not Implemented", "Not Implemented") as TElement);

                        return this;
                    });
                    break;
            }
            t.Start();
            return t;
        }

        public virtual void Search()
        {
            // HACK: Replace with real code.
            _results.Add(OperationFailedDataElement.ThrowNewException("Search is not implemented", "This message was written @ " + DateTime.Now.ToString()) as TElement);
        }
    }
}
