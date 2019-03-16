using Caliburn.Micro;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xceed.Wpf.DataGrid;

namespace XceedDataGridDemo.ViewModels
{
    public class DataGridViewModel : PropertyChangedBase, INotifyPropertyChanged
    {
        private string _firstText = "Hey, smart guy.";

        public string FirstText
        {
            get { return _firstText; }
            set { _firstText = value; }
        }

        // ctor
        public DataGridViewModel()
        {
        }
        

    }
}
