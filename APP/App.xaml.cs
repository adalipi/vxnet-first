using vxnet.APP.Services;

namespace vxnet.APP;

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
		
		var appid = Preferences.Get("appid", "");
		if (string.IsNullOrWhiteSpace(appid))
		{
			var appreg = await _regAppService.RegisterAppIdAsync();
            Preferences.Set("appid", appreg.Id);
		}
	}
	
}
