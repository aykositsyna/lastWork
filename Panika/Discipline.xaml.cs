using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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

namespace lastWork
{
    /// <summary>
    /// Логика взаимодействия для Disciplina.xaml
    /// </summary>
    public partial class Discipline : UserControl, INotifyPropertyChanged
    {
        private bool _status;
        public bool Status
        {
            get { return _status; }
            set
            {
                _status = value;
                NotifyPropertyChanged("Status");
            }
        }


        private string _title;
        public string Title
        {
            get { return _title;}
            set
            {
                _title = value;
                NotifyPropertyChanged("Title");
            }
        }

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public Discipline()
        {
            InitializeComponent();
        }



        public Discipline(string str, bool status)
        {
            InitializeComponent();

            Title = str;

            Status = status;
            

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void CheckStatus()
        {
            Status = !Status;
        }

        public void SetFilter(int index)
        {
            this.Visibility = Visibility.Collapsed;

            if (index == 0)
            {
                this.Visibility = Visibility.Visible;
            }
            else
            {
                if (index == 1 && Status)
                {
                    this.Visibility = Visibility.Visible;
                }
                else
                {
                    if (index == 2 && Status==false)
                    {
                        this.Visibility = Visibility.Visible;
                    }
                }
            }

               
        }
    }
}
