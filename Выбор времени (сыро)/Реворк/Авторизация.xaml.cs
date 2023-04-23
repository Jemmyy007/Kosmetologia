using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.OleDb;
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
using System.Data;

namespace Косметология
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;


        public MainWindow()

        {
            InitializeComponent();


        }

        private void Krest_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Cherta_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Tollbar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            string user = Login.Text;
            string password = Password.Password;
            
            con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = КосметологияБД2.accdb");
            string query = "SELECT * FROM logins where Login ='" + Login.Text + "' AND Password='" + password + "' AND Должность = '" + Polsovatel.Text + "'";
            OleDbDataAdapter ad = new OleDbDataAdapter(query, con);
            DataTable dtbl = new DataTable();
            ad.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                if (Polsovatel.SelectedIndex == 0)
                {
                    this.Hide();
                    new Главное_меню__Менеджер_().ShowDialog();
                    this.Close();
                }

                else if (Polsovatel.SelectedIndex == 1)
                {

                    this.Hide();
                    new Главное_меню__Админ_().ShowDialog();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Неверный Логин, Парорль или Выбор пользователя");
            }
            con.Close();



            /*
            string user = Login.Text;
            string password = Password.Text;
            con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = КосметологияБД2.accdb");
            string query = "SELECT * FROM logins where Login ='" + Login.Text + "' AND Password='" + Password.Text + "'";
            OleDbDataAdapter ad = new OleDbDataAdapter(query, con);
            DataTable dtbl = new DataTable();
            ad.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                if (Polsovatel.SelectedIndex == 0)
                {
                    this.Hide();
                    new Главное_меню__Менеджер_().ShowDialog();
                    this.Close();
                }

                else if (Polsovatel.SelectedIndex == 1)
                {

                    this.Hide();
                    new Главное_меню__Админ_().ShowDialog();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Неверный Логин, Парорль или Выбор пользователя");
            }
            con.Close();

            */





            /*  string user = Login.Text;
              string password = Password.Text;
              con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = КосметологияБД2.accdb");
              string query = "SELECT * FROM logins where Login ='" + Login.Text + "' AND Password='" + Password.Text + "' AND Должность = '" + Polsovatel.SelectedIndex + "'"; ;
              OleDbDataAdapter ad = new OleDbDataAdapter(query, con);
              DataTable dtbl = new DataTable();
              ad.Fill(dtbl);
              if (dtbl.Rows.Count == 1 && Polsovatel.SelectedIndex == 0)
              {
                  this.Hide();
                  new Главное_меню__Менеджер_().ShowDialog();
                  this.Close();
              }
              else if (dtbl.Rows.Count == 1 && Polsovatel.SelectedIndex == 1)
              {

                  this.Hide();
                  new Главное_меню__Админ_().ShowDialog();
                  this.Close();
              }
              else
              {
                  MessageBox.Show("Неверный Логин, Парорль или Выбор пользователя");
              }
              con.Close() */






            /* string user = Login.Text;
             string password = Password.Text;
             con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = КосметологияБД2.accdb");
             cmd = new OleDbCommand();
             con.Open();
             cmd.Connection = con;

             string str = "SELECT * FROM logins where Login ='" + Login.Text + "' AND Password='" + Password.Text + "'";
             cmd.CommandText = str;
             dr = cmd.ExecuteReader();



             if (Polsovatel.SelectedIndex == 0 && user == "meneger" && password == "qwer")
             {
                 this.Hide();
                 new Главное_меню__Менеджер_().ShowDialog();
                 this.Close();
             }
             else if (Polsovatel.SelectedIndex == 1 && user == "admin" && password == "qwer")
             {
                 this.Hide();
                 new Главное_меню__Админ_().ShowDialog();
                 this.Close();
             }
             else
             {
                 MessageBox.Show("Неверный Логин, Парорль или Выбор пользователя");
             }
             con.Close();
            */
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
