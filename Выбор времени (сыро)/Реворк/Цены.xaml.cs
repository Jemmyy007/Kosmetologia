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

            TextDel.MaxLength = 9;

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



        private void Добавить_Click(object sender, RoutedEventArgs e)  // Внесение данных в таблицу
        {
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            con.Open();

            try
            {

                string name = txtService.Text;
                int price = Convert.ToInt32(txtPrice.Text);
                string napr = txtNapr.Text;

                if (name == "" || price == 0 || napr == "")
                {
                    MessageBox.Show("Вы не ввели данные");
                }
                else
                {
                    string query = $"INSERT INTO Услуги (Название, Цена, Специальность) VALUES (N'{name} ', " +
                        $"' {price} ', N'{napr}')";
                    SqlCommand cmd = new SqlCommand(query, myConnection);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Запись добавлена");

                    da = new SqlDataAdapter("select * from Услуги", con);
                    ds = new DataSet();
                    da.Fill(ds, "Услуги");
                    priceGrid.ItemsSource = ds.Tables["Услуги"].DefaultView;

                    txtService.Text = "";
                    txtPrice.Text = "";

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

                string query = "UPDATE Услуги SET Название = N'" + name + "', Цена = N'" + price + "', Специальность = N'" + nupr + "' WHERE [ID Услуги] = " + kod;
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
    }
}
