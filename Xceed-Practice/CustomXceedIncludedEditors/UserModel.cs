using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfWithOnlyXceed_DynamicColumns
{
    public class UserModel
    {
        #region AgeYears
        private int m_AgeYears;
        public int AgeYears
        {
            [DebuggerStepThrough]
            get
            {
                return m_AgeYears;
            }

            [DebuggerStepThrough]
            set
            {
                if (m_AgeYears == value) return;
                m_AgeYears = value;
                NotifyPropertyChanged("AgeYears");
            }
        }

        #endregion AgeYears



        #region ID
        private int m_ID;
        public int ID
        {
            [DebuggerStepThrough]
            get
            {
                return m_ID;
            }

            [DebuggerStepThrough]
            set
            {
                if (m_ID == value) return;
                m_ID = value;
                NotifyPropertyChanged("ID");
            }
        }
        #endregion ID



        #region Name
        private string m_Name;
        public string Name
        {
            [DebuggerStepThrough]
            get
            {
                return m_Name;
            }

            [DebuggerStepThrough]
            set
            {
                if (m_Name == value) return;
                m_Name = value;
                NotifyPropertyChanged("Name");
            }
        }
        #endregion Name

        public event PropertyChangedEventHandler PropertyChanged;
        // Pre .NET 4.5 implimentation
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
