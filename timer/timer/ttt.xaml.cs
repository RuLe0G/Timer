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
using System.Windows.Shapes;

namespace timer
{
    /// <summary>
    /// Логика взаимодействия для ttt.xaml
    /// </summary>
    public partial class ttt : Window
    {
        public ttt()
        {
            InitializeComponent();
            Calendar.DisplayMode = CalendarMode.Decade;
        }

        public void Name_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "no name ")
            {
                Name.Text = "";
                Name.Foreground.Opacity = 1;
            }
        }


        public void Name_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "")
            {
                Name.Foreground.Opacity = 0.5;
                Name.Text = "no name ";
            }
                
        }
    }
}
