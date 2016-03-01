using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(PerfectPattern.API.Startup))]

namespace PerfectPattern.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
