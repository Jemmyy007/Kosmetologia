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
using static System.Net.Mime.MediaTypeNames;
using Microsoft.SqlServer.Server;
using Реворк;
using System.Windows.Navigation;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Косметология
{
    /// <summary>
    /// Логика взаимодействия для Оформление_заявки.xaml
    /// </summary>
    public partial class Оформление_заявки : Window
    {
       

        private SqlConnection myConnection;
        public static string connectString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True";  // Подключаем БД

        SqlConnection con;  // Задаем осн. команды для использования
        SqlCommand cmd, cmd2, cmd3;
        SqlDataReader dr, dr2, dr3;
        SqlDataAdapter da, da2, da3;

       

        /* con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True"); */

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            con.Open();

            try
            {

                string fioc = txtFio.Text;
                string fios = ComStuff.Text;
                string mail = txtMail.Text;
                string tel = txtTel.Text;
                double sto = Convert.ToDouble(txtPriceS.Text);
                string usl = ComPrice.Text;

                string query = $"INSERT INTO Заказы (ФИО, Телефон, Mail, Услуга, Специалист, Стоимость) VALUES (N'{fioc} ', " +
                    $" N' {tel} ', N'{mail} ', N'{usl} ', N'{fios} ', N'{sto} ')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Запись добавлена");


            }
            catch (FormatException)
            {
                MessageBox.Show("Цену услуги нужно ввести числом");
                
            }

           
        }

        public void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string price = txtPriceS.Text;
            string usl = ComPrice.Text;
            string fio = txtFio.Text;
            string date = Convert.ToString(DateP.Text);
            new Ваучер(fio, usl, price, date).ShowDialog();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            string kod = txtID.Text;
            (App.Current as App).Zakaz = kod;
            string client = txtFio.Text;
            string tel = txtTel.Text;
            string mail = txtMail.Text;
            string usluga = ComPrice.Text;
            string spec = ComStuff.Text;
            string price = txtPriceS.Text;
            new Отчет(client, tel, mail, usluga, spec, price).ShowDialog();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            con.Open();


            string quary = "SELECT Название FROM Услуги";
            cmd = new SqlCommand(quary, con);
            SqlDataReader dr = cmd.ExecuteReader(); //Считывает таблицу

            SqlDataAdapter da = new SqlDataAdapter(quary, con);

            DataTable dt = new DataTable(); //Создаем таблицу (виртуальную,  всне базы)
            da.Fill(dt); //Заполняет таблицу запросом из da

            while (dr.Read()) //Пробегается по всей таблице
            {

                ComPrice.Items.Add(dr[0].ToString()); //Создает елементы из таблицы, название элементов из "Название"

            }
            dr.Close();

            string quary2 = "SELECT ФИО FROM Stuff";
            cmd = new SqlCommand(quary2, con);
            SqlDataReader dr2 = cmd.ExecuteReader(); //Считывает таблицу

            SqlDataAdapter da2 = new SqlDataAdapter(quary2, con);

            DataTable dt2 = new DataTable(); //Создаем таблицу (виртуальную,  всне базы)
            da2.Fill(dt2); //Заполняет таблицу запросом из da

            while (dr2.Read()) //Пробегается по всей таблице
            {

                ComStuff.Items.Add(dr2[0].ToString()); //Создает елементы из таблицы, название элементов из "Название"

            }
            dr2.Close();


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
            ClientsGrid.ItemsSource = ds.Tables["Clients"].DefaultView;
            con.Close();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            try
            {
                con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True"); // Создаем подключение к БД для этой функции
                cmd = new SqlCommand(); // Создаем команду
                con.Open();

                int id = Convert.ToInt32(txtID.Text);
                string priceW = ComPrice.Text;
                string query4 = "SELECT Цена FROM Услуги WHERE Название =  N'" + priceW + "' ";
                cmd = new SqlCommand(query4, con);
                txtPriceW.Text = cmd.ExecuteScalar().ToString();


                string day = "SELECT [Дата рождения] FROM Clients WHERE Код = " + id;
                

                SqlCommand cmdDay = new SqlCommand(day, con);
               

                string dm = cmdDay.ExecuteScalar().ToString();
                

                DateTime DM = DateTime.Parse(dm);
               
                int D = DM.Day;
                int M = DM.Month;


                int TodayDay = DateTime.Now.Day;
                int TodayMonth = DateTime.Now.Month;


                int price = Convert.ToInt32(txtPriceW.Text);
                string itog = Convert.ToString(Convert.ToDouble(price - price * 0.15));

                if (D == TodayDay && M == TodayMonth)
                  {
                      txtSkidka.Text = "15%";
                      txtPriceS.Text = itog;
                  }
                  else
                  {
                      txtSkidka.Text = "-";
                      txtPriceS.Text = Convert.ToString(price);
                  };
                  /*      string query5 = "SELECT [Дата рождения] FROM Clients WHERE Код = " + id;
                          cmd = new SqlCommand(query5, con);
                          string date1 = cmd.ExecuteScalar().ToString();
                          DateTime dateTime = DateTime.Parse(date1);
                          DateTime date2 = DateTime.Today;

                          int a = Convert.ToInt32(date2.Year - dateTime.Year);
                          int price = Convert.ToInt32(txtPriceW.Text);
                          string itog = Convert.ToString(Convert.ToDouble(price - price * 0.15));

                          if (a >= 30)
                          {
                              txtSkidka.Text = "15%";
                              txtPriceS.Text = itog;
                          }
                          else
                          {
                              txtSkidka.Text = "-";
                              txtPriceS.Text = Convert.ToString(price);
                          };
                  */
            }

            catch (FormatException)
            {
                int id = Convert.ToInt32(txtID.Text);
                con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True"); // Создаем подключение к БД для этой функции
                cmd = new SqlCommand(); // Создаем команду
                con.Open();
                string query5 = "SELECT [Дата рождения] FROM Clients WHERE Код = " + id;
                cmd = new SqlCommand(query5, con);
                string date1 = cmd.ExecuteScalar().ToString();

                MessageBox.Show($"Дата рождения выбранного клиента была введена некоректно\n Дата рождения клиента:( {date1} d)");

            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            con.Close();
        }

        private void txtID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            new Главное_меню__Менеджер_().ShowDialog();
            this.Close();
        }

        private void ComPrice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        DataSet ds;

        public Оформление_заявки()
        {
            InitializeComponent();
          
            ComPrice.SelectedIndex= 0;
            ComStuff.SelectedIndex= 0;
            DateP.DisplayDateStart= DateTime.Now;
            DateP.Text = DateTime.Today.ToString();
          
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True"); // Создаем подключение к БД для этой функции
            cmd = new SqlCommand(); // Создаем команду
            con.Open(); // Открываем соединение с базой


           

            da = new SqlDataAdapter("select * from Clients", con); // Представляет набор команд данных и подключение к базе данных, которые используются для заполнения DataSet и обновления источника данных.
            ds = new DataSet();
            da.Fill(ds, "Clients");

            ClientsGrid.ItemsSource = ds.Tables["Clients"].DefaultView; // Заполнение грида нужной базой
            con.Close();


            myConnection = new SqlConnection(connectString);


            con.Open();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtID.Text);
                con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True");
                string query = "SELECT * FROM Clients where Код = " + id;
                SqlDataAdapter ad = new SqlDataAdapter(query, con);
                DataTable dtbl = new DataTable();
                ad.Fill(dtbl);
                if (dtbl.Rows.Count == 1)
                {

                    con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True"); // Создаем подключение к БД для этой функции
                    cmd = new SqlCommand(); // Создаем команду
                    con.Open();



                    string query5 = "SELECT ФИО FROM Clients WHERE Код = " + id;
                    cmd = new SqlCommand(query5, con);
                    txtFio.Text = cmd.ExecuteScalar().ToString();

                    string query2 = "SELECT Телефон FROM Clients WHERE Код = " + id;
                    cmd = new SqlCommand(query2, con);
                    txtTel.Text = cmd.ExecuteScalar().ToString();

                    string query3 = "SELECT Mail FROM Clients WHERE Код = " + id;
                    cmd = new SqlCommand(query3, con);
                    txtMail.Text = cmd.ExecuteScalar().ToString();

                }
                else
                {
                    MessageBox.Show("Такого клиента не существует");
                }
                con.Close();

               
            }



            catch (FormatException)
            {
                MessageBox.Show("Вы введи не все данные или некоторые данные введены некорректно");
            }

            con.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Главное_меню__Менеджер_().ShowDialog();
            this.Close();

        }

        private void Window_Activated(object sender, EventArgs e)
        {
           
          
            
            /*  for (int i = 0; i < list1.Items.Count; i++) 
            {
                RadioButton r = new RadioButton();
                list1.Items[i] = r;
                r.Content = dt.Rows[i][0] + " " + dt.Rows[i][1] + " р.";

                
            }

            */
        //----------------------------------------------------------------------------------------------------------------------------------------------------------





        //----------------------------------------------------------------------------------------------------------------------------------------------------------

        /*
        string quary3 = "SELECT ФИО, Опыт FROM stuff";
        SqlCommand cmd3 = new SqlCommand(quary3, con);
        SqlDataReader dr3 = cmd3.ExecuteReader(); //Считывает таблицу

        SqlDataAdapter da3 = new SqlDataAdapter(quary3, con);

        DataTable dt3 = new DataTable(); //Создаем таблицу (виртуальную,  всне базы)
        da3.Fill(dt3); //Заполняет таблицу запросом из da



        while (dr3.Read()) //Пробегается по всей таблице
        {

            listStuff.Items.Add(dr3["ФИО"].ToString()); //Создает елементы из таблицы, название элементов из "Название"

        }

        for (int i = 0; i < listStuff.Items.Count; i++)
        {
            RadioButton r3 = new RadioButton();
            listStuff.Items[i] = r3;
            r3.Content = dt3.Rows[i][0] + ", Стаж - " + dt3.Rows[i][1];


        }

        con.Close();

        */

    }


}
}
