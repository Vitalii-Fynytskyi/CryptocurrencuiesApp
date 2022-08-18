using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CryptocurrencuiesApp.Model;
using CryptocurrencuiesApp.ViewModel;


namespace CryptocurrencuiesApp.ViewModel
{
    internal class MainPageViewModel
    {
        public ObservableCollection<CurrencyViewModel> Currencies { get; set; }
        public MainPageViewModel()
        {
            Currencies = new ObservableCollection<CurrencyViewModel>(HttpService.GetCryptocurrencies(out int next).Select(c=>new CurrencyViewModel(c)).ToList());
        }
    }
}
