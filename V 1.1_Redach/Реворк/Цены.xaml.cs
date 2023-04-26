using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Косметология
{
    /// <summary>
    /// Логика взаимодействия для Цены.xaml
    /// </summary>
    public partial class Цены : Window

    {

        private SqlConnection myConnection;
        public static string connectString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True";  // Подключаем БД

        SqlCommand cmd2;
        SqlConnection con;  // Задаем осн. команды для использования
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataSet ds;

        public Цены()
        {
            InitializeComponent();

            ComboBox();
            TextDel.MaxLength = 9;
            txtTimeAdd.MaxLength = 5;
            txtTimeUpdate.MaxLength = 5;
            txtPrice.MaxLength = 6;
            txtRedPrice.MaxLength = 6;

            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True"); // Создаем подключение к БД для этой функции
            cmd = new SqlCommand(); // Создаем команду
            con.Open(); // Открываем соединение с базой

            da = new SqlDataAdapter("select * from Услуги", con); // Представляет набор команд данных и подключение к базе данных, которые используются для заполнения DataSet и обновления источника данных.
            ds = new DataSet();
            da.Fill(ds, "Услуги");

            priceGrid.ItemsSource = ds.Tables["Услуги"].DefaultView; // Заполнение грида нужной базой
            con.Close();


            myConnection = new SqlConnection(connectString);


            myConnection.Open();


        }

        private void ComboBox()
        {
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            con.Open();

            com1.Items.Clear(); 
            com2.Items.Clear();

            string quaryFIO = $"SELECT DISTINCT Специальность FROM Услуги";
            cmd2 = new SqlCommand(quaryFIO, con);
            SqlDataReader dr = cmd2.ExecuteReader(); //Считывает таблицу

            while (dr.Read()) //Пробегается по всей таблице
            {

                com1.Items.Add(dr[0].ToString()); //Создает елементы из таблицы, название элементов из "Название"
                com2.Items.Add(dr[0].ToString());
            }
            
            dr.Close();

            
        }


        private void Добавить_Click(object sender, RoutedEventArgs e)  // Внесение данных в таблицу
        {
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            con.Open();

            try
            {

                string name = txtService.Text;
                int price = Convert.ToInt32(txtPrice.Text);
                string napr = txtNapr.Text;
                try
                {
                    double time2 = Convert.ToDouble(txtTimeAdd.Text);
                    
                }
                catch (FormatException)
                {
                    MessageBox.Show("Вы неправильно ввели время");
                    txtTimeAdd.Text = "";
                    return;
                }
                double time = Convert.ToDouble(txtTimeAdd.Text);

                if (name == "" || price == 0 || napr == "" || time == 0)
                {
                    MessageBox.Show("Вы не ввели данные");
                }
                else
                {
                    string query = $"INSERT INTO Услуги (Название, Цена, Специальность, [Время (ч)]) VALUES (N'{name} ', " +
                        $"' {price} ', N'{napr}', {time})";
                    SqlCommand cmd = new SqlCommand(query, myConnection);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Запись добавлена");

                    da = new SqlDataAdapter("select * from Услуги", con);
                    ds = new DataSet();
                    da.Fill(ds, "Услуги");
                    priceGrid.ItemsSource = ds.Tables["Услуги"].DefaultView;

                    txtTimeAdd.Text = "";
                    txtNapr.Text = "";
                    txtService.Text = "";
                    txtPrice.Text = "";
                    ComboBox();

                    con.Close();
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Цену услуги нужно ввести числом");
                txtPrice.Text = "";
            }

            txtPrice.Text = "";
            txtService.Text = "";


        }

        private void Button_Click(object sender, RoutedEventArgs e)  // Удаление данных
        {
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            con.Open();

            try
            {

                int kod = Convert.ToInt32(TextDel.Text);
                string query = "DELETE FROM Услуги WHERE [ID Услуги] = " + kod;
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Получилось");

                da = new SqlDataAdapter("select * from Услуги", con);
                ds = new DataSet();
                da.Fill(ds, "Услуги");
                priceGrid.ItemsSource = ds.Tables["Услуги"].DefaultView;

                con.Close();

            }

            catch (FormatException)
            {
                MessageBox.Show("Введите только номер (цифрой)");
            }
            txtRedName.Text = "";
            txtRedPrice.Text = "";
            txtUpdateNapr.Text = "";
            com2.SelectedIndex = -1;
            txtTimeUpdate.Text = "";
            TextDel.Text = "";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            con.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)  // Изменение данных
        {
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            con.Open();

            try
            {
                int kod = Convert.ToInt32(TextDel.Text);
                string name = txtRedName.Text;
                int price = Convert.ToInt32(txtRedPrice.Text);
                string nupr = txtUpdateNapr.Text;
                try
                {
                    double time2 = Convert.ToDouble(txtTimeUpdate.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Вы неправильно ввели время");
                    txtTimeAdd.Text = "";
                    return;
                }
                double time = Convert.ToDouble(txtTimeUpdate.Text);

                string query = "UPDATE Услуги SET Название = N'" + name + "', Цена = '" + price + "', Специальность = N'" + nupr + "', [Время (ч)] = '"+ time +"' WHERE [ID Услуги] = " + kod;
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Получилось");

                da = new SqlDataAdapter("select * from Услуги", con);
                ds = new DataSet();
                da.Fill(ds, "Услуги");
                priceGrid.ItemsSource = ds.Tables["Услуги"].DefaultView;
                ComboBox();
                con.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("В \"Изменение цены\" и \"Выбор кода записи\" нужно ввести числа");
            }

            TextDel.Text = "";
            txtRedName.Text = "";
            txtRedPrice.Text = "";
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void TextDel_TextChanged(object sender, TextChangedEventArgs e)
        {
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            con.Open();
            try
            {
                int kod = Convert.ToInt32(TextDel.Text);

                string select = $"SELECT * FROM Услуги WHERE [ID Услуги] = {kod}";
                da = new SqlDataAdapter(select, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 1)
                {


                    txtRedName.Text = dt.Rows[0][1].ToString();
                    txtRedPrice.Text = dt.Rows[0][3].ToString();
                    txtUpdateNapr.Text = dt.Rows[0][3].ToString();
                    com2.Text = dt.Rows[0][3].ToString();
                    txtTimeUpdate.Text = dt.Rows[0][4].ToString();
                }
                else
                {
                    txtRedName.Text = "";
                    txtRedPrice.Text = "";
                    txtUpdateNapr.Text = "";
                    com2.SelectedIndex = -1;
                    txtTimeUpdate.Text = "";
                }

            }
            catch (FormatException)
            {
                txtRedName.Text = "";
                txtRedPrice.Text = "";
                txtUpdateNapr.Text = "";
                com2.SelectedIndex = -1;
                txtTimeUpdate.Text = "";
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Главное_меню__Админ_().ShowDialog();
            this.Close();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            new Главное_меню__Админ_().ShowDialog();
            this.Close();

        }

        private void TextDel_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void txtTimeAdd_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0) && e.Text != ",")
            {
                e.Handled = true;
                return;
            }

            // Проверяем, что запятая не в начале
            var textBox = sender as TextBox;
            if (textBox != null && textBox.Text.Length == 0 && e.Text == ",")
            {
                e.Handled = true;
                return;
            }

            // Проверяем, что запятая не повторяется
            if (e.Text == "," && textBox.Text.Contains(","))
            {
                e.Handled = true;
                return;
            }

            // Проверяем, что запятая не стоит в конце
            if (e.Text == "," && textBox.Text.Length > 0 && textBox.Text.LastIndexOf(',') == textBox.Text.Length - 1)
            {
                e.Handled = true;
                return;
            }
        }

        private void txtTimeUpdate_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0) && e.Text != ",")
            {
                e.Handled = true;
                return;
            }

            // Проверяем, что запятая не в начале
            var textBox = sender as TextBox;
            if (textBox != null && textBox.Text.Length == 0 && e.Text == ",")
            {
                e.Handled = true;
                return;
            }

            // Проверяем, что запятая не повторяется
            if (e.Text == "," && textBox.Text.Contains(","))
            {
                e.Handled = true;
                return;
            }

            // Проверяем, что запятая не стоит в конце
            if (e.Text == "," && textBox.Text.Length > 0 && textBox.Text.LastIndexOf(',') == textBox.Text.Length - 1)
            {
                e.Handled = true;
                return;
            }
        }

        private void com1_DropDownClosed(object sender, EventArgs e)
        {
            txtNapr.Text = com1.Text;
        }

        private void com2_DropDownClosed(object sender, EventArgs e)
        {
            txtUpdateNapr.Text = com2.Text;
        }

        private void txtPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void txtRedPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
