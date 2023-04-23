using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.AccessControl;
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
using Реворк;

namespace Косметология
{
    /// <summary>
    /// Логика взаимодействия для Ваучер.xaml
    /// </summary>
    public partial class Ваучер : Window
    {
        


        public Ваучер(string fio, string usl, string price, string date)
        {
            InitializeComponent();

            lPr.Content += fio;
            lUsl.Content += usl;          
            lPrice.Content += price + " руб.";
            lDate.Content = "Дата проведения: " + date;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string date = DateTime.Today.ToString("G");
            PrintDialog pr = new PrintDialog();
            if (pr.ShowDialog() == true)
            {
                pr.PrintVisual(logoContainer1, $"{date}");
            }

            
        }
    }
}
