namespace vxnet.APP.Views;

public partial class DetailsPage : ContentPage
{
	
	public DetailsPage(ShopDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}