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
using System.Windows.Controls.Primitives;
using System.Globalization;
using System.Security.Policy;

namespace Косметология
{
    /// <summary>
    /// Логика взаимодействия для Редактировать_заказ.xaml
    /// </summary>
    public partial class Редактировать_заказ : Window
    {
        private SqlConnection myConnection;
        public static string connectString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True";  // Подключаем БД
        
        SqlConnection con;  // Задаем осн. команды для использования
        SqlCommand cmd, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataSet ds;
        private void ComStuffM()
        {
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

            ComStuff.SelectedIndex = 0;
        }
        private void Combo()
        {
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True"); // Создаем подключение к БД для этой функции
            cmd = new SqlCommand(); // Создаем команду
            con.Open();
            string quaryFIO = $"SELECT ФИО FROM stuff";
            cmd2 = new SqlCommand(quaryFIO, con);
            SqlDataReader dr = cmd2.ExecuteReader(); //Считывает таблицу

            while (dr.Read()) //Пробегается по всей таблице
            {

                ComStuff.Items.Add(dr[0].ToString()); //Создает елементы из таблицы, название элементов из "Название"

            }
            dr.Close();

            ComStuff.SelectedIndex = -1;
        }
        public Редактировать_заказ()
        {
            InitializeComponent();
            txtTimeE.MaxLength = 5;
            txtTimeS.MaxLength = 5;
            ComboSpec();
            txtKod.MaxLength = 9;
            ComStuff.SelectedIndex = 0;

            txtDate.DisplayDateStart = DateTime.Now;
            txtDate.SelectedDate = DateTime.Now;

            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True"); // Создаем подключение к БД для этой функции
            cmd = new SqlCommand(); // Создаем команду
            con.Open(); // Открываем соединение с базой

            da = new SqlDataAdapter("select Код, ФИО, Телефон, Mail, Услуга, Специалист, Стоимость, convert(varchar(255), Дата, 104) AS Дата, Начало, Конец from Заказы", con); // Представляет набор команд данных и подключение к базе данных, которые используются для заполнения DataSet и обновления источника данных.
            ds = new DataSet();
            da.Fill(ds, "Заказы");

            GridBuys.ItemsSource = ds.Tables["Заказы"].DefaultView; // Заполнение грида нужной базой
            con.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Главное_меню__Менеджер_().ShowDialog();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            

            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            con.Open();

            try
            {
                string startTime = txtTimeS.Text;
                string endTime = txtTimeE.Text;
                string specialist = ComStuff.Text;
                int kod = Convert.ToInt32(txtKod.Text);
                string fioc = txtFIOc.Text;
                string fios = ComStuff.Text;
                string mail = txtMail.Text;
                string tel = txtTel.Text;
                int sto = Convert.ToInt32(txtStoimost.Text);
                string usl = ComPrice.Text;
                string date = txtDate.Text;

                // Вычисляем конечное время заказа
                string time = $"SELECT [Время (ч)] FROM Услуги WHERE Название = N'{usl}'";
                SqlCommand cmdP = new SqlCommand(time, con);
                double uslugaTime = Convert.ToDouble(cmdP.ExecuteScalar());

                DateTime EndTime;
                if (DateTime.TryParseExact(startTime, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out var startTimeParsed))
                {
                    EndTime = startTimeParsed.AddHours(uslugaTime);
                    txtTimeE.Text = EndTime.ToShortTimeString();
                }
                else
                {
                    MessageBox.Show("Вы ввели неправильное время!");
                    return;
                }
                


                string query = "UPDATE Заказы SET ФИО = N'" + fioc + "', Телефон = N'" + tel + "', Mail = N'" + mail + "'," +
                    " Услуга = N'" + usl + "', Специалист = N'" + fios + "', Стоимость = N'" + sto + "', Дата = CONVERT(date, '"+ date +"', 104), Начало = '"+startTime+"', Конец = '"+endTime+"' WHERE [Код] = " + kod;
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Получилось");

                da = new SqlDataAdapter("select Код, ФИО, Телефон, Mail, Услуга, Специалист, Стоимость, convert(varchar(255), Дата, 104) AS Дата, Начало, Конец from Заказы", con);
                ds = new DataSet();
                da.Fill(ds, "Заказы");
                GridBuys.ItemsSource = ds.Tables["Заказы"].DefaultView;

                con.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("В \"Изменение цены\" и \"Выбор кода записи\" нужно ввести числа");
            }

           
        }

       

        

        

