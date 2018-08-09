using System;

namespace Calculator.Web.Services
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Bootstrapper.Initialize();
        }
    }
}