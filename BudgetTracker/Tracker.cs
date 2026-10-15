using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker
{
    class Tracker
    {
        private List<LineItem> lineItems;

        public Tracker()
        {
            lineItems = new List<LineItem>();
        }
        public List<LineItem> LineItems
            { get { return lineItems; } }

        public void AddLineItem(string name, int credit, int debit) { 
            lineItems.Add(new LineItem(name, credit, debit));
        }

        public int TotalCredit() {
            // TODO: Do something with your lineItems
            return 0;
        }
        public int TotalDebit()
        {
            // TODO: Do something with your lineItems
            return 0;
        }
    }
}
