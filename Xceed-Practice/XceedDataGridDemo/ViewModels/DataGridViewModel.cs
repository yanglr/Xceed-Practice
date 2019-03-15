using Caliburn.Micro;
using System.ComponentModel;

namespace XceedDataGridDemo.ViewModels
{
    public class DataGridViewModel : PropertyChangedBase, INotifyPropertyChanged
    {
        private string _firstText = "Hey";

        public string FirstText
        {
            get { return _firstText; }
            set { _firstText = value; }
        }

    }
}
