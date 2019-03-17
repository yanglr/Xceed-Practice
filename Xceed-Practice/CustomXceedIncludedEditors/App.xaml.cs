using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;

namespace CustomXceedIncludedEditors
{
    public partial class App : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            XceedDeploymentLicense.SetLicense();
            base.OnStartup(e);
        }
    }
}
