using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
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

namespace RawWpfDataGridDynamicColDemoUsingDict
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<DataGridColumn> _columnCollection = new ObservableCollection<DataGridColumn>();
        public ObservableCollection<DataGridColumn> ColumnCollection
        {
            get
            {
                return this._columnCollection;
            }
            set
            {
                _columnCollection = value;
                INotifyPropertyChanged("ColumnCollection");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void INotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private DataTable _datatable = new DataTable();

        public DataTable Datatable
        {
            get
            {
                return _datatable;
            }
            set
            {
                if (_datatable != value)
                {
                    _datatable = value;
                }
                INotifyPropertyChanged("Datatable");
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            Datatable.Columns.Add("Name", typeof(string));
            Datatable.Columns.Add("Color", typeof(string));
            Datatable.Columns.Add("Phone", typeof(string));
            Datatable.Rows.Add("Vinoth", "#00FF00", "456345654");
            Datatable.Rows.Add("lkjasdgl", "Blue", "45654");
            Datatable.Rows.Add("Vinoth", "#FF0000", "456456");
            Binding bindings = new Binding("Name");
            Binding bindings1 = new Binding("Phone");
            Binding bindings2 = new Binding("Color");
            DataGridTextColumn s = new DataGridTextColumn();
            s.Header = "Name";
            s.Binding = bindings;
            DataGridTextColumn s1 = new DataGridTextColumn();
            s1.Header = "Phone";
            s1.Binding = bindings1;
            DataGridTextColumn s2 = new DataGridTextColumn();
            s2.Header = "Color";
            s2.Binding = bindings2;

            FrameworkElementFactory textblock = new FrameworkElementFactory(typeof(TextBlock));
            textblock.Name = "text";
            Binding prodID = new Binding("Name");
            Binding color = new Binding("Color");
            textblock.SetBinding(TextBlock.TextProperty, prodID);
            textblock.SetValue(TextBlock.TextWrappingProperty, TextWrapping.Wrap);
            //textblock.SetValue(TextBlock.BackgroundProperty, color);
            textblock.SetValue(TextBlock.NameProperty, "textblock");
            //FrameworkElementFactory border = new FrameworkElementFactory(typeof(Border));
            //border.SetValue(Border.NameProperty, "border");
            //border.AppendChild(textblock);
            //DataTrigger t = new DataTrigger();
            //t.Binding = new System.Windows.Data.Binding { Path = new PropertyPath("Name"), Converter = new EnableConverter(), ConverterParameter = "Phone" };
            //t.Value = 1;
            //t.Setters.Add(new Setter(TextBlock.BackgroundProperty, Brushes.LightGreen, textblock.Name));
            //t.Setters.Add(new Setter(TextBlock.ToolTipProperty, bindings, textblock.Name));
            //DataTrigger t1 = new DataTrigger();
            //t1.Binding = new System.Windows.Data.Binding { Path = new PropertyPath("Name"), Converter = new EnableConverter(), ConverterParameter = "Phone" };
            //t1.Value = 2;
            //t1.Setters.Add(new Setter(TextBlock.BackgroundProperty, Brushes.LightYellow, textblock.Name));
            //t1.Setters.Add(new Setter(TextBlock.ToolTipProperty, bindings, textblock.Name));

            DataTemplate d = new DataTemplate();
            d.VisualTree = textblock;
            //d.Triggers.Add(t);
            //d.Triggers.Add(t1);

            DataGridTemplateColumn s3 = new DataGridTemplateColumn();
            s3.Header = "Name 1";
            s3.CellTemplate = d;
            s3.Width = 140;

            ColumnCollection.Add(s);
            ColumnCollection.Add(s1);
            ColumnCollection.Add(s2);
            ColumnCollection.Add(s3);

            DataGridUsers.ItemsSource = ColumnCollection;

        }


    }
}
