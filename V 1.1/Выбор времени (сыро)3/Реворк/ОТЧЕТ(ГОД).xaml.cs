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
    /// Логика взаимодействия для ОТЧЕТ_ГОД_.xaml
    /// </summary>
    public partial class ОТЧЕТ_ГОД_ : Window
    {
        SqlConnection con;
        SqlCommand cmd, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataSet ds;


        public ОТЧЕТ_ГОД_(string nom, string date)
        {
            InitializeComponent();

            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            con.Open();

            int YEAR = DateTime.Parse(date).Year;
            int ND = DateTime.Now.Day;
            int NM = DateTime.Now.Month;

            lN_Copy.Content += YEAR.ToString() +" год";

            string quary = $"select SUM(Стоимость) FROM Заказы WHERE DAY(Дата) <= {ND} AND MONTH(Дата) <= {NM} AND YEAR(Дата) = {YEAR}";


            cmd = new SqlCommand(quary, con);
            
            lN.Content += cmd.ExecuteScalar().ToString() + " руб.";
            lDate.Content += DateTime.Now.ToShortDateString();
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
