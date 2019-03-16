using Caliburn.Micro;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        }
        

    }
}
