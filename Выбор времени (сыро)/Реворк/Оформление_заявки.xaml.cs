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
using System.Text.RegularExpressions;
using System.Globalization;

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
                string date = DateP.Text;
                string TimeS = txtTimeS.Text;
                string TimeE = txtTimeE.Text;



                string query = $"INSERT INTO Заказы (ФИО, Телефон, Mail, Услуга, Специалист, Стоимость, Дата, Начало, Конец) VALUES (N'{fioc} ', " +
                 $" N' {tel} ', N'{mail} ', N'{usl} ', N'{fios} ', N'{sto} ', CONVERT(date, '{date}', 104), '{TimeS}', '{TimeE}')";
                SqlCommand cmd = new SqlCommand(query, con);

                /*     string query = $"INSERT INTO Заказы (ФИО, Телефон, Mail, Услуга, Специалист, Стоимость, Дата) VALUES (N@ФИО, N@Телефон, N@Mail, N@Услуга, N@Специалист, @Стоимость, @Дата)";

                 cmd.Parameters.AddWithValue("@ФИО, txtFio.Text", txtFio.Text);
                 cmd.Parameters.AddWithValue("@Телефон", txtTel.Text);
                 cmd.Parameters.AddWithValue("@Mail",txtMail.Text);
                 cmd.Parameters.AddWithValue("@Услуга", ComPrice.Text);
                 cmd.Parameters.AddWithValue("@Специалист", ComStuff.Text);
                 cmd.Parameters.AddWithValue("@Стоимость", sto);
                 cmd.Parameters.AddWithValue("@Дата", DateP.SelectedDate); */


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
            string DATE = DateP.Text;
            new Отчет(client, tel, mail, usluga, spec, price, DATE).ShowDialog();
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

                string startTime = txtTimeS.Text;
                string specialist = ComStuff.Text;
                string Date = DateP.Text;

                // Вычисляем конечное время заказа
                string time = $"SELECT [Время (ч)] FROM Услуги WHERE Название = N'{priceW}'";
                SqlCommand cmdP = new SqlCommand(time, con);
                int uslugaTime = Convert.ToInt32(cmdP.ExecuteScalar());

                DateTime endTime;
                if (DateTime.TryParseExact(startTime, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out var startTimeParsed))
                {
                    endTime = startTimeParsed.AddHours(uslugaTime);
                    txtTimeE.Text = endTime.ToShortTimeString();
                }
                else
                {
                    MessageBox.Show("Вы ввели неправильное время!");
                    return;
                }

                string endTime2 = txtTimeE.Text;

                string SelectTime = $"SELECT COUNT(*) FROM Заказы WHERE Специалист = N'{specialist}' AND Дата = CONVERT(date, '{Date}', 104) AND " +
                    $"((CONVERT(time, '{startTime}') BETWEEN Начало AND Конец) OR (CONVERT(time, '{endTime2}') BETWEEN Начало AND Конец))";
                SqlCommand cmdSel = new SqlCommand(SelectTime, con);
                
               
                
                int col = Convert.ToInt32(cmdSel.ExecuteScalar());
                if (col == 0)
                {
                    MessageBox.Show("Свободно");
                }
                else
                {
                    MessageBox.Show(col.ToString());
                }



                /*string StartTime = txtTimeS.Text;
                string time = $"SELECT [Время (ч)] FROM Услуги WHERE Название = N'{priceW}'";
                SqlCommand cmdP = new SqlCommand(time, con);
                int UslugaTime = Convert.ToInt32(cmdP.ExecuteScalar());

                DateTime TIME;
                if (DateTime.TryParseExact(StartTime, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out TIME))
                {
                    TIME = TIME.AddHours(UslugaTime);
                    txtTimeE.Text = TIME.ToShortTimeString();
                    
                    // time теперь содержит дату и время из строки в формате ЧЧ:ММ
                    // можно использовать переменную time для дальнейших операций с датой и временем
                }
                else
                {
                    MessageBox.Show("Вы ввели неправильное время!");
                }
                string EndTime = txtTimeE.Text;
                string stuff = ComStuff.Text;
                

                string SelectTime = $"SELECT COUNT(*) FROM Заказы WHERE Специалист = '{stuff}' AND (('{StartTime}' BETWEEN Начало AND Конец) OR ('{EndTime}' BETWEEN Начало AND Конец) OR (Начало BETWEEN '{StartTime}' AND '{EndTime}'))";
                SqlCommand cmdSEL = new SqlCommand(SelectTime, con);
                if (Convert.ToInt32(cmdSEL.ExecuteScalar()) == 0) 
                {
                    
                    MessageBox.Show("Свободно");
                }
                else
                {
                    MessageBox.Show("Это время занято");
                } */


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

                MessageBox.Show($"Дата рождения выбранного клиента была введена некоректно\n Дата рождения клиента: {date1}");

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

        
        private void txtID_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void ComPrice_DropDownClosed(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True"); // Создаем подключение к БД для этой функции
            cmd = new SqlCommand(); // Создаем команду
            con.Open();
            ComStuff.Items.Clear();
            string usl = ComPrice.Text;
            string quary1 = $"SELECT Специальность FROM Услуги WHERE Название = N'{usl}'";


            cmd = new SqlCommand(quary1, con);
            string spec = cmd.ExecuteScalar().ToString();

            string quaryFIO = $"SELECT ФИО FROM stuff WHERE Специальность = N'{spec}'";
            cmd2 = new SqlCommand(quaryFIO, con);
            SqlDataReader dr = cmd2.ExecuteReader(); //Считывает таблицу

            while (dr.Read()) //Пробегается по всей таблице
            {

                ComStuff.Items.Add(dr[0].ToString()); //Создает елементы из таблицы, название элементов из "Название"

            }
            dr.Close();

            con.Close();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void txtTimeS_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text[0]) && e.Text[0] != ':' && e.Text[0] != '\b')
            {
                e.Handled = true;
                return;
            }

            var textBox = (TextBox)sender;

            if (textBox.Text.Length == 2 && e.Text[0] != ':' && !textBox.Text.Contains(":"))
            {
                textBox.Text += ":";
            }

            textBox.CaretIndex = textBox.Text.Length;
        }

        private void txtTimeE_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text[0]) && e.Text[0] != ':' && e.Text[0] != '\b')
            {
                e.Handled = true;
                return;
            }

            var textBox = (TextBox)sender;

            if (textBox.Text.Length == 2 && e.Text[0] != ':' && !textBox.Text.Contains(":"))
            {
                textBox.Text += ":";
            }

            textBox.CaretIndex = textBox.Text.Length;
        }

        private void txtTimeS_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        DataSet ds;


        public Оформление_заявки()
        {
            InitializeComponent();
            txtTimeS.MaxLength = 5;
            txtTimeE.MaxLength = 5;
            txtID.MaxLength = 9;

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
