using System;
using System.Collections.Generic;
using Caliburn.Micro;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using Xceed.Wpf.DataGrid;
using XceedDataGridDemo.Models;

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

        private BindableCollection<Person> _people = new BindableCollection<Person>();

        public BindableCollection<Person> People
        {
            get { return _people; }
            set
            {
                _people = value;
                NotifyOfPropertyChange(() => People);
            }
        }
                
        private Person _selectedPerson;

        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value; 
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }

        
        // ctor
        public DataGridViewModel()
        {
            People.Add(new Person
            {
                FirstName = "John",
                LastName = "Doe"
            });

            People.Add(new Person
            {
                FirstName = "Bruce",
                LastName = "Lee"
            });

            People.Add(new Person
            {
                FirstName = "Bravo",
                LastName = "Yeung"
            });

            SelectedPerson = People.FirstOrDefault(); // Select first by default

            InitColumnHeaders();
            PopulateTable();
        }

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
            RandomDataTable.Columns.Add(new DataColumn("Gender", typeof(bool)));  // Auto turn into checkbox
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
                NotifyOfPropertyChange(() => RandomDataTable);
            }
        }

        private ObservableCollection<DataTable> _randomData = new ObservableCollection<DataTable>();

        public ObservableCollection<DataTable> RandomData
        {
            get { return _randomData; }
            set
            {
                _randomData = value;
                NotifyOfPropertyChange(() => RandomDataTable);
            }
        }

    }
}
