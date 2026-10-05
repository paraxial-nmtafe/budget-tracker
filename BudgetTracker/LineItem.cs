using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker
{
    class LineItem
    {
        private int credit;
        private int debit;
        private string name;

        public string Name { get { return name; } }
        public int Credit { get { return credit; } set { credit = value; } }
        public int Debit { get { return debit; } set { debit = value; } }

        public LineItem(string name, int credit, int debit)
        {
            this.name = name;
            this.credit = credit;
            this.debit = debit;
        }
    }
}
