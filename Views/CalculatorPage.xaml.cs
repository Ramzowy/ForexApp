using ForexApp.ViewModel;

namespace ForexApp.Views;


public partial class CalculatorPage : ContentPage
{
	public CalculatorPage(CalculatorViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

    }
}