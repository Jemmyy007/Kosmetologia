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

namespace Косметология
{
    /// <summary>
    /// Логика взаимодействия для Главное_меню__Админ_.xaml
    /// </summary>
    public partial class Главное_меню__Админ_ : Window
    {
        public Главное_меню__Админ_()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Специалисты().ShowDialog();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new MainWindow().ShowDialog();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Логины().ShowDialog();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Цены().ShowDialog();
            this.Close();

        }
    }
}
