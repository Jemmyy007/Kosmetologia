using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
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
using System.Data.SqlClient;

namespace Косметология
{
    /// <summary>
    /// Логика взаимодействия для Регистрация.xaml
    /// </summary>
    public partial class Регистрация : Window
    {

        private SqlConnection myConnection;
        public static string connectString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True";  // Подключаем БД

        SqlConnection con;  // Задаем осн. команды для использования
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataSet ds;
        
        public Регистрация()
        {
            InitializeComponent();
            txtBirth.DisplayDateEnd = DateTime.Now;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Главное_меню__Менеджер_().ShowDialog();
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            con.Open();
        
        try {
              
            string fio = txtFio.Text;
            string phone = txtTel.Text;
            string mail = txtMail.Text;
            string birth = txtBirth.Text;
            string seria = txtSeria.Text;
            string nomer = txtNomer.Text;
            string kod = txtKodP.Text;
            string kemVid = txtKemVidan.Text;
            string kogdaVid = txtKogdaVidan.Text;

            
            string query = $"INSERT INTO Clients (ФИО, Телефон, Mail, [Дата рождения], [Серия паспорта], [Номер паспорта], [Код подразделения], [Кем выдан], [Дата выдачи]) VALUES " + 
                $" (N'{fio} ', N'{phone}', N'{mail}', N'{birth}', N'{seria}', N'{nomer}', N'{kod}', N'{kemVid}', N'{kogdaVid}')";

            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Клиент был зарегистрирован");

                txtFio.Text = "";
                txtTel.Text = "";
                txtMail.Text = "";
                txtBirth.Text = "";
                txtSeria.Text = "";
                txtNomer.Text = "";
                txtKodP.Text = "";
                txtKemVidan.Text = "";
                txtKogdaVidan.Text = "";
                
            }
            catch(FormatException)
            {
                MessageBox.Show("Вы неправильно ввели данные в поле");
            }


        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
            new Главное_меню__Менеджер_().ShowDialog();
            this.Close();
        }
    }
}
