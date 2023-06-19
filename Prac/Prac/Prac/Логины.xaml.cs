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
using System.Data.OleDb;
using System.Security.Policy;

namespace Prac
{
    /// <summary>
    /// Логика взаимодействия для Логины.xaml
    /// </summary>
    public partial class Логины : Window
    {
        public int kod = 0;
        OleDbConnection con;
        public Логины()
        {
            InitializeComponent();
            GRID();

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        
        void GRID()
        {
            con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = Prac.accdb");
            con.Open();
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter();
            da = new OleDbDataAdapter("select * from logins", con);
            ds = new DataSet();
            da.Fill(ds, "logins");
            dataLogins.ItemsSource = ds.Tables["logins"].DefaultView;
        }

        private void dataLogins_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {

                var selectedRow = (DataRowView)dataLogins.SelectedItem;
                if (selectedRow != null)
                {
                    txtFIO.Text = selectedRow[1].ToString();
                    txtLogin.Text = selectedRow[3].ToString();
                    txtPass.Text = selectedRow[4].ToString();
                    comStatus.Text = selectedRow[2].ToString();
                    kod = Convert.ToInt32(selectedRow[0]);
                    
                }
            }
            catch { 
            
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = Prac.accdb");
            con.Open();

            try
            {
                if (txtFIO.Text == "" || txtLogin.Text == "" || txtPass.Text == "" || comStatus.SelectedIndex == -1)
                {
                    MessageBox.Show("Выберите пользователя");
                }
                else
                {
                    int kod2 = Convert.ToInt32(kod);
                    string log = txtLogin.Text;
                    string pas = txtPass.Text;
                    string fio = txtFIO.Text;
                    string status = comStatus.Text;

                    string query = "UPDATE logins SET [Login] = '" + log + "', [Password] = '" + pas + "', ФИО = '" + fio + "', Должность = '" + status + "' WHERE [Код] = " + kod;
                    OleDbCommand cmd = new OleDbCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Получилось");

                    GRID();

                    con.Close();

                    txtLogin.Text = "";
                    txtPass.Text = "";
                    txtFIO.Text = "";
                    comStatus.SelectedIndex = -1;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Выберите пользователя");
                
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = Prac.accdb");
            con.Open();

                if (txtFIO.Text == "" || txtLogin.Text == "" || txtPass.Text == "" || comStatus.SelectedIndex == -1)
                {
                    MessageBox.Show("Введите данные для добавления");
                }
                else
                {
                   
                    string log = txtLogin.Text;
                    string pas = txtPass.Text;
                    string fio = txtFIO.Text;
                    string status = comStatus.Text;
                    MessageBox.Show(fio);
                    MessageBox.Show(status);
                    MessageBox.Show(log);
                    MessageBox.Show(pas);

                string query = $"INSERT INTO logins (ФИО, Должность, Логин, Пароль) VALUES ('{fio}', '{status}', '{log}', '{pas}')";
                OleDbCommand cmd = new OleDbCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Получилось");

                    GRID();

                    con.Close();

                    txtLogin.Text = "";
                    txtPass.Text = "";
                    txtFIO.Text = "";
                    comStatus.SelectedIndex = -1;
                }
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new User().Show();
            this.Close();
        }
    }
    
}
