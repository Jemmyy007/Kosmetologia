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
                int salary = Convert.ToInt32(txtRedSalary.Text);
                string exp = txtRedExp.Text;

                string query = "UPDATE stuff SET ФИО = N'" + fio + "', Опыт = N'" + exp + "', Зарплата = N'" + salary +"' WHERE [Id] = " + kod;
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
            txtRedExp.Text = "";
        }

        private void AddBut_Click(object sender, RoutedEventArgs e)
        {
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            con.Open();

            try
            {

               
                string fio = txtFIO.Text;
                int salary = Convert.ToInt32(txtSalary.Text);
                string exp = txtExp.Text;

                string query = $"INSERT INTO stuff (ФИО, Опыт, Зарплата) VALUES (N'{fio} ', N' {exp}', N'{salary}')";                
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Запись добавлена");

                da = new SqlDataAdapter("select * from stuff", con);
                ds = new DataSet();
                da.Fill(ds, "stuff");
                StuffGrid.ItemsSource = ds.Tables["stuff"].DefaultView;
 
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

        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            new Главное_меню__Админ_().ShowDialog();
            this.Close();
        }
    }

        
}

