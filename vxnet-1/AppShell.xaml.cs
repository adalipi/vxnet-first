﻿namespace vxnet_1;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
	}
}
