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
        }

        public void RefreshView()
        {
            budgetItems.ItemsSource = budgetTracker.LineItems;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // itemName
            int amount = int.Parse(itemAmount.Text);
            int credit = 0;
            int debit = 0;
            if (amount > 0) {
                credit = amount;
            } else
            {
                debit = amount;
            }
            budgetTracker.AddLineItem(itemName.Text,credit, debit);
            RefreshView();
        }
    }
}