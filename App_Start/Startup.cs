﻿using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(YemekSiparis.App_Start.Startup))]

namespace YemekSiparis.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType ="ApplicationCookie",
                LoginPath=new PathString("/Account/Login")
            });
        }
    }
}
