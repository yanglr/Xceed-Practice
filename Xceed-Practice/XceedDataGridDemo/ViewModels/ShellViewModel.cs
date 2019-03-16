using Caliburn.Micro;

namespace XceedDataGridDemo.ViewModels
{
    public class ShellViewModel : Conductor<IScreen>
    {
        private const string WindowTitleDefault = "Xceed Demo";
        private string _windowTitle = WindowTitleDefault;
        private DataGridViewModel _dataGridViewModel;

        public ShellViewModel()
        {
            DisplayName = "Xceed Demo";
            DataGridViewModel = new DataGridViewModel();
        }

        public DataGridViewModel DataGridViewModel
        {
            get { return _dataGridViewModel; }
            set
            {
                _dataGridViewModel = value;
                NotifyOfPropertyChange(() => DataGridViewModel);
            }
        }

        public string WindowTitle
        {
            get { return _windowTitle; }
            set
            {
                _windowTitle = value;
                NotifyOfPropertyChange(() => WindowTitle);
            }
        }

    }
}
