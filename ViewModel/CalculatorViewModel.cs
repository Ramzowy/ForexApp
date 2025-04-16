using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ForexApp.Models;
using ForexApp.Services;
using System.Collections.ObjectModel;

namespace ForexApp.ViewModel
{
    public partial class CalculatorViewModel : ObservableObject
    {
        private readonly ExchangeRateService _exchangeRateService;

        [ObservableProperty]
        private decimal amount = 1m;

        [ObservableProperty]
        private string fromCurrency = "USD";

        [ObservableProperty]
        private string toCurrency = "EUR";

        [ObservableProperty]
        private decimal convertedAmount;

        [ObservableProperty]
        private decimal exchangeRate;

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private string errorMessage;

        [ObservableProperty]
        private ObservableCollection<string> availableCurrencies = new();

        public CalculatorViewModel(ExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
            InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            try
            {
                IsBusy = true;
                var rates = await _exchangeRateService.GetRateAsync("USD");
                if (rates?.Rates != null)
                {
                    AvailableCurrencies = new ObservableCollection<string>(rates.Rates.Keys.OrderBy(c => c));
                    await Calculate(); // Calculate with default values
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Failed to load currencies: {ex.Message}";
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task Calculate()
        {
            if (string.IsNullOrEmpty(FromCurrency) || string.IsNullOrEmpty(ToCurrency))
                return;

            try
            {
                IsBusy = true;
                ErrorMessage = null;

                // Get rates for the FromCurrency
                var rates = await _exchangeRateService.GetRateAsync(FromCurrency);

                if (rates?.Rates != null && rates.Rates.TryGetValue(ToCurrency, out var rate))
                {
                    ExchangeRate = rate;
                    ConvertedAmount = Amount * ExchangeRate;
                }
                else
                {
                    ErrorMessage = "Exchange rate not available for selected currencies";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Calculation failed: {ex.Message}";
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task SwapCurrencies()
        {
            (FromCurrency, ToCurrency) = (ToCurrency, FromCurrency);
            await Calculate();
        }
    }
}