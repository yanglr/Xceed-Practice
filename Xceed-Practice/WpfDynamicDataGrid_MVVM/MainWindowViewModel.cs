/* MainWindow ViewModel */

namespace WpfDynamicDataGrid_MVVM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Dynamic;
    using System.Linq;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;

    /// <summary>
    /// MainWindow ViewModel
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Constructor

        public MainWindowViewModel()
        {
           // AddCommand = new RelayCommand(SaveExecute, CanExecuteSaveCommand);
           GetPersons();
           dataGrid.ItemsSource = ListOfPerson;

           AddDynamicColumnsToDataGrid();
        }
        #endregion

        #region Variables

        // DataGrid Instance in the viewModel
        private static DataGrid dataGrid = new DataGrid();

        #endregion

        #region Attached Property

        /// <summary>
        /// DataGrid Attached Property
        /// </summary>
        public static readonly DependencyProperty DataGridProperty = DependencyProperty.RegisterAttached("DataGrid",
                                                                     typeof(DataGrid), typeof(MainWindowViewModel),
                                                                     new FrameworkPropertyMetadata(OnDataGridChanged));

        public static void SetDataGrid(DependencyObject element, DataGrid value)
        {
            element.SetValue(DataGridProperty, value);
        }

        public static DataGrid GetDataGrid(DependencyObject element)
        {
            return (DataGrid)element.GetValue(DataGridProperty);
        }

        public static void OnDataGridChanged
            (DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            dataGrid = obj as DataGrid;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Property that is binded as the ItemsSource of the DataGrid
        /// </summary>
        private List<ExpandoObject> listOfPerson = new List<ExpandoObject>();
        public List<ExpandoObject> ListOfPerson
        {
            get { return listOfPerson; }
            set
            {
                listOfPerson = value;
                OnPropertyChanged("ListOfPersion");
            }
        }

        #endregion

        #region Methods
        
        /// <summary>
        /// Add dynamic columns to DataGrid
        /// </summary>
        private static void AddDynamicColumnsToDataGrid()
        {
            IEnumerable<IDictionary<string, object>> rows = dataGrid.ItemsSource.OfType<IDictionary<string, object>>();
            IEnumerable<string> columns = rows.SelectMany(d => d.Keys).Distinct(StringComparer.OrdinalIgnoreCase);

            // now set up a column and binding for each property
            PropertyInfo[] propertyInfos = typeof(Person).GetProperties();
            foreach (string text in columns)
            {
                var prop = propertyInfos.FirstOrDefault(p => p.Name == text);
                if (prop != null && prop.PropertyType.Equals(typeof(bool)))    // Set as checkbox if value is bool type
                {
                    var column = new DataGridCheckBoxColumn
                    {
                        Header = text,
                        Binding = new Binding(text)
                    };

                    dataGrid.Columns.Add(column);
                }
                else
                {
                    var column = new DataGridTextColumn
                    {
                        Header = text,
                        Binding = new Binding(text)
                    };

                    dataGrid.Columns.Add(column);
                }

            }
        }

        /// <summary>
        /// Get the list of the persons
        /// </summary>
        private void GetPersons()
        {
            //AddPersonToList(1, true, "Bhavik","bhavikmbarot@gmail.com");
            //AddPersonToList(2, false, "Rishi", "rishibarot@gmail.com");

            var randNum = new Random().Next(5, 9);
            for (int i = 0; i < randNum; i++)
            {
                AddPersonToList(i + 1,
                    (i % 3 == 0) ? true : false, 
                    "Name_" + (i + 1), 
                    "MailName-" + (i + 1) + (i % 2 == 1 ? "@gmail.com" : "@hotmail.com"));
            }

        }

        /// <summary>
        /// Add person to list
        /// </summary>
        /// <param name="id">Id of the person</param>
        /// <param name="name">Name of the person</param>
        /// <param name="email">EmailId of the person</param>
        /// <returns></returns>
        private dynamic AddPersonToList(dynamic id, dynamic isMale, dynamic name,dynamic email)
        {
            dynamic p1 = new ExpandoObject();
            p1.Id = id;
            p1.Name = name;
            p1.IsMale = isMale;

            p1.Email = email;  // Only etract the info we are interested

            listOfPerson.Add(p1);
            return p1;
        }

        #endregion

        #region INotifyPropertyChanged
        
        // Declare the event
        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion
    }
}

