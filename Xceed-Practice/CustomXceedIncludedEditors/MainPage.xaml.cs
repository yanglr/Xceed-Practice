using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CustomXceedIncludedEditors
{
    public partial class MainPage : System.Windows.Controls.Page
  {
    private static DataTable RandomDataTable;
    private static Random Randomizer = new Random();

    private static List<string> DepartmentsList;

    private const string Consonnants = "bcdfgjklmnprstv";
    private const string Vowels = "aeiou";

    private static bool GetRandomBool()
    {
      return ( MainPage.Randomizer.Next( 0, 2 ) == 1 );
    }

    private static string GetRandomName()
    {
        var names = new List<string>();
        names.Add("Bruce");
        names.Add("Andy");
        names.Add("Mike");

        int rIdx = Randomizer.Next(names.Count);
        return names[rIdx];
    }

    private static int GetRandomInteger()
    {
      return MainPage.Randomizer.Next( 0, 13 );
    }

    private static double GetRandomDouble( double multiplier )
    {
      return Math.Round( ( MainPage.Randomizer.NextDouble() * multiplier ), 2 );
    }

    static MainPage()
    {
      MainPage.DepartmentsList = new List<string>();
      MainPage.DepartmentsList.Add( "Development" );

      MainPage.RandomDataTable = new DataTable();

      MainPage.RandomDataTable.Columns.Add( new DataColumn( "Included", typeof( bool ) ) );
      MainPage.RandomDataTable.Columns.Add( new DataColumn( "Name", typeof( string ) ) );

      MainPage.RandomDataTable.Columns.Add( new DataColumn( "Price", typeof( double ) ) );
      MainPage.RandomDataTable.Columns.Add( new DataColumn( "Quantity", typeof( int ) ) );

      for( int i = 0; i < 8; i++ )
      {
        object[] values = new object[] { 
          MainPage.GetRandomBool(), 
          MainPage.GetRandomName(),

          MainPage.GetRandomDouble( 100 ), 
          MainPage.GetRandomInteger()
        };

        MainPage.RandomDataTable.Rows.Add( values );
      }
    }

    public MainPage()
    {
      InitializeComponent();
    }

    public DataTable RandomData
    {
      get
      {
        return MainPage.RandomDataTable;
      }
    }

    public List<String> Departments
    {
      get
      {
        return MainPage.DepartmentsList;
      }
    }

  }
}
