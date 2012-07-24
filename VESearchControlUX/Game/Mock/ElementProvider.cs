using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VESearchControlUX.Models;
using System.IO;
using System.Data;

namespace VESearchControlUX.Game.Mock
{
    public class ElementProvider 
    {
        private static ElementProvider _the_one = null;
        public static ElementProvider Singleton
        {
            get
            {
                if (_the_one == null)
                {
                    _the_one = new ElementProvider();
                    _the_one.Init();
                }
                return _the_one;
            }
        }

        private List<IFirmDataElement> elements = new List<IFirmDataElement>();
        
        public void Init()
        {
            LoadAccounts();
            LoadContacts();
            LoadInvoices();

        }

        private void LoadAccounts()
        {
            LoadCsv<AccountDataElement>("accounts.csv");
        }

        private void LoadContacts()
        {
            LoadCsv<ContactDataElement>("contacts.csv");
        }

        private void LoadInvoices()
        {
            LoadCsv<InvoiceDataElement>("invoice.csv");
        }

        private void LoadCsv<TElement>(string filename) where TElement : IFirmDataElement, new()
        {
            var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"data", filename); 
            var lines = File.ReadAllLines(path);
            var headers = lines.First().Split(',').ToList();
            using (var table = new DataTable())
            {
                headers.ForEach(colname => table.Columns.Add(colname));

                foreach (var line in lines.Skip(1).Select(l => l.Split(',')))
                {
                    table.Rows.Add(line);
                }

                table.Rows.Cast<DataRow>().AsParallel().ForAll(
                        row => {
                            var el = new TElement();
                            el.LoadDataElement(row);
                            this.elements.Add(el);
                        }
                    );
            }
        }



        public IEnumerable<IFirmDataElement> AllElements
        {
            get { return elements; }
        }

        public IEnumerable<AccountDataElement> Accounts
        {
            get { return elements.OfType<AccountDataElement>(); }
        }

        public IEnumerable<ContactDataElement> Contacts
        {
            get { return elements.OfType<ContactDataElement>(); }
        }

        public IEnumerable<InvoiceDataElement> Invoices
        {
            get { return elements.OfType<InvoiceDataElement>(); }
        }
    }
}