using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.OleDb;


namespace Prac
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {



        public MainWindow()

        {
            InitializeComponent();

        }



        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OleDbConnection con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = Prac.accdb");
            //OleDbConnection con = new OleDbConnection("Data Source=(LocalDB)\\MS OleDbLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            con.Open();

            string user = Login.Text;
            string password = Password.Password;

            string query = "SELECT Должность FROM logins WHERE Логин = '" + user + "' AND Пароль = '" + password + "'";

            OleDbDataAdapter ad = new OleDbDataAdapter(query, con);
            DataTable dtbl = new DataTable();
            ad.Fill(dtbl);



            if (dtbl.Rows.Count == 1)
            {
                string g = Convert.ToString(dtbl.Rows[0][0]);
                if (g == "Пользователь")
                {
                    this.Hide();
                    new Admin().ShowDialog();
                    this.Close();
                }

                else if (g == "Админ")
                {

                    this.Hide();
                    new User().ShowDialog();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Неверный Логин или Пароль");
            }
        }
    }
}

