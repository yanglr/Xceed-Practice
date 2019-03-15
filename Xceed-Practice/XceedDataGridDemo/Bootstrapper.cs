using System.Windows;
using Caliburn.Micro;
using XceedDataGridDemo.ViewModels;

namespace XceedDataGridDemo
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object obj, StartupEventArgs e)
        {
            XceedDeploymentLicense.SetLicense();  // load Xceed license

            DisplayRootViewFor<DataGridViewModel>();
        }
    }
}
