using vxnet.APP.Services;
using vxnet.APP.Views;

namespace vxnet.APP.ViewModel
{
    public partial class ShopListViewModel : BaseViewModel
    {
        
        ShopService _shopService;
        IConnectivity _connectivity;
        public ObservableCollection<ShopDTO> Shops { get; } = new();
         
        public ShopListViewModel(ShopService shopService, IConnectivity connectivity)
        {
            Title = "Shop Locator";
            _shopService = shopService;
            _connectivity = connectivity;
        }

        [RelayCommand]
        async Task GoToDetailsAsync(ShopDTO shop)
        {
            if (shop is null)
                return;
            await Shell.Current.GoToAsync($"{nameof(DetailsPage)}", true, new Dictionary<string, object> { { "Shop", shop } });
        }

        [RelayCommand]
        async Task GetShopsAsync()
        {
            if (IsBusy)
                return; 
            try
            {
                if (_connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("Internet issue", "Check you connection to the internet and try again", "OK");
                    return;
                }

                IsBusy = true;
                var shopList = await _shopService.GetShopsAsync();

                if (Shops.Count != 0)
                    Shops.Clear();

                foreach (var item in shopList)
                {
                    Shops.Add(item);
                }
            }
            catch (Exception)
            {
                await Shell.Current.DisplayAlert("Error", "Not get shop list", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
