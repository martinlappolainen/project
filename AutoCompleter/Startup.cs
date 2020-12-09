using Microsoft.Owin;
using Owin;
using System;

[assembly: OwinStartupAttribute(typeof(AutoCompleter.Startup))]
namespace AutoCompleter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
		{
            ConfigureAuth(app);
		}

		
	}
}