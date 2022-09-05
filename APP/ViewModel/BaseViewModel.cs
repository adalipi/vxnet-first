
namespace vxnet.APP.ViewModel
{
    public partial class BaseViewModel : ObservableObject
    {
        
        [ObservableProperty]
        bool _isBusy;
        
        [ObservableProperty]
        string _title;

        public bool IsNotBusy => !IsBusy;
    }
}
