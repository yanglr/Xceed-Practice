using Caliburn.Micro;

namespace XceedDataGridDemo.ViewModels
{
    public class ShellViewModel : Conductor<IScreen>
    {
        private DataGridViewModel _dataGridViewModel;

        public ShellViewModel()
        {
            DisplayName = "Xceed Demo";  // Set Title for default window title, also can be set once in ShellView.xaml using "Title="

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

    }
}
