using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace WpfWithOnlyXceed_DynamicColumns
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

            UserCollection.Add(new UserModel() { Name = "Yogi", ID = 1, AgeYears = 10 });
            UserCollection.Add(new UserModel() { Name = "BooBoo", ID = 2, AgeYears = 8 });
        }

        private ObservableCollection<UserModel> _userCollection = new ObservableCollection<UserModel>();
        public ObservableCollection<UserModel> UserCollection
        {
            get { return _userCollection; }
            set
            {
                _userCollection = value;
                NotifyPropertyChanged("UserCollection");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        // Pre .NET 4.5 implimentation
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
