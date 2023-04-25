using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Косметология
{
    /// <summary>
    /// Логика взаимодействия для Отчет_Ваучер.xaml
    /// </summary>
    public partial class Отчет_Ваучер : Window
    {
        SqlConnection con;  // Задаем осн. команды для использования
        SqlCommand cmd, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataSet ds;

        public Отчет_Ваучер()
        {
            InitializeComponent();

            txtNom.MaxLength = 9;

            txtDate.SelectedDate = DateTime.Now;
            txtDate.DisplayDateEnd = DateTime.Now;

            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True"); // Создаем подключение к БД для этой функции
            cmd = new SqlCommand(); // Создаем команду
            con.Open(); // Открываем соединение с базой

            da = new SqlDataAdapter("select Код AS [Номер заказа], ФИО, Телефон, Mail, Услуга, Специалист, Стоимость, convert(varchar(255), Дата, 104) AS Дата, Начало, Конец from Заказы", con); // Представляет набор команд данных и подключение к базе данных, которые используются для заполнения DataSet и обновления источника данных.
            ds = new DataSet();
            da.Fill(ds, "Заказы");

            GridBuys.ItemsSource = ds.Tables["Заказы"].DefaultView; // Заполнение грида нужной базой
            con.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True"); // Создаем подключение к БД для этой функции
            cmd = new SqlCommand(); // Создаем команду
            con.Open();

            string searh = txtSearch.Text;
            string queary = "select Код AS [Номер заказа], ФИО, Телефон, Mail, Услуга, Специалист, Стоимость, convert(varchar(255), Дата, 104) AS Дата, Начало, Конец from Заказы WHERE " +
                " ФИО LIKE N'%" + searh + "%'";
            SqlDataAdapter com = new SqlDataAdapter(queary, con);
            DataSet ds = new DataSet();
            com.Fill(ds, "Заказы");
            GridBuys.ItemsSource = ds.Tables["Заказы"].DefaultView;
            con.Close();
        }

        private void txtNom_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void txtNom_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string date = txtDate.Text;
            string nom = txtNom.Text;
            new ОТЧЕТ_ДЕНЬ_(nom, date).ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Главное_меню__Менеджер_().ShowDialog();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            con.Open();
            string nom2 = txtNom.Text;
            string date = txtDate.Text;
            try
            {
                int nom = Convert.ToInt32(txtNom.Text);

                string quary = "SELECT Код FROM Заказы WHERE Код = " + nom;
                da = new SqlDataAdapter(quary, con);
                DataTable dt = new DataTable();
                da.Fill(dt);




                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Такого номера не существует");
                    txtNom.Text = "";

                }

                else
                {
                    new Отчет2(nom, date).ShowDialog();
                }
                con.Close();

                
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите номер");
            }


            
        }

            private void Button_Click_4(object sender, RoutedEventArgs e)
            {
            string date = txtDate.Text;
            string nom = txtNom.Text;
            new ОТЧЕТ_МЕСЯЦ_(nom, date).ShowDialog();
            }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            string date = txtDate.Text;
            string nom = txtNom.Text;
            new ОТЧЕТ_ГОД_(nom, date).ShowDialog();
        }
    }
}
