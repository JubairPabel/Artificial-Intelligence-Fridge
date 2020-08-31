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

namespace AI_Fridge
{
    /// <summary>
    /// Interaction logic for Payment.xaml
    /// </summary>
    public partial class Payment : Window
    {
        DBHandler dbh;
        public Payment()
        {
            InitializeComponent();
        }

        public Payment(DBHandler dbh)
        {
            InitializeComponent();
            this.dbh = dbh;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

          
            dbh.Payment(this);
            dbh.orderprocess();
            this.Hide();
        }
    }
}
