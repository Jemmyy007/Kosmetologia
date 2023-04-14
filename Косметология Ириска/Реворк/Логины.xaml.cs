using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Логины.xaml
    /// </summary>
    public partial class Логины : Window
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataSet ds;

        

        public Логины()
        {
            InitializeComponent();

            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            cmd = new SqlCommand();
            con.Open();

            da = new SqlDataAdapter("select * from logins", con);
            ds = new DataSet();
            da.Fill(ds, "logins");

            dataLogins.ItemsSource = ds.Tables["logins"].DefaultView;
            con.Close();

        }


        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }

        private void dataLogins_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {

        }

        private void dataLogins_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }





        private void ButtonInsert(object sender, RoutedEventArgs e)
        {

        }

        private void dataLogins_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtChangeLog_Click(object sender, RoutedEventArgs e)
        {
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            con.Open();

            try
            {
                int kod = Convert.ToInt32(txtKod.Text);
                string log = txtLogin.Text;
                string pas = txtPass.Text;

                string query = "UPDATE logins SET [Login] = N'" + log + "', [Password] = N'" + pas + "' WHERE [Код] = " + kod;
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Получилось");

                da = new SqlDataAdapter("select * from logins", con);
                ds = new DataSet();
                da.Fill(ds, "logins");
                dataLogins.ItemsSource = ds.Tables["logins"].DefaultView;

                con.Close();

                txtKod.Text = "";
                txtLogin.Text = "";
                txtPass.Text = "";
            }
            catch (FormatException)
            {
                MessageBox.Show("В поле код нужно ввести номер выбранной вами запси");
                txtKod.Text = "";
            }

           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Главное_меню__Админ_().ShowDialog();
            this.Close();
        }

        private void txtKod_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

       
    
}
