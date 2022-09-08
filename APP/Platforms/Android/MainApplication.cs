using Android.App;
using Android.Runtime;

namespace vxnet.APP;

#if DEBUG
[Application(UsesCleartextTraffic = true)]  // todo arjan check this: connect to local service?
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
