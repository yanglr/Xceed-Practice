using Caliburn.Micro;
using System.ComponentModel;

namespace XceedDataGridDemo.ViewModels
{
    public class DataGridViewModel : Screen, INotifyPropertyChanged
    {
        private string _firstText = "Hey";

        public string FirstText
        {
            get { return _firstText; }
            set { _firstText = value; }
        }

    }
}
