using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RawWpfDataGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ObservableCollection<Employee> Employee = new ObservableCollection<Employee>();
            Employee.Add(new Employee
            {
                ID = 1,
                Name = "Kay",
                IsMale = false,
                Type = EmployeeType.Normal,
                SiteID = new Uri("http://kay.github.io"),
                BirthDate = new DateTime(1980, 1, 1)
            });

            Employee.Add(new Employee
            {
                ID = 2,
                Name = "Bravo",
                IsMale = false,
                Type = EmployeeType.Normal,
                SiteID = new Uri("http://bravo.coding.net"),
                BirthDate = new DateTime(1980, 2, 1)
            });

            Employee.Add(new Employee
            {
                ID = 3,
                Name = "Vicky",
                IsMale = false,
                Type = EmployeeType.Normal,
                SiteID = new Uri("http://vikey.github.io"),
                BirthDate = new DateTime(1980, 2, 1)
            });

            myDataGrid.AutoGeneratingColumn += myDataGrid_AutoGeneratingColumns;
            myDataGrid.ItemsSource = Employee;

        }

        public class Employee
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public bool IsMale { get; set; }
            public EmployeeType Type { get; set; }
            public Uri SiteID { get; set; }
            public DateTime BirthDate { get; set; }
        }

        public enum EmployeeType
        {
            Normal,
            Supervisor,
            Manager
        }

        public void myDataGrid_AutoGeneratingColumns(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "ID")
                e.Cancel = true;

            if (e.PropertyName == "Name")
            {
                e.Column.Header = "First Name";
            }

        }

    }
}
