
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

namespace ForexApp.ViewModel
{
  public partial class MainViewModel : ObservableObject
    {
        
        private readonly ExchangeRateService _service = new();

        [ObservableProperty]
        private string baseCurrency = "USD";

        [ObservableProperty]
        private ObservableCollection<string> currencyList = new();

        [ObservableProperty]
        private string selectedCurrency;

        [ObservableProperty]
        private string result;

        public MainViewModel()
        {

            LoadRatesCommand = new AsyncRelayCommand(LoadRatesAsync); 
        
        }

        public IAsyncRelayCommand LoadRatesCommand { get; }

        private async Task LoadRatesAsync()
        {
            var data = await _service.GetRateAsync(BaseCurrency);
            if (data?.Rates != null)
            {

                CurrencyList = new ObservableCollection<string>(data.Rates.Select(r => $"{r.Key}: {r.Value:N2}"));

                Result = $"Exchange rates for {data.BaseCurrency}";

            }
            else
            {
                Result = "Failed to fetch data.";
            
            }

        }

    }
}
