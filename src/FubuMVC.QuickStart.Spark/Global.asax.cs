using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using FubuMVC.Core;
using FubuMVC.StructureMap;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace FubuMVC.QuickStart.Spark
{
    public class Global : System.Web.HttpApplication
    {
        private FubuRuntime _runtime;

        protected void Application_Start(object sender, EventArgs e)
        {
            // Simplest possible way to bootstrap w/ StructureMap

            // You can do this if you want:
            //  FubuApplication.DefaultPolicies().StructureMap(new Container()).Bootstrap();

            _runtime = FubuApplication.BootstrapApplication<MyApplication>();
        }

        protected void Application_End(object sender, EventArgs e)
        {
            _runtime.Dispose();
        }
    }

    // Using a separate class for bootstrapping makes it much easier to reuse your application 
    // in testing scenarios with either SelfHost or OWIN/Katana hosting
    public class MyApplication : IApplicationSource
    {
        public FubuApplication BuildApplication()
        {
            // This is bootstrapping an application with all default FubuMVC conventions and
            // policies pulling actions from only this assembly for classes suffixed with
            // "Endpoint" or "Endpoints"
            return FubuApplication.DefaultPolicies().StructureMap(new Container());



            // Fancier way if you want to specify your own policies:
            // return FubuApplication.For<MyFubuMvcPolicies>().StructureMap(new Container());


            // Here's an example of using StructureMap specific registration with a StructureMap Registry.  
            // return FubuApplication.For<MyFubuMvcPolicies>().StructureMap<MyStructureMapRegistry>();
            
        }
    }

    public class MyStructureMapRegistry : Registry
    {
        public MyStructureMapRegistry()
        {
            // StructureMap registration here
        }
    }

    public class MyFubuMvcPolicies : FubuRegistry
    {
        public MyFubuMvcPolicies()
        {
            // This is a DSL to change or add new conventions, policies, or application settings
        }
    }
}