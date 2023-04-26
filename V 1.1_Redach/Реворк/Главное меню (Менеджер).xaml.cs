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
using Реворк;


namespace Косметология
{
    /// <summary>
    /// Логика взаимодействия для Главное_меню__Менеджер_.xaml
    /// </summary>
    public partial class Главное_меню__Менеджер_ : Window
    {
        public Главное_меню__Менеджер_()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Регистрация().ShowDialog(); ;
            this.Close();
        }

        private void Krest_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Cherta_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Выход_в_Логин(object sender, RoutedEventArgs e)
        {

        }

        private void Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new MainWindow().ShowDialog();
            this.Close();
        }

        private void Tollbar_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Оформление_заявки().ShowDialog(); ;
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Редактировать_заказ().ShowDialog(); ;
            this.Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Редактирование_клиентов().ShowDialog(); ;
            this.Close();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Отчет_Ваучер().Show();
            this.Close();
        }
    }
}