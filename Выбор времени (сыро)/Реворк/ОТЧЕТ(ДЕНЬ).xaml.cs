using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для ОТЧЕТ_ДЕНЬ_.xaml
    /// </summary>
    public partial class ОТЧЕТ_ДЕНЬ_ : Window
    {
        SqlConnection con;
        SqlCommand cmd, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataSet ds;

        public ОТЧЕТ_ДЕНЬ_(string nom, string date)
        {
            InitializeComponent();

            lN_Copy.Content += date;

            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            con.Open();

            int DAY = DateTime.Parse(date).Day;
            int MONTH = DateTime.Parse(date).Month;
            int YEAR = DateTime.Parse(date).Year;


            string quary = $"select SUM(Стоимость) FROM Заказы WHERE DAY(Дата) = {DAY} AND MONTH(Дата) = {MONTH} AND YEAR(Дата) = {YEAR}";

            
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
                pr.PrintVisual(logoContainer1, $"{date}");
            }
        }
    }
}
