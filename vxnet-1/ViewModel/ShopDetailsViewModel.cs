using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vxnet_1.ViewModel
{
    [QueryProperty("Shop","Shop")]
    public partial class ShopDetailsViewModel : BaseViewModel
    {
        [ObservableProperty]
        ShopDTO shop;
        
        public ShopDetailsViewModel()
        {
            
        }

        [RelayCommand]
        async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync(".."); //also possible "..?id=1"  very cool :)
        }
    }
}
