using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Logic logic;
        public MainWindow()
        {
            InitializeComponent();

            

            logic = new Logic();
            logic.Subjects = new ObservableCollection<Discipline>();
            
            StartFileRead();
            DataContext = logic;

            RBAll.IsChecked = true;
        }

        public async Task StartFileRead()
        {
            var file = File.ReadAllText("subjects.txt");

            var bn = file.Split('\n');
            foreach (var s in bn)
            {
                var _array = s.Split(',');
                logic.Subjects.Add(new Discipline(_array[0], bool.Parse(_array[1])));
            }
        }

        public async Task Save()
        {
            string str="";
            foreach (Discipline logicSubject in logic.Subjects)
            {
                if (str != "")
                {
                    str += "\n";
                }

                str += $"{logicSubject.Title},{logicSubject.Status}";
            }
            File.WriteAllText("subjects.txt", str);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            logic.SelectedSubject.CheckStatus();
            Save();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (logic.SelectedSubject != null)
            {
                logic.Subjects.Remove(logic.SelectedSubject);
                Save();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (TBDiscip.Text != "" && CBStatus.SelectedIndex != -1)
            { 
               var Disc= new Discipline(TBDiscip.Text, CBStatus.SelectedIndex == 0);
               logic.Subjects.Add(Disc);
               TBDiscip.Text = "";
               CBStatus.SelectedIndex = -1;
               Save();
            }
        }

        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            int index = 0;

            if (RBPassed.IsChecked == true)
            {
                index = 1;
            }

            if (RBNotPassed.IsChecked == true)
            {
                index = 2;
            }

            foreach (Discipline logicSubject in logic.Subjects)
            {
                logicSubject.SetFilter(index);
            }

        }
    }
}
