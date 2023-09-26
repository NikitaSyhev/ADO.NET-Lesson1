using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {


        private string ConnectionString;
        private SqlConnection connection = null;
        private string SQLExpression =
            "USE Users; SELECT * FROM Metrics;"; // тестовый запрос, сдеаем что нибудь другое

        public Form1()
        {
            InitializeComponent();
            tbConnectionSTR.Text = " Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;  ";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(connection != null)
            {
                connection.Close();
                connection = null;
                return;
            }
            ConnectionString = tbConnectionSTR.Text;
            connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(SQLExpression, connection);
            SqlDataReader reader = command.ExecuteReader();
            object first, second,third;
            string tmp = string.Empty;
            if(reader.HasRows) //если данные не пусты
            {
                while(reader.Read()) //метод считывает построчно
                {
                     first = reader.GetValue(0); //возвращает значение с индексом
                  //  bool IsEnd = reader.NextResult();// Возвращает true, если есть следующий результат
                                                     // , и false, если все результаты уже обработаны. 

                    second =reader.GetValue(1);
                    third =reader.GetValue(2);
                    tmp = $"{first} | {second} | {third}";
                    textBox2.Text += tmp;
                }    
            }

        }
        

    }
}
