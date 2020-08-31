using System;
using System.Collections;
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
using MySql.Data;
using MySql.Data.MySqlClient;

namespace AI_Fridge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        BLClass bl = new BLClass();
       
        public MainWindow()
        {
            InitializeComponent();
           
        }
        private MySqlConnection connection;
        private String server;
        private String database;
        private String uid;
        private String password;


        private void btnLog_Click(object sender, RoutedEventArgs e)
        {

            string username = textbox1.Text;
            string pass = textbox2.Text;
            Main_Menu mm = new Main_Menu();
            server = "localhost";
            database = "ai fridge";
            uid = "root";
            password = "";

            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);

            string query = "SELECT * FROM user";
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);

            MySqlDataReader dataReader = cmd.ExecuteReader();
            int count = 0;

            while (dataReader.Read())
            {
                User us = new User();

                us.Username = dataReader["UserName"].ToString();
                us.pass = dataReader["Pass"].ToString();
                us.phone = (int)dataReader["Phone"];

                if (username == "" || pass == "")
                {
                    MessageBox.Show("Please Fill Up Username and Password!!!");
                    
                }
                else
                {
                    if (us.Username == username && us.pass == pass)
                    {

                        count++;

                        break;

                    }
                   
                    
                }
            }
            if (count == 1)
            {
                this.Hide();
                mm.Show();
                MessageBox.Show("Access Granted!");

                    }
            else
            {
                MessageBox.Show("Wrong usenrame or Password");
                    }
            dataReader.Close();
            connection.Close();

          

           

           
            
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }
    }
}
