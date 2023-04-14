﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Реворк;

namespace Косметология
{
    /// <summary>
    /// Логика взаимодействия для Отчет.xaml
    /// </summary>
    public partial class Отчет : Window
    {
        SqlConnection con;
        SqlCommand cmd, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataSet ds;

        public Отчет(string client, string tel, string mail, string usluga, string spec, string price)
        {
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\КосметологияБД2.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            con.Open();

            string quary = "SELECT MAX(Код) FROM Заказы WHERE ФИО = N'"+ client +"'";
            cmd = new SqlCommand(quary, con);
            int g = Convert.ToInt32(cmd.ExecuteScalar());


            string quary2 = "Select ФИО From Заказы WHERE Код = " + g;
              string quary3 = "Select Телефон From Заказы WHERE Код = " + g;
              string quary4 = "Select Mail From Заказы WHERE Код = " + g ;
              string quary5 = "Select Услуга From Заказы WHERE Код = " + g;
              string quary6 = "Select Специалист From Заказы WHERE Код = " + g;
              string quary7 = "Select Стоимость From Заказы WHERE Код = " + g; 

              cmd = new SqlCommand(quary, con);
              cmd2 = new SqlCommand(quary2, con);
              cmd3 = new SqlCommand(quary3, con);
              cmd4 = new SqlCommand(quary4, con);
              cmd5 = new SqlCommand(quary5, con);
              cmd6 = new SqlCommand(quary6, con);
              cmd7 = new SqlCommand(quary7, con);



              InitializeComponent();
              lDate.Content += Convert.ToString(DateTime.Now);
              lN.Content += cmd.ExecuteScalar().ToString();
              lClient.Content += cmd2.ExecuteScalar().ToString();
              lTel.Content += cmd3.ExecuteScalar().ToString();
              lMail.Content += cmd4.ExecuteScalar().ToString();
              lUsluga.Content += cmd5.ExecuteScalar().ToString();
              lSpec.Content += cmd6.ExecuteScalar().ToString();
              lPrice.Content += cmd6.ExecuteScalar().ToString();

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
