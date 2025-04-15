namespace ForexApp.Views;
using ForexApp.ViewModel;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        BindingContext = new MainViewModel(Navigation);
    }
}