using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BudgetTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Tracker budgetTracker;
        public MainWindow()
        {
            InitializeComponent();
            budgetTracker = new Tracker();
            RefreshView();
        }

        public void RefreshView()
        {
            budgetItems.ItemsSource = budgetTracker.LineItems;
            totalCredit.Text = budgetTracker.TotalCredit().ToString();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // itemName
            int amount = int.Parse(itemAmount.Text);
            uint credit = 0;
            uint debit = 0;
            if (amount > 0) {
                credit = (uint)amount;
            } else
            {
                debit = (uint)-amount;
            }
            budgetTracker.AddLineItem(itemName.Text,credit, debit);

            RefreshView();
        }
    }
}