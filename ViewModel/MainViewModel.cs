
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ForexApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForexApp.Models;
using ForexApp.Views;

namespace ForexApp.ViewModel
{
  public partial class MainViewModel : ObservableObject
    {
        
        private readonly ExchangeRateService _service = new();

    
        private readonly INavigation _navigation;

        [ObservableProperty]
        private ObservableCollection<Currency> availableCurrencies = new();

        [ObservableProperty]
        private Currency selectedCurrencyObj;

        [ObservableProperty]
        private string baseCurrency = "USD";

        [ObservableProperty]
        private ObservableCollection<string> currencyList = new();

        [ObservableProperty]
        private string selectedCurrency;

        [ObservableProperty]
        private string result;

        public MainViewModel(INavigation navigation)
        {

            _navigation = navigation;

            LoadRatesCommand = new AsyncRelayCommand(LoadRatesAsync);

            LoadCurrencyList();

        }

        public IAsyncRelayCommand LoadRatesCommand { get; }

        private async Task LoadRatesAsync()
        {
            var data = await _service.GetRateAsync(SelectedCurrencyObj?.Code ?? "USD");
            if (data?.Rates != null)
            {

                CurrencyList = new ObservableCollection<string>(data.Rates.Select(r => $"{r.Key}: {r.Value:N2}"));


                await _navigation.PushAsync(new RatesPage (CurrencyList, data.BaseCurrency));
            }
            else
            {
                Result = "Failed to fetch data.";
            
            }

        }
        private void LoadCurrencyList()
        {
            var currencies = CurrencyService.GetAvailableCurrencies();
            AvailableCurrencies = new ObservableCollection<Currency>(currencies);
            SelectedCurrencyObj = AvailableCurrencies.FirstOrDefault(c => c.Code == "USD"); // default
        }

    }
}
