using Android.App;
using Android.Runtime;
using System.Net;

namespace vxnet_1;

#if DEBUG
[Application(UsesCleartextTraffic = true)]  // connect to local service
#else 
[Application]
#endif
public class MainApplication : MauiApplication
{
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
    }

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
