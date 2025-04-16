using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForexApp.ViewModel
{
    public partial class RatesViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<string> _currencyList;

        [ObservableProperty]
        private string _title;

        [ObservableProperty]
        private string _baseCurrency;

        public RatesViewModel(ObservableCollection<string> rates, string baseCurrency)
        {
            CurrencyList = rates;
            Title = $"Rates for {baseCurrency}";
            BaseCurrency = baseCurrency;
        }

        [RelayCommand]
        private async Task CurrencySelected(string rateString)
        {
            if (string.IsNullOrEmpty(rateString)) return;

            var parts = rateString.Split(':');
            if (parts.Length != 2) return;

            var currencyCode = parts[0].Trim();
            var rateValue = parts[1].Trim();

            await Shell.Current.DisplayAlert("Currency Selected",
                $"1 {BaseCurrency} = {rateValue} {currencyCode}", "OK");
        }
    }
}
