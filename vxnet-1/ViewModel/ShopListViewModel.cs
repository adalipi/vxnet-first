using vxnet_1.Services;
using vxnet_1.Views;

namespace vxnet_1.ViewModel
{
    public partial class ShopListViewModel : BaseViewModel
    {
        
        ShopService _shopService;
        public ObservableCollection<ShopDTO> Shops { get; } = new();

        public ShopListViewModel(ShopService shopService)
        {
            Title = "Shop Locator";
            _shopService = shopService;
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
                IsBusy = true;
                var shopList = await _shopService.GetShopsAsync();

                if (Shops.Count != 0)
                    Shops.Clear();

                foreach (var item in shopList)
                {
                    Shops.Add(item);
                }
            }
            catch (Exception ex)
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
