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
    /// Логика взаимодействия для ОТЧЕТ_МЕСЯЦ_.xaml
    /// </summary>
    public partial class ОТЧЕТ_МЕСЯЦ_ : Window
    {
        SqlConnection con;
        SqlCommand cmd, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataSet ds;

        public ОТЧЕТ_МЕСЯЦ_(string nom, string date)
        {
            InitializeComponent();

            int M = DateTime.Parse(date).Month;
            int Y = DateTime.Parse(date).Year;
            

            switch (M)
            {
                case 1:
                    lN_Copy.Content += "Январь " + Y + " года";
                    break;
                case 2:
                    lN_Copy.Content += "Февраль " + Y + " года";
                    break;
                case 3:
                    lN_Copy.Content += "Март " + Y + " года";
                    break;
                case 4:
                    lN_Copy.Content += "Апрель " + Y + " года";
                    break;
                case 5:
                    lN_Copy.Content += "Май " + Y + " года";
                    break;
                case 6:
                    lN_Copy.Content += "Июнь " + Y + " года";
                    break;
                case 7:
                    lN_Copy.Content += "Июль " + Y + " года";
                    break;
                case 8:
                    lN_Copy.Content += "Август " + Y + " года";
                    break;
                case 9:
                    lN_Copy.Content += "Сентябрь " + Y + " года";
                    break;
                case 10:
                    lN_Copy.Content += "Октябрь " + Y + " года";
                    break;
                case 11:
                    lN_Copy.Content += "Ноябрь " + Y + " года";
                    break;
                case 12:
                    lN_Copy.Content += "Декабрь " + Y + " года";
                    break;

            }

            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            con.Open();

            
            int MONTH = DateTime.Parse(date).Month;
            int YEAR = DateTime.Parse(date).Year;

            int ND = DateTime.Now.Day;


            string quary = $"select SUM(Стоимость) FROM Заказы WHERE DAY(Дата) <= {ND} AND MONTH(Дата) = {MONTH} AND YEAR(Дата) = {YEAR}";


            cmd = new SqlCommand(quary, con);
            //lN.Content = cmd.ExecuteScalar().ToString();
            lN.Content += cmd.ExecuteScalar().ToString() + " руб.";
            lDate.Content += Convert.ToString(DateTime.Now);
            con.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string date = DateTime.Today.ToString("G");
            PrintDialog pr = new PrintDialog();
            if (pr.ShowDialog() == true)
            {
                Application.Current.MainWindow = this;
                Application.Current.MainWindow.Height = 11.5 * 96;
                Application.Current.MainWindow.Width = 8 * 96;
                pr.PrintVisual(logoContainer1, $"{date}");
            }
        }
    }
}
