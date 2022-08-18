using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CryptocurrencuiesApp.ViewModel;

namespace CryptocurrencuiesApp.View
{
    /// <summary>
    /// Interaction logic for CurrenciesList.xaml
    /// </summary>
    public partial class CurrenciesList : UserControl
    {
        public event EventHandler CurrencySelected;

        public static readonly DependencyProperty CurrenciesProperty = DependencyProperty.Register("Currencies", typeof(ObservableCollection<CurrencyViewModel>), typeof(CurrenciesList));
        public ObservableCollection<CurrencyViewModel> Currencies
        {
            get
            {
                return (ObservableCollection<CurrencyViewModel>)GetValue(CurrenciesProperty);
            }
            set
            {
                SetValue(CurrenciesProperty, value);
            }
        }
        public CurrenciesList()
        {
            InitializeComponent();
        }

        private void ButtonCurrency_Click(object sender, RoutedEventArgs e)
        {
            CurrencyViewModel currency = (sender as Button).DataContext as CurrencyViewModel;
            CurrencySelected?.Invoke(currency, EventArgs.Empty);
        }
    }
}
