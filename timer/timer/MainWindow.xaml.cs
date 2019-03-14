using System;
using System.Collections.Generic;
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

namespace timer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime dt;
        Dictionary<string, DateTime> list = new Dictionary<string, DateTime>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {  

            ttt ttt = new ttt();
            
            if (ttt.ShowDialog() == true)
            {
                dt = new DateTime(ttt.Calendar.SelectedDate.Value.Year, ttt.Calendar.SelectedDate.Value.Month, ttt.Calendar.SelectedDate.Value.Day, int.Parse(ttt.Hours.Text), int.Parse(ttt.Minutes.Text), int.Parse(ttt.Seconds.Text));
                list.Add(ttt.Name.Text, dt);
            }
            else
            {

            }
        } 
        }
    }
