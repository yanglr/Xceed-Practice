using Caliburn.Micro;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace WpfDataGridDynamicColumns_MVVM.ViewModels
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
