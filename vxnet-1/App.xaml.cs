using vxnet_1.Services;

namespace vxnet_1;

public partial class App : Application
{
	private readonly RegAppService _regAppService;
	public App(RegAppService regAppService)
	{
		InitializeComponent();
		MainPage = new AppShell();
		_regAppService = regAppService;
	}

	protected async override void OnStart()
	{
		base.OnStart();

		var appId = Preferences.Get("AppId","");
		if (string.IsNullOrWhiteSpace(appId))
		{
			var appReg = await _regAppService.RegisterAppIdAsync();
			Preferences.Set("AppId", appReg.Id);
		}
		
    }
}
