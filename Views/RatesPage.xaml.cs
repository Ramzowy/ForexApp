using ForexApp.ViewModel;
using System.Collections.ObjectModel;

namespace ForexApp.Views;

public partial class RatesPage : ContentPage
{
	public RatesPage( ObservableCollection<string> currencyList, string baseCurrency )
	{
		InitializeComponent();
        BindingContext = new RatesViewModel(currencyList, baseCurrency);
    }
}