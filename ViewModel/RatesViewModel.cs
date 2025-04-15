using CommunityToolkit.Mvvm.ComponentModel;
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

        public RatesViewModel(ObservableCollection<string> rates, string baseCurrency)
        {
            // Initialize the formatted currency list
            CurrencyList = rates;

            // Set the page title
            Title = $"Rates for {baseCurrency}";

        }

    }
}
