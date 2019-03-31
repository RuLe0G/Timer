using System;
using System.Collections.Generic;
using System.IO;
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
        DateTime gg;
        DateTime dt;
        Dictionary<string, DateTime> list = new Dictionary<string, DateTime>();

        System.Windows.Threading.DispatcherTimer Timer;


        public MainWindow()
        {
            InitializeComponent();
            Timer = new System.Windows.Threading.DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            ttt ttt = new ttt();

            if (ttt.ShowDialog() == true)
            {
                gg = ttt.Calendar.SelectedDate.Value;
                Txt.Items.Add(ttt.Name.Text.ToString());

                dt = new DateTime(ttt.Calendar.SelectedDate.Value.Year, ttt.Calendar.SelectedDate.Value.Month, ttt.Calendar.SelectedDate.Value.Day, int.Parse(ttt.Hours.Text), int.Parse(ttt.Minutes.Text), int.Parse(ttt.Seconds.Text));
                list.Add(ttt.Name.Text, dt);
            }
            else
            {

            }
        }

        private void Txt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Timer.Tick += new EventHandler(dispatcherTimer_Tick);
            Timer.Start();

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {

            if (Txt.SelectedIndex > -1)
            {
                TimeSpan ts = (list[Txt.SelectedValue.ToString()]) - DateTime.Now;
                if (ts.TotalSeconds < 0)
                {
                    lb.Content = "Закончен";
                }
                else
                {
                    int so = ts.Seconds + (ts.Minutes * 60) + (ts.Hours * 1440) + (ts.Days * 86400);
                    int mo = ts.Minutes + (ts.Hours * 60) + (ts.Days * 1440);
                    int ho = ts.Hours + (ts.Days * 24);
                    if (www.IsChecked == true) { lb.Content = (" Осталось " + ts.Days + " дней  " + ts.Hours + " часов " + ts.Minutes + " минут " + ts.Seconds + " секунд"); qqq.IsChecked = false; eee.IsChecked = false; rrr.IsChecked = false; }
                    if (qqq.IsChecked == true) { lb.Content = (" Осталось " + so + " секунд"); www.IsChecked = false; eee.IsChecked = false; rrr.IsChecked = false; };
                    if (eee.IsChecked == true) { lb.Content = (" Осталось " + ho + " часов " + ts.Minutes + " минут " + ts.Seconds + " секунд"); www.IsChecked = false; qqq.IsChecked = false; rrr.IsChecked = false; };
                    if (rrr.IsChecked == true) { lb.Content = (" Осталось " + mo + " минут " + ts.Seconds + " секунд"); qqq.IsChecked = false; eee.IsChecked = false; www.IsChecked = false; };
                }
            }

        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ttt ttt = new ttt(Txt.SelectedValue.ToString(), dt.Hour, dt.Second, dt.Minute, gg, list[Txt.SelectedValue.ToString()]);

            if (ttt.ShowDialog() == true)
            {


                dt = new DateTime(ttt.Calendar.SelectedDate.Value.Year, ttt.Calendar.SelectedDate.Value.Month, ttt.Calendar.SelectedDate.Value.Day, int.Parse(ttt.Hours.Text), int.Parse(ttt.Minutes.Text), int.Parse(ttt.Seconds.Text));

                //list.Remove(ttt.Name.Text.ToString());

                list[ttt.Name.Text] = dt;
            }
            else
            {

            }
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            list.Remove(Txt.SelectedValue.ToString());
            Txt.Items.Remove(Txt.SelectedValue.ToString());

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Document";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";
            dlg.ShowDialog();

            using (StreamWriter outputFile = new StreamWriter(dlg.FileName))
            {

                foreach (var item in Txt.Items)
                {
                    outputFile.WriteLine(item.ToString());
                    outputFile.WriteLine("*");
                    outputFile.WriteLine(list[item.ToString()]);
                }
            }


        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.FileName = "Document";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";

            dlg.ShowDialog();


            using (System.IO.StreamReader sr = new System.IO.StreamReader(dlg.FileName))
            {
                string line;
                string str;
                string j;

                while ((line = sr.ReadLine()) != null)
                {
                    str = line;
                    list.Add(str, new DateTime(0));
                    if (line == "*")
                    {
                        j = line;
                        list[str] = DateTime.Parse(j);
                        
                    }

                }
                sr.Close();
            }
        }
    }
}
