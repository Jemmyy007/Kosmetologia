using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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

namespace Prac
{
    /// <summary>
    /// Логика взаимодействия для Платы.xaml
    /// </summary>
    public partial class Платы : Window
    {
        int kod;
        OleDbConnection con;
        public Платы()
        {
            InitializeComponent();
            GRID();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = Prac.accdb");
            con.Open();

            if (txtName.Text != "")
            {
                string name = txtName.Text;
                string quary = $"INSERT INTO Платы (Название) VALUES ('{txtName.Text}')";
                OleDbCommand cmd = new OleDbCommand(quary, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Получилось");

                GRID();

                con.Close();

                txtName.Text = "";

            }
            else
            {
                MessageBox.Show("Введите название платы");
            }
            
        }
        void GRID()
        {
            con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = Prac.accdb");
            con.Open();
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter();
            da = new OleDbDataAdapter("select * from Платы", con);
            ds = new DataSet();
            da.Fill(ds, "Платы");
            dataPlat.ItemsSource = ds.Tables["Платы"].DefaultView;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = Prac.accdb");
            con.Open();

            try
            {
                if (txtName.Text != "")
                
                {
                    int kod2 = Convert.ToInt32(kod);
                    string name = txtName.Text;

                    string query = "UPDATE Платы SET [Название] = '" + name + "' WHERE [Код] = " + kod;
                    OleDbCommand cmd = new OleDbCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Получилось");

                    GRID();

                    con.Close();

                    txtName.Text = "";
                }
                else
                {
                    MessageBox.Show("Введите название");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Выберите пользователя");

            }
        }

        private void dataPlat_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {

                var selectedRow = (DataRowView)dataPlat.SelectedItem;
                if (selectedRow != null)
                {
                    txtName.Text = selectedRow[1].ToString();                  
                    kod = Convert.ToInt32(selectedRow[0]);

                }
            }
            catch
            {

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