        private void txtKod_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtKod.Text);
                con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True"); // Создаем подключение к БД для этой функции
                cmd = new SqlCommand(); // Создаем команду
                con.Open();
                string queryy = "SELECT * FROM Заказы where Код = " + id;
                SqlDataAdapter ad = new SqlDataAdapter(queryy, con);
                DataTable dtbl = new DataTable();
                ad.Fill(dtbl);
                if (dtbl.Rows.Count == 1)
                {
                    string qTimeS = "SELECT Начало FROM Заказы WHERE Код = " + id;
                    SqlDataAdapter da = new SqlDataAdapter(qTimeS, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        
                        SqlCommand cmdS = new SqlCommand(qTimeS, con);
                        string times = cmdS.ExecuteScalar().ToString();
                        if (times.Length > 5)
                        {
                            txtTimeS.Text = times.Remove(times.Length - 3);
                        }
                        else
                        {
                            txtTimeS.Text = "";
                        }
                    }

                    string qTimeE = "SELECT Конец FROM Заказы WHERE Код = " + id;
                    SqlDataAdapter da2 = new SqlDataAdapter(qTimeE, con);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    da.Fill(dt);
                    if (dt2.Rows.Count > 0)
                    {
                        SqlCommand cmdE = new SqlCommand(qTimeE, con);
                        string timee = cmdE.ExecuteScalar().ToString();
                        if (timee.Length > 5)
                        {
                            txtTimeE.Text = timee.Remove(timee.Length - 3);
                        }
                        else
                        {
                            txtTimeE.Text = "";
                        }
                    }


                    string query = "SELECT ФИО FROM Заказы WHERE Код = " + id;
                    cmd = new SqlCommand(query, con);
                    txtFIOc.Text = cmd.ExecuteScalar().ToString();

                    string query2 = "SELECT Телефон FROM Заказы WHERE Код = " + id;
                    cmd2 = new SqlCommand(query2, con);
                    txtTel.Text = cmd2.ExecuteScalar().ToString();

                    string query3 = "SELECT Mail FROM Заказы WHERE Код = " + id;
                    cmd3 = new SqlCommand(query3, con);
                    txtMail.Text = cmd3.ExecuteScalar().ToString();

                    string query6 = "SELECT Стоимость FROM Заказы WHERE Код = " + id;
                    cmd6 = new SqlCommand(query6, con);
                    txtStoimost.Text = cmd6.ExecuteScalar().ToString();

                    string query4 = "SELECT Специалист FROM Заказы WHERE Код = " + id;
                    cmd4 = new SqlCommand(query4, con);
                    string a = cmd4.ExecuteScalar().ToString();
                    ComStuff.Text = a;

                   
                    

                }
                else
                {
                    txtFIOc.Text = "";
                    txtTel.Text = "";
                    txtMail.Text = "";
                    txtStoimost.Text = "";
                    ComStuff.SelectedIndex = -1;
                    ComPrice.SelectedIndex = -1;
                }
            }
            catch (FormatException)
            {
                txtFIOc.Text = "";
                txtTel.Text = "";
                txtMail.Text = "";
                txtStoimost.Text = "";
                ComStuff.SelectedIndex = -1;
                ComPrice.SelectedIndex = -1;
            }
        }
        private void ComboSpec()
        {
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True"); // Создаем подключение к БД для этой функции
            cmd = new SqlCommand(); // Создаем команду
            con.Open();
            try
            {
                int id = Convert.ToInt32(txtKod.Text);
                string fioc = ComStuff.Text;
                string quarySpec = $"Select Специальность FROM stuff WHERE ФИО = N'{fioc}'";
                /*SqlCommand cmdSpec = new SqlCommand(quarySpec, con);
                string spec =cmdSpec.ExecuteScalar().ToString();*/
                SqlDataAdapter da = new SqlDataAdapter(quarySpec, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    string spec = dt.Rows[0][0].ToString();
                    string query5 = $"SELECT Название FROM Услуги WHERE Специальность = N'{spec}'";
                    cmd5 = new SqlCommand(query5, con);
                    SqlDataReader dr = cmd5.ExecuteReader();
                    ComPrice.Items.Clear();
                    while (dr.Read())
                    {
                        ComPrice.Items.Add(dr[0].ToString());
                    }

                    string query7 = "SELECT Услуга FROM Заказы WHERE Код = " + id;
                    cmd7 = new SqlCommand(query7, con);
                    string g = cmd7.ExecuteScalar().ToString();
                    ComPrice.Text = g;

                }
            }
            catch
            {
                string fioc = ComStuff.Text;
                string quarySpec = $"Select Специальность FROM stuff WHERE ФИО = N'{fioc}'";
                /*SqlCommand cmdSpec = new SqlCommand(quarySpec, con);
                string spec =cmdSpec.ExecuteScalar().ToString();*/
                SqlDataAdapter da = new SqlDataAdapter(quarySpec, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    string spec = dt.Rows[0][0].ToString();
                    string query5 = $"SELECT Название FROM Услуги WHERE Специальность = N'{spec}'";
                    cmd5 = new SqlCommand(query5, con);
                    SqlDataReader dr = cmd5.ExecuteReader();
                    ComPrice.Items.Clear();
                    while (dr.Read())
                    {
                        ComPrice.Items.Add(dr[0].ToString());
                    }

                    
                }
            }
            }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            con.Open();

            try
            {

                int kod = Convert.ToInt32(txtKod.Text);
                string query = "DELETE FROM Заказы WHERE [Код] = " + kod;
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Получилось");

                da = new SqlDataAdapter("select Код, ФИО, Телефон, Mail, Услуга, Специалист, Стоимость, convert(varchar(255), Дата, 104) AS Дата from Заказы", con); // Представляет набор команд данных и подключение к базе данных, которые используются для заполнения DataSet и обновления источника данных.
                ds = new DataSet();
                da.Fill(ds, "Заказы");

                GridBuys.ItemsSource = ds.Tables["Заказы"].DefaultView; // Заполнение грида нужной базой
                con.Close();

            }

            catch (FormatException)
            {
                MessageBox.Show("Введите только номер (цифрой)");
            }

            txtKod.Text = "";
        }

        private void txtKod_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void ComStuff_DropDownClosed(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True"); // Создаем подключение к БД для этой функции
            cmd = new SqlCommand(); // Создаем команду
            con.Open();
            string fioc = ComStuff.Text;
            string quarySpec = $"Select Специальность FROM stuff WHERE ФИО = N'{fioc}'";
            SqlDataAdapter da = new SqlDataAdapter(quarySpec, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string spec = dt.Rows[0][0].ToString();
                string query5 = $"SELECT Название FROM Услуги WHERE Специальность = N'{spec}'";
                cmd5 = new SqlCommand(query5, con);
                SqlDataReader dr = cmd5.ExecuteReader();
                ComPrice.Items.Clear();
                while (dr.Read())
                {
                    ComPrice.Items.Add(dr[0].ToString());
                }
                ComPrice.SelectedIndex = 0;
                con.Close();
            }
            else
            {
                ComPrice.SelectedIndex = -1;
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text[0]) && e.Text[0] != ':' && e.Text[0] != '\b' && e.Text == " ")
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

        private void TextBox_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text[0]) && e.Text[0] != ':' && e.Text[0] != '\b' && e.Text == " ")
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtTimeS.Text == "")
            {
                txtTimeE.Text = "";
            }
            string startTime = txtTimeS.Text;
            string endTime = txtTimeE.Text;
            string usl = ComPrice.Text;
            if (usl == "")
            {
                txtTimeE.Text = "";
            }
            else
            {
                string time = $"SELECT [Время (ч)] FROM Услуги WHERE Название = N'{usl}'";
                SqlCommand cmdP = new SqlCommand(time, con);
                try
                {
                    double uslugaTime2 = Convert.ToDouble(cmdP.ExecuteScalar());
                }
                catch (FormatException)
                {
                    txtTimeE.Text = "";
                }
                DateTime EndTime;
                double uslugaTime = Convert.ToDouble(cmdP.ExecuteScalar());
                if (DateTime.TryParseExact(startTime, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out var startTimeParsed))
                {
                    EndTime = startTimeParsed.AddHours(uslugaTime);
                    txtTimeE.Text = EndTime.ToShortTimeString();
                }
                else
                {
                    txtTimeE.Text = "";
                }
            }
        }

        private void ComPrice_DropDownClosed(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True"); // Создаем подключение к БД для этой функции
            cmd = new SqlCommand(); // Создаем команду
            con.Open();

            if (ComPrice.Text == "")
            {
                MessageBox.Show("Вы не выбрали услугу");
            }
            else
            {
                string priceW = ComPrice.Text;
                string query9 = "SELECT Цена FROM Услуги WHERE Название =  N'" + priceW + "' ";
                cmd7 = new SqlCommand(query9, con);
                txtStoimost.Text = cmd7.ExecuteScalar().ToString();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True"); // Создаем подключение к БД для этой функции
            cmd = new SqlCommand(); // Создаем команду
            con.Open();
            ComPrice.SelectedItem.ToString();
            string query6 = "SELECT Стоимость FROM Услуги WHERE Услуга = N'" + ComPrice.Text + "'";
            SqlCommand cmdd = new SqlCommand(query6, con);
            txtStoimost.Text = cmdd.ExecuteScalar().ToString();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True"); // Создаем подключение к БД для этой функции
            cmd = new SqlCommand(); // Создаем команду
            con.Open();

            string searh = txtSearch.Text;
            string queary = "select Код, ФИО, Телефон, Mail, Услуга, Специалист, Стоимость, convert(varchar(255), Дата, 104) AS Дата from Заказы WHERE " +
                " ФИО LIKE N'%" + searh + "%'";
            SqlDataAdapter com = new SqlDataAdapter(queary, con);
            DataSet ds = new DataSet();
            com.Fill(ds, "Заказы");
            GridBuys.ItemsSource = ds.Tables["Заказы"].DefaultView;
            con.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
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
        }

        private void txtStoimost1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComPrice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            con.Close();
        }

       
    }
    
    
}
