using System;
using System.Collections.Generic;
using System.Data.Common;
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
    /// Логика взаимодействия для Редактирование_клиентов.xaml
    /// </summary>
    public partial class Редактирование_клиентов : Window
    {

        private SqlConnection myConnection;
        public static string connectString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True";  // Подключаем БД

        SqlConnection con;  // Задаем осн. команды для использования
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataSet ds; 

        public Редактирование_клиентов()
        {
            InitializeComponent();

            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True"); // Создаем подключение к БД для этой функции
            cmd = new SqlCommand(); // Создаем команду
            con.Open(); // Открываем соединение с базой

            da = new SqlDataAdapter("select * from Clients", con); // Представляет набор команд данных и подключение к базе данных, которые используются для заполнения DataSet и обновления источника данных.
            ds = new DataSet();
            da.Fill(ds, "Clients");

            clientDB.ItemsSource = ds.Tables["Clients"].DefaultView; // Заполнение грида нужной базой
            con.Close();


            myConnection = new SqlConnection(connectString);


            myConnection.Open();

        }

      

      

        private void ButUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void changeBut_Click(object sender, RoutedEventArgs e)
        {
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            con.Open();

            

            try
            {
                string kod = txtID.Text;
                string fio = txtFio.Text;
                string phone = txtTel.Text;
                string mail = txtMail.Text;
                string birth = txtBirth.Text;
                string seria = txtSeria.Text;
                string nomer = txtNomer.Text;
                string kodP = txtKodP.Text;
                string kemVid = txtKemVidan.Text;
                string kogdaVid = txtKogdaVidan.Text;
            
                string query = "UPDATE Clients SET ФИО = N'"+ fio + "', Телефон = N'"+ phone + "', Mail = N'"+ mail + "', [Дата рождения] = N'"+ birth + "', [Серия паспорта] = N'"+ seria + "', [Номер паспорта] = N'"+ nomer + "', [Код подразделения] = N'"+ kodP + "', [Кем выдан] = N'"+ kemVid +"', [Дата выдачи] = N'"+ kogdaVid+"' WHERE [Код] = " + kod;
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Получилось");

                da = new SqlDataAdapter("select * from Clients", con);
                ds = new DataSet();
                da.Fill(ds, "Clients");
                clientDB.ItemsSource = ds.Tables["Clients"].DefaultView;

                con.Close();

                txtID.Text = "";
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
            catch (FormatException)
            {
                MessageBox.Show("Ошибка, проверьте введенные данные");
            }

           
            

        }
    

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            new Главное_меню__Менеджер_().ShowDialog();
            
        }

       

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True"); // Создаем подключение к БД для этой функции
            cmd = new SqlCommand(); // Создаем команду
            con.Open();

            string query = "SELECT ФИО FROM Clients WHERE Код = " + id;
            cmd = new SqlCommand(query, con);
            txtFio.Text = cmd.ExecuteScalar().ToString();

            string query2 = "SELECT Телефон FROM Clients WHERE Код = " + id;
            cmd = new SqlCommand(query2, con);
            txtTel.Text = cmd.ExecuteScalar().ToString();

            string query3 = "SELECT Mail FROM Clients WHERE Код = " + id;
            cmd = new SqlCommand(query3, con);
            txtMail.Text = cmd.ExecuteScalar().ToString();

            string query4 = "SELECT [Дата рождения] FROM Clients WHERE Код = " + id;
            cmd = new SqlCommand(query4, con);
            txtBirth.Text = cmd.ExecuteScalar().ToString();

            string query5 = "SELECT [Серия паспорта] FROM Clients WHERE Код = " + id;
            cmd = new SqlCommand(query5, con);
            txtSeria.Text = cmd.ExecuteScalar().ToString();

            string query6 = "SELECT [Номер паспорта] FROM Clients WHERE Код = " + id;
            cmd = new SqlCommand(query6, con);
            txtNomer.Text = cmd.ExecuteScalar().ToString();

            string query7 = "SELECT [Код подразделения] FROM Clients WHERE Код = " + id;
            cmd = new SqlCommand(query7, con);
            txtKodP.Text = cmd.ExecuteScalar().ToString();

            string query8 = "SELECT [Кем выдан] FROM Clients WHERE Код = " + id;
            cmd = new SqlCommand(query8, con);
            txtKemVidan.Text = cmd.ExecuteScalar().ToString();

            string query9 = "SELECT [Дата выдачи] FROM Clients WHERE Код = " + id;
            cmd = new SqlCommand(query9, con);
            txtKogdaVidan.Text = cmd.ExecuteScalar().ToString();


        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True"); // Создаем подключение к БД для этой функции
            cmd = new SqlCommand(); // Создаем команду
            con.Open();

            string searh = txtSearch.Text;
            string queary = "SELECT Код, ФИО, Телефон, Mail, [Дата рождения], [Серия паспорта], [Номер паспорта], [Код подразделения], [Кем выдан], [Дата выдачи] FROM Clients WHERE " +
                " ФИО LIKE N'%" + searh + "%'";
            SqlDataAdapter com = new SqlDataAdapter(queary, con);
            DataSet ds = new DataSet();
            com.Fill(ds, "Clients");
            clientDB.ItemsSource = ds.Tables["Clients"].DefaultView;
            con.Close();
        }

        private void txtID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            new Главное_меню__Менеджер_().ShowDialog();
            this.Close();
        }








        /* con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True"); // Создаем подключение к БД для этой функции
        cmd = new SqlCommand(); // Создаем команду
        con.Open(); //создаем подключение к базе

            SqlCommand aCommand = new SqlCommand("select * from Clients", con); //создаем SQL запрос (команду)
         try
         {
             con.Open(); //открываем соединение

             SqlDataReader aReader = aCommand.ExecuteReader(); //создаем DataReader и присваиваем к нему результаты нашего SQL запроса

             while (aReader.Read()) //пока наши результаты читаются, читаем их
             {
                 Console.WriteLine(aReader.GetInt32(0).ToString()); //получаем значение из первого поля типа Int32
                 Console.WriteLine(aReader.GetString(0)); //получаем значение из второго поля типа String
             }

             aReader.Close(); //после выполнения запроса закрываем "читателя базы"
             con.Close(); //закрываем соединение с базой. Это важно!
         }
         catch (OleDbException) //если произошла ошибка, то выводим её
         {
             MessageBox.Show("PuP");

         }
        */





    }
}
