using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CustomXceedIncludedEditors
{
  public class MainPageParams : INotifyPropertyChanged
  {
    public static readonly MainPageParams Singleton = new MainPageParams();

    #region CONSTRUCTORS

    private MainPageParams()
    {
    }

    #endregion CONSTRUCTORS


    #region MaskedTextColumnsVisible

    private bool m_maskedTextColumnsVisible = true;

    public bool MaskedTextColumnsVisible
    {
      get 
      { 
        return m_maskedTextColumnsVisible; 
      }
      
      set 
      {
        if( m_maskedTextColumnsVisible == value )
          return;

        m_maskedTextColumnsVisible = value;

        this.OnPropertyChanged( new PropertyChangedEventArgs( "MaskedTextColumnsVisible" ) );
      }
    }

    #endregion MaskedTextColumnsVisible

    #region CheckBoxColumnsVisible

    private bool m_checkBoxColumnsVisible = true;

    public bool CheckBoxColumnsVisible
    {
      get
      {
        return m_checkBoxColumnsVisible;
      }

      set
      {
        if( m_checkBoxColumnsVisible == value )
          return;

        m_checkBoxColumnsVisible = value;

        this.OnPropertyChanged( new PropertyChangedEventArgs( "CheckBoxColumnsVisible" ) );
      }
    }

    #endregion CheckBoxColumnsVisible


    #region INotifyPropertyChanged Members

    protected void OnPropertyChanged( PropertyChangedEventArgs e )
    {
      if( this.PropertyChanged != null )
        this.PropertyChanged( this, e );
    }

    public event PropertyChangedEventHandler PropertyChanged;

    #endregion
  }
}
