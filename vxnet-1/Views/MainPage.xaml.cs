namespace vxnet_1.Views;

public partial class MainPage : ContentPage
{
	public MainPage(ShopListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

}

