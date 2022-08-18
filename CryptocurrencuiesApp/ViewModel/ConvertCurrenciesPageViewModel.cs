using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using CryptocurrencuiesApp.Model;

namespace CryptocurrencuiesApp.ViewModel
{
    public class ConvertCurrenciesPageViewModel : INotifyPropertyChanged
    {
        List<CurrencyPreview> CurrenciesPreview { get; set; }
        public CollectionViewSource FirstCurrencyPreview { get; set; }
        public CollectionViewSource SecondCurrencyPreview { get; set; }

        public CurrencyViewModel FirstCurrency { get; set; }
        public CurrencyViewModel SecondCurrency { get; set; }

        public string FirstCurrencySearchText
        {
            get
            {
                return firstCurrencySearchText;
            }
            set
            {
                firstCurrencySearchText = value;
                FirstCurrencyPreview.View.Refresh();
            }
        }
        private string firstCurrencySearchText = "";
        public string SecondCurrencySearchText
        {
            get
            {
                return secondCurrencySearchText;
            }
            set
            {
                secondCurrencySearchText = value;
                SecondCurrencyPreview.View.Refresh();
            }
        }
        private string secondCurrencySearchText = "";

        public double FirstCurrencyValue
        {
            get
            {
                return firstCurrencyValue;
            }
            set
            {
                firstCurrencyValue = value;
                OnPropertyChanged("FirstCurrencyValue");
            }
        }
        private double firstCurrencyValue;
        public double SecondCurrencyValue
        {
            get
            {
                return secondCurrencyValue;
            }
            set
            {
                secondCurrencyValue = value;
                OnPropertyChanged("SecondCurrencyValue");
            }
        }
        private double secondCurrencyValue;

        public ConvertCurrenciesPageViewModel()
        {
            CurrenciesPreview = HttpService.GetCurrenciesPreview().OrderBy(p=>p.Asset_Id+"_"+p.Name).ToList();
            FirstCurrency = new CurrencyViewModel();
            SecondCurrency = new CurrencyViewModel();
            FirstCurrencyPreview = new CollectionViewSource() { Source = CurrenciesPreview };
            FirstCurrencyPreview.View.CurrentChanged += FirstCurrencyPreview_CurrentChanged;
            FirstCurrencyPreview.View.Filter = FirstCurrencyPreviewFilter;

            SecondCurrencyPreview = new CollectionViewSource() { Source = CurrenciesPreview };
            SecondCurrencyPreview.View.CurrentChanged += SecondCurrencyPreview_CurrentChanged;
            SecondCurrencyPreview.View.Filter = SecondCurrencyPreviewFilter;


        }
        private bool FirstCurrencyPreviewFilter(object item)
        {
            CurrencyPreview currencyPreview = (CurrencyPreview)item;
            return (currencyPreview.Asset_Id + "_" + currencyPreview.Name).Contains(FirstCurrencySearchText);
        }
        private bool SecondCurrencyPreviewFilter(object item)
        {
            CurrencyPreview currencyPreview = (CurrencyPreview)item;
            return (currencyPreview.Asset_Id + "_" + currencyPreview.Name).Contains(SecondCurrencySearchText);
        }
        private void SecondCurrencyPreview_CurrentChanged(object? sender, EventArgs e)
        {
            CurrencyPreview target = SecondCurrencyPreview.View.CurrentItem as CurrencyPreview;
            if(target == null) { return; }
            SecondCurrency.Currency = HttpService.GetCurrency(target.Asset_Id);
        }

        private void FirstCurrencyPreview_CurrentChanged(object? sender, EventArgs e)
        {
            CurrencyPreview target = FirstCurrencyPreview.View.CurrentItem as CurrencyPreview;
            if (target == null) { return; }

            FirstCurrency.Currency = HttpService.GetCurrency(target.Asset_Id);

        }
        public void FirstCurrencyUpdated()
        {
            double totalPrice = FirstCurrencyValue * FirstCurrency.Price;
            SecondCurrencyValue = totalPrice/SecondCurrency.Price;
        }

        internal void SecondCurrencyUpdated()
        {
            double totalPrice = SecondCurrencyValue * SecondCurrency.Price;
            FirstCurrencyValue = totalPrice / FirstCurrency.Price;
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
