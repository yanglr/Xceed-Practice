using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows;
using Xceed.Wpf.DataGrid;

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

            InitColumnHeaders();
            PopulateTable();
            myGrid.ItemsSource = new DataGridCollectionView(RandomDataTable.DefaultView);
        }

        private DataTable _randomData = new DataTable();
        private static readonly Random _random = new Random();

        private bool GetRandomBool()
        {
            return (_random.Next(0, 2) == 1);
        }

        private string GetRandomName()
        {
            var names = new List<string>();
            names.Add("Casey");
            names.Add("Darcy");
            names.Add("Max");
            names.Add("Lee");

            int rIdx = _random.Next(names.Count);
            return names[rIdx];
        }

        private int GetRandomInteger()
        {
            return _random.Next(0, 13);
        }

        private static double GetRandomDouble(double multiplier)
        {
            return Math.Round((_random.NextDouble() * multiplier), 2);
        }

        private void PopulateTable()
        {
            for (int i = 0; i < 8; i++)
            {
                object[] values = new object[] {
                    GetRandomBool(),
                    GetRandomName(),
                    GetRandomDouble(100),
                    GetRandomInteger()
                };

                RandomDataTable.Rows.Add(values);
            }
        }

        private void InitColumnHeaders()
        {
            RandomDataTable.Columns.Add(new DataColumn("Gendar", typeof(bool)));
            RandomDataTable.Columns.Add(new DataColumn("Name", typeof(string)));
            RandomDataTable.Columns.Add(new DataColumn("Score", typeof(double)));
            RandomDataTable.Columns.Add(new DataColumn("Win Times", typeof(int)));
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

        public DataTable RandomData
        {
            get { return RandomDataTable; }
            set
            {
                RandomData = value;
                NotifyPropertyChanged("RandomData");
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
