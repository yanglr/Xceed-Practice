using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows;

namespace CustomXceedIncludedEditors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            XceedDeploymentLicense.SetLicense();  // load Xceed license

            InitializeComponent();

            RandomDataTable.Columns.Add(new DataColumn("Included", typeof(bool)));
            RandomDataTable.Columns.Add(new DataColumn("Name", typeof(string)));

            RandomDataTable.Columns.Add(new DataColumn("Price", typeof(double)));
            RandomDataTable.Columns.Add(new DataColumn("Quantity", typeof(int)));

            for (int i = 0; i < 8; i++)
            {
                object[] values = new object[] {
                    true,
                    "Bruce",
                    20.5,
                    66
                };

                RandomDataTable.Rows.Add(values);
            }

        }

        private DataTable _randomDataTable = new DataTable();

        public DataTable RandomDataTable
        {
            get { return _randomDataTable; }
            set
            {
                _randomDataTable = value; 
                NotifyPropertyChanged("RandomDataTable");
            }
        }


        //private ObservableCollection<UserModel> _userCollection = new ObservableCollection<UserModel>();
        //public ObservableCollection<UserModel> UserCollection
        //{
        //    get { return _userCollection; }
        //    set
        //    {
        //        _userCollection = value;
        //        NotifyPropertyChanged("UserCollection");
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        // Pre .NET 4.5 implimentation
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
