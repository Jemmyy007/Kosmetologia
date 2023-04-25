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
    /// Логика взаимодействия для Специалисты.xaml
    /// </summary>
    public partial class Специалисты : Window
    {
        private SqlConnection myConnection;
        public static string connectString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True";

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataSet ds;


        public Специалисты()
        {
            InitializeComponent();

            ComboBox();

            txtKod.MaxLength = 9;
            txtSalary.SelectedIndex = 0;

            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            cmd = new SqlCommand();
            con.Open();

            da = new SqlDataAdapter("select * from stuff", con);
            ds = new DataSet();
            da.Fill(ds, "stuff");

            StuffGrid.ItemsSource = ds.Tables["stuff"].DefaultView;
            con.Close();


            myConnection = new SqlConnection(connectString);


            myConnection.Open();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            con.Open();

            try
            {

                int kod = Convert.ToInt32(txtKod.Text);

                string sel = $"SELECT COUNT(*) FROM stuff WHERE [Id] = {kod}";
                SqlCommand sqlCommand = new SqlCommand(sel, con);
                int col = Convert.ToInt32(sqlCommand.ExecuteScalar());

                if (col > 0)
                {

                    string query = "DELETE FROM stuff WHERE [Id] = " + kod;
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Получилось");

                    da = new SqlDataAdapter("select * from stuff", con);
                    ds = new DataSet();
                    da.Fill(ds, "stuff");
                    StuffGrid.ItemsSource = ds.Tables["stuff"].DefaultView;

                    con.Close();
                }
                else
                {
                    MessageBox.Show("Такого кода не найдено");
                }
            }

            catch (FormatException)
            {
                MessageBox.Show("Введите только номер (цифрой)");
            }

            txtKod.Text = "";
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Главное_меню__Админ_().ShowDialog();
            this.Close();
        }

        private void Выйти(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Главное_меню__Админ_().ShowDialog();
            this.Close();
        }

        private void ChangeBut_Click(object sender, RoutedEventArgs e)
        {
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            con.Open();

            try
            {
                int kod = Convert.ToInt32(txtKod.Text);
                string fio = txtRedFIO.Text;
                string exp = txtRedSalary.Text;

                string query = "UPDATE stuff SET ФИО = N'" + fio + "', Специальность = N'" + exp + "' WHERE [Id] = " + kod;
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Получилось");

                da = new SqlDataAdapter("select * from stuff", con);
                ds = new DataSet();
                da.Fill(ds, "stuff");
                StuffGrid.ItemsSource = ds.Tables["stuff"].DefaultView;

                con.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Меняй");
            }

            txtKod.Text = "";
            txtRedFIO.Text = "";
            txtRedSalary.Text = "";
            
        }

        private void AddBut_Click(object sender, RoutedEventArgs e)
        {
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            con.Open();

            try
            {


                string fio = txtFIO.Text;              
                string exp = txtSalary.Text;

                string query = $"INSERT INTO stuff (ФИО, Специальность) VALUES (N'{fio} ', N'{exp}')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Запись добавлена");

                da = new SqlDataAdapter("select * from stuff", con);
                ds = new DataSet();
                da.Fill(ds, "stuff");
                StuffGrid.ItemsSource = ds.Tables["stuff"].DefaultView;

                txtFIO.Text = "";
                txtSalary.SelectedIndex = 0;

                con.Close();

            }
            catch (FormatException)
            {
                MessageBox.Show("Зарплата должна быть целым числов (без пробелов)");
                txtSalary.Text = "";
            }


        }

        private void txtKod_TextChanged(object sender, TextChangedEventArgs e)
        {
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            con.Open();
            try
            {
                int id = Convert.ToInt32(txtKod.Text);

                string quary2 = $"SELECT ФИО, Специальность FROM stuff WHERE Id = {id}";
                SqlDataAdapter da2 = new SqlDataAdapter(quary2, con);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                if (dt2.Rows.Count > 0)
                {
                    txtRedFIO.Text = dt2.Rows[0][0].ToString();
                    txtRedSalary.Text = dt2.Rows[0][1].ToString();
                }
                else
                {
                    txtRedFIO.Text = "";
                    txtRedSalary.Text = "";
                }
            }
            catch (FormatException)
            {
                txtRedFIO.Text = "";
                txtRedSalary.Text = "";
            }
            
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            new Главное_меню__Админ_().ShowDialog();
            this.Close();
        }

        private void txtKod_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void txtKod_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtKod.Text == "")
            {
                txtRedFIO.Text = "";
                txtRedSalary.Text = "";
            }

        }
        private void ComboBox()
        {
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            con.Open();

            txtSalary.Items.Clear();
            txtRedSalary.Items.Clear();

            string quaryFIO = $"SELECT DISTINCT Специальность FROM Услуги";
            SqlCommand cmd2 = new SqlCommand(quaryFIO, con);
            SqlDataReader dr = cmd2.ExecuteReader(); //Считывает таблицу

            while (dr.Read()) //Пробегается по всей таблице
            {

                txtSalary.Items.Add(dr[0].ToString()); //Создает елементы из таблицы, название элементов из "Название"
                txtRedSalary.Items.Add(dr[0].ToString());
            }

            dr.Close();


        }
    }


}

