using Caliburn.Micro;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Xceed.Wpf.DataGrid;
using Xceed.Wpf.DataGrid.Markup;

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

        private DataView _users;

        public DataView Users
        {
            get { return _users; }
            set { _users = value; }
        }

        private ObservableCollection<DataGridColumn> _userRoleColumns = new ObservableCollection<DataGridColumn>();

        public ObservableCollection<DataGridColumn> UserRoleColumns
        {
            get { return _userRoleColumns; }
            set { _userRoleColumns = value; }
        }

        // ctor
        public DataGridViewModel()
        {
            AddCheckBox();
        }

        private DataGridControl _dataGridUsers;

        public DataGridControl DataGridUsers
        {
            get { return _dataGridUsers; }
            set { _dataGridUsers = value; }
        }

        public void AddCheckBox()
        {
            CellEditor cellEditor = new CellEditor();
            CellEditorBindingExtension cellEditorBinding = new CellEditorBindingExtension();

            FrameworkElementFactory check = new FrameworkElementFactory(typeof(System.Windows.Controls.CheckBox));
            cellEditor.EditTemplate = new DataTemplate();
            cellEditor.EditTemplate.VisualTree = check;
            DataGridUsers.Columns["CheckColumn"].CellEditor = cellEditor;
            DataGridUsers.Columns["CheckColumn"].CellEditorDisplayConditions = CellEditorDisplayConditions.Always;
            check.SetBinding(System.Windows.Controls.CheckBox.IsCheckedProperty, cellEditorBinding.ProvideValue(null) as BindingBase);

        }

    }
}
