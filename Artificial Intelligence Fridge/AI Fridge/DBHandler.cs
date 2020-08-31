using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;


namespace AI_Fridge
{
    public class DBHandler
    {
        private MySqlConnection connection;
        private String server;
        private String database;
        private String uid;
        private String password;
        Recharge r = new Recharge();
        Items i = new Items();
        int cashout;
        Accounts us = new Accounts();
        int count = 0;

        int ch1 = 0; int be1 = 0; int mi1 = 0; int cu1 = 0; int ca1 = 0; int eg1 = 0; Order_Items g1;

        public DBHandler()
        {

            server = "localhost";
            database = "ai fridge";
            uid = "root";
            password = "";

            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);

        }

        //AI MOde Process
        public void AIprocess(AIMODE ai)

        {
            int Cic = 10 - i.chicken;
            int Bef = 15 - i.Beef;
            int Mil = 5 - i.Milk;
            int Cum = 10 - i.Cucumber;
            int Cap = 10 - i.Capsicum;
            int EEg = 10 - i.Egg;
            int counter = 0;

            int total = Cic * 130 + Bef * 450 + Mil * 65 + Cum * 8 + Cap * 12 + EEg * 9;

            string query = "SELECT * FROM accounts";
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);

            MySqlDataReader dataReader = cmd.ExecuteReader();
            try
            {
                int id = Int32.Parse(ai.textbox1.Text);
                int pass = Int32.Parse(ai.Passbox1.Password);
                while (dataReader.Read())
                {


                    us.CardId = (int)dataReader["CardId"];
                    us.Pass = (int)dataReader["Pass"];
                    us.Balance = (int)dataReader["Balance"];

                   

                    if (id == null || pass == null)
                    {
                        MessageBox.Show("Please Fill Up Card Id and Password!!!");

                    }
                    else
                    {
                        if (us.CardId == id && us.Pass == pass)
                        {
                            counter++;
                            break;
                          

                        }

                        ////////

                        else
                        {
                            MessageBox.Show("WRONG Card ID or PASSWORD!!");
                        }




                        //Egg





                    }
                    //Milk









                }
                dataReader.Close();

                if (counter == 1)
                {
                    if (us.Balance >= total)
                    {
                        us.Balance -= total;

                        string query2 = "UPDATE accounts SET Balance ='" + us.Balance + "' WHERE CardId = '" + id + "'";

                        MySqlCommand cmd2 = new MySqlCommand();

                        cmd2.CommandText = query2;
                        cmd2.Connection = connection;

                        cmd2.ExecuteNonQuery();

                        try
                        {





                            string query1 = "UPDATE items SET Quantity ='10' WHERE item = 'Chicken'";

                            MySqlCommand cmd1 = new MySqlCommand();

                            cmd1.CommandText = query1;
                            cmd1.Connection = connection;

                            cmd1.ExecuteNonQuery();

                            ai.rich.AppendText("Chicken Added - " + Cic + " Costed -" + Cic * 130 + " " + Environment.NewLine);





                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show("" + ex);
                        }






                        //Beef

                        try
                        {




                            string query23 = "UPDATE items SET Quantity ='15' WHERE item = 'Beef'";

                            MySqlCommand cmd23 = new MySqlCommand();

                            cmd23.CommandText = query23;
                            cmd23.Connection = connection;

                            cmd23.ExecuteNonQuery();

                            ai.rich.AppendText("Chicken Added - " + Bef + " Costed -" + Bef * 450 + "BDT " + Environment.NewLine);



                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show("" + ex);
                        }


                        try
                        {





                            string query24 = "UPDATE items SET Quantity ='5' WHERE item = 'Milk'";

                            MySqlCommand cmd24 = new MySqlCommand();

                            cmd24.CommandText = query24;
                            cmd24.Connection = connection;

                            cmd24.ExecuteNonQuery();

                            ai.rich.AppendText("Milk Added - " + Mil + " Costed -" + Mil * 65 + "BDT" + Environment.NewLine);



                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show("" + ex);
                        }



                        //Cucumber


                        try
                        {





                            string query25 = "UPDATE items SET Quantity ='10' WHERE item = 'Cucumber'";

                            MySqlCommand cmd25 = new MySqlCommand();

                            cmd25.CommandText = query25;
                            cmd25.Connection = connection;

                            cmd25.ExecuteNonQuery();

                            ai.rich.AppendText("Cucumber Added - " + Cum + " Costed -" + Cum * 8 + "BDT" + Environment.NewLine);



                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show("" + ex);
                        }




                        //Capsicum


                        try
                        {





                            string query26 = "UPDATE items SET Quantity ='10' WHERE item = 'Capsicum'";

                            MySqlCommand cmd26 = new MySqlCommand();

                            cmd26.CommandText = query26;
                            cmd26.Connection = connection;

                            cmd26.ExecuteNonQuery();

                            ai.rich.AppendText("Capsicum Added - " + Cap + " Costed -" + Cap * 12 + "BDT" + Environment.NewLine);





                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show("" + ex);
                        }

                        try
                        {





                            string query27 = "UPDATE items SET Quantity ='10' WHERE item = 'Egg'";

                            MySqlCommand cmd27 = new MySqlCommand();

                            cmd27.CommandText = query27;
                            cmd27.Connection = connection;

                            cmd27.ExecuteNonQuery();

                            ai.rich.AppendText("Eggs Added - " + EEg + " Costed -" + EEg * 9 + "BDT" + Environment.NewLine);





                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show("" + ex);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Insuffcient Balance !!");
                    }
                }
               

                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(""+ex);
            }

        }


         //Show Items Process

        public void Showitems(Show_Items si)
        {

            string querys = "SELECT * FROM items";
            connection.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter(querys, connection);


            DataTable dt = new DataTable();

            sda.Fill(dt);

            si.Grid.ItemsSource = dt.DefaultView;
            sda.Update(dt);


            connection.Close();
        }

        ///Insert balance
        ///

        public void Insert(int pi, int id)
        {
            try
            {
                this.OpenConnection();

                string query = "SELECT Amount FROM recharge WHERE Code =' " + pi + "' ";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                MySqlDataReader dataReader = cmd.ExecuteReader();





                while (dataReader.Read())
                {
                    r.amount = (int)dataReader["Amount"];


                }

                dataReader.Close();


                //blanace neya

                string query3 = "SELECT * FROM accounts";
               
                MySqlCommand cmd3 = new MySqlCommand(query3, connection);

                MySqlDataReader dataReader2 = cmd3.ExecuteReader();



                while (dataReader2.Read())
                {



                    us.Balance = (int)dataReader2["Balance"];

                }

                dataReader2.Close();
                //shesh


                //Balance update
                us.Balance += r.amount;

                string query2 = "UPDATE accounts SET Balance ='" + us.Balance + "' WHERE CardId = '" + id + "'";

                MySqlCommand cmd2 = new MySqlCommand();

                cmd2.CommandText = query2;
                cmd2.Connection = connection;

                cmd2.ExecuteNonQuery();

                MessageBox.Show("Recaharge Successfull : " + r.amount + " TK");

                string query4 = "DELETE FROM recharge WHERE Code ='"+pi+"'";

                MySqlCommand cmd4 = new MySqlCommand();

                cmd4.CommandText = query4;
                cmd4.Connection = connection;

                cmd4.ExecuteNonQuery();

                this.CloseConnection();

            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex);
            }
}



            


        //THis is for ORder Items
        public void getidpassbal(int ch, int be, int mi, int cu, int ca, int eg, Order_Items gt)
        {
            ch1 = ch;
            be1 = be;
            mi1 = mi;
            cu1 = cu;
            ca1 = ca;
            eg1 = eg;
            g1 = gt;
            //MessageBox.Show(Convert.ToString(ch));
            //MessageBox.Show(Convert.ToString(be));
            //MessageBox.Show(Convert.ToString(mi));
            //MessageBox.Show(Convert.ToString(cu));
            //MessageBox.Show(Convert.ToString(ca));
            //MessageBox.Show(Convert.ToString(eg));
            Payment pa = new Payment(this);
            pa.Show();

        }

        public void orderprocess()
        {


            this.getAllquantity();

            if (i.chicken + ch1 > 10)
            { ch1 = 0; }
            if (i.Beef + be1 > 15)
            { be1 = 0; }
            if (i.Milk + mi1 > 5)
            { mi1 = 0; }
            if (i.Cucumber + cu1 > 10)
            { cu1 = 0; }
            if (i.Capsicum + ca1 > 10)
            { ca1 = 0; }
            if (i.Egg + eg1 > 10)
            { eg1 = 0; }


            //MessageBox.Show(Convert.ToString(ch1));
            //MessageBox.Show(Convert.ToString(be1));
            //MessageBox.Show(Convert.ToString(mi1));
            //MessageBox.Show(Convert.ToString(cu1));
            //MessageBox.Show(Convert.ToString(ca1));
            //MessageBox.Show(Convert.ToString(eg1));



            cashout = ch1 * 130 + be1 * 450 + mi1 * 65 + cu1 * 8 + ca1 * 12 + eg1 * 9;
            
            
            if(cashout<=us.Balance)  //sdfassssssvsdsssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss
            { 

           
                try
                {

                    i.chicken = i.chicken + ch1;

                    this.OpenConnection();

                    string query = "UPDATE items SET Quantity ='" + i.chicken + "' WHERE item = 'Chicken'";

                    MySqlCommand cmd = new MySqlCommand();

                    cmd.CommandText = query;
                    cmd.Connection = connection;

                    cmd.ExecuteNonQuery();

                    this.CloseConnection();
                   g1.RichText1.AppendText("Chickens Orderd -" + ch1 + "" + Environment.NewLine);


                }

                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }

            
            if(ch1==0)
            {


               g1.RichText1.AppendText("Not Enough Space For Chickens!!" + Environment.NewLine);
                    

            }

            //Beef
           
                try
                {

                    i.Beef = i.Beef + be1;

                    this.OpenConnection();

                    string query = "UPDATE items SET Quantity ='" + i.Beef + "' WHERE item = 'Beef'";

                    MySqlCommand cmd = new MySqlCommand();

                    cmd.CommandText = query;
                    cmd.Connection = connection;

                    cmd.ExecuteNonQuery();

                    this.CloseConnection();
                    g1.RichText1.AppendText("Beefs Orderd -" + be1 + "" + Environment.NewLine);


                }

                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }

            
            if(be1==0)
            {


                g1.RichText1.AppendText("Not Enough Space For Beef!!" + Environment.NewLine);
                    
                }
            //Milk
            
            
                try
                {

                    i.Milk = i.Milk + mi1;

                    this.OpenConnection();

                    string query = "UPDATE items SET Quantity ='" + i.Milk + "' WHERE item = 'Milk'";

                    MySqlCommand cmd = new MySqlCommand();

                    cmd.CommandText = query;
                    cmd.Connection = connection;

                    cmd.ExecuteNonQuery();

                    this.CloseConnection();
                    g1.RichText1.AppendText("Milk orderd -" + mi1 + "" + Environment.NewLine);


                }

                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }


                if (mi1 == 0)
                {


                g1.RichText1.AppendText("Not Enough Space For Milk!! " + Environment.NewLine);
                    
                }
            //Cucumber

          
                try
                {

                    i.Cucumber = i.Cucumber + cu1;

                    this.OpenConnection();

                    string query = "UPDATE items SET Quantity ='" + i.Cucumber + "' WHERE item = 'Cucumber'";

                    MySqlCommand cmd = new MySqlCommand();

                    cmd.CommandText = query;
                    cmd.Connection = connection;

                    cmd.ExecuteNonQuery();

                    this.CloseConnection();
                   g1.RichText1.AppendText("Cucumbers orderd -" + cu1 + "" + Environment.NewLine);


                }

                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }

            
            if(cu1==0)
            {


                g1.RichText1.AppendText("Not Enough Space for Cucumber!!" + Environment.NewLine);
                   
                }

            //Capsicum

          
                try
                {

                    i.Capsicum = i.Capsicum + ca1;

                    this.OpenConnection();

                    string query = "UPDATE items SET Quantity ='" + i.Capsicum + "' WHERE item = 'Capsicum'";

                    MySqlCommand cmd = new MySqlCommand();

                    cmd.CommandText = query;
                    cmd.Connection = connection;

                    cmd.ExecuteNonQuery();

                    this.CloseConnection();
                  g1.RichText1.AppendText("Capcisums Orderd -" + ca1 + "" + Environment.NewLine);


                }

                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }

            
            if(ca1==0)
            {


                g1.RichText1.AppendText("Not Enough Space For Capsicum!!" + Environment.NewLine);
                    
                }


            //Egg

          
                try
                {

                    i.Egg = i.Egg + eg1;

                    this.OpenConnection();

                    string query = "UPDATE items SET Quantity ='" + i.Egg + "' WHERE item = 'Egg'";

                    MySqlCommand cmd = new MySqlCommand();

                    cmd.CommandText = query;
                    cmd.Connection = connection;

                    cmd.ExecuteNonQuery();

                    this.CloseConnection();
                  g1.RichText1.AppendText("Eggs Orderd -" + eg1 + "" + Environment.NewLine);


                }

                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }

            
            if(eg1==0)
            {


               g1.RichText1.AppendText("Not Enough Space For Eggs!!" + Environment.NewLine);
                  
                }

                cashoutf();


        }

            else
            {
                MessageBox.Show("OREE BHADAIMMA TAKA NAI!!!!");
            }


        }


        public void cashoutf()
        {


            if (count == 1)
            {
                us.Balance -= cashout;

                this.OpenConnection();
                

                string query1 = "UPDATE accounts SET Balance = " + us.Balance + " WHERE  CardId = " + us.CardId;

                MySqlCommand cmd1 = new MySqlCommand();

                cmd1.CommandText = query1;
                cmd1.Connection = connection;

                cmd1.ExecuteNonQuery();

                this.CloseConnection();


                g1.RichText1.AppendText("Total Cost = " + cashout+  "" + Environment.NewLine);
                g1.RichText1.AppendText("Remaining Balance = " + us.Balance + "" + Environment.NewLine);

            }
            else
            {
                MessageBox.Show("Wrong usenrame or Password");
            }



        }

        public void Payment(Payment p)
        {
            int id=int.Parse(p.textbox1.Text);
            int pass=int.Parse(p.textbox2.Password);
           


            string query = "SELECT * FROM accounts";
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);

            MySqlDataReader dataReader = cmd.ExecuteReader();
            

            while (dataReader.Read())
            {
                

                us.CardId = (int)dataReader["CardId"];
                us.Pass = (int)dataReader["Pass"];
                us.Balance = (int)dataReader["Balance"];

                if (id == null || pass == null)
                {
                    MessageBox.Show("Please Fill Up Card Id and Password!!!");

                }
                else
                {
                    if (us.CardId == id && us.Pass == pass)
                    {

                        count++;
                        break;



                    }
                    //if (count == 1)
                    //{
                    //    this.Hide();
                    //    mm.Show();
                    //    MessageBox.Show("Access Granted!");

                    //}
                    //else
                    //{
                    //    MessageBox.Show("Wrong usenrame or Password");
                    //}

                }
            }
           
            dataReader.Close();
            connection.Close();
        }
        public void  getAllquantity()
        {
            

            //For chicken
            string query = "SELECT Quantity FROM items WHERE Item = 'Chicken'";
            
            this.OpenConnection();
            MySqlCommand cmd = new MySqlCommand(query, connection);

            MySqlDataReader dataReader = cmd.ExecuteReader();

            while(dataReader.Read())
            {
                
               
                i.chicken = (int)dataReader["Quantity"];
               
             }
            dataReader.Close();

            //For beef
            string query2 = "SELECT Quantity FROM items WHERE Item = 'Beef'";

            
            MySqlCommand cmd2 = new MySqlCommand(query2, connection);

            MySqlDataReader dataReader2 = cmd2.ExecuteReader();

            while (dataReader2.Read())
            {

                
                i.Beef= (int)dataReader2["Quantity"];
            }
            dataReader2.Close();

            //for milk

            string query3 = "SELECT Quantity FROM items WHERE Item = 'Milk'";

            
            MySqlCommand cmd3 = new MySqlCommand(query3, connection);

            MySqlDataReader dataReader3 = cmd3.ExecuteReader();

            while (dataReader3.Read())
            {

                
                i.Milk = (int)dataReader3["Quantity"];
            }
            dataReader3.Close();

            // cucumber

            string query4 = "SELECT Quantity FROM items WHERE Item = 'Cucumber'";

            
            MySqlCommand cmd4 = new MySqlCommand(query4, connection);

            MySqlDataReader dataReader4 = cmd4.ExecuteReader();

            while (dataReader4.Read())
            {

               
                i.Cucumber = (int)dataReader4["Quantity"];
            }
            dataReader4.Close();

            //Capsicum

            string query5 = "SELECT Quantity FROM items WHERE Item = 'Capsicum'";

            
            MySqlCommand cmd5 = new MySqlCommand(query5, connection);

            MySqlDataReader dataReader5 = cmd5.ExecuteReader();

            while (dataReader5.Read())
            {

              
                i.Capsicum = (int)dataReader5["Quantity"];
            }
            dataReader5.Close();

            //Egg

            string query6 = "SELECT Quantity FROM items WHERE Item = 'Egg'";

            
            MySqlCommand cmd6 = new MySqlCommand(query6, connection);

            MySqlDataReader dataReader6 = cmd6.ExecuteReader();

            while (dataReader6.Read())
            {

                
                i.Egg = (int)dataReader6["Quantity"];
            }

            dataReader6.Close();




            this.CloseConnection();



            
        }

        //For AI mode

       

        public void getitemscalculation(int ch,int be, int mi,int cu , int ca, int eg, Get_Items gt)
        {

            //CHic
           

            if (i.chicken > ch)
            {
                try
                {
                   
                    i.chicken = i.chicken - ch;

                    this.OpenConnection();

                    string query = "UPDATE items SET Quantity ='" + i.chicken + "' WHERE item = 'Chicken'";

                    MySqlCommand cmd = new MySqlCommand();

                    cmd.CommandText = query;
                    cmd.Connection = connection;

                    cmd.ExecuteNonQuery();

                    this.CloseConnection();
                    gt.RichText1.AppendText("Chickens removed -"+ch+"" + Environment.NewLine);

                    
                }

                catch(Exception ex)
                {
                    MessageBox.Show(""+ex);
                }

            }
            else
            {
                

                gt.RichText1.AppendText("Not Enough Chickens left" + Environment.NewLine);
            }

            //Beef
            if (i.Beef > be)
            {
                try
                {

                    i.Beef = i.Beef - be;

                    this.OpenConnection();

                    string query = "UPDATE items SET Quantity ='" + i.Beef + "' WHERE item = 'Beef'";

                    MySqlCommand cmd = new MySqlCommand();

                    cmd.CommandText = query;
                    cmd.Connection = connection;

                    cmd.ExecuteNonQuery();

                    this.CloseConnection();
                    gt.RichText1.AppendText("Beefs removed -" + be + "" + Environment.NewLine);


                }

                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }

            }
            else
            {


                gt.RichText1.AppendText("Not Enough Beef left" + Environment.NewLine);
            }
            //Milk
            if (i.Milk > mi)
            {
                try
                {

                    i.Milk = i.Milk - mi;

                    this.OpenConnection();

                    string query = "UPDATE items SET Quantity ='" + i.Milk + "' WHERE item = 'Milk'";

                    MySqlCommand cmd = new MySqlCommand();

                    cmd.CommandText = query;
                    cmd.Connection = connection;

                    cmd.ExecuteNonQuery();

                    this.CloseConnection();
                    gt.RichText1.AppendText("Milk removed -" + mi + "" + Environment.NewLine);


                }

                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }

            }
            else
            {


                gt.RichText1.AppendText("Not Enough Milk left" + Environment.NewLine);
            }
            //Cucumber

            if (i.Cucumber > cu)
            {
                try
                {

                    i.Cucumber = i.Cucumber - cu;

                    this.OpenConnection();

                    string query = "UPDATE items SET Quantity ='" + i.Cucumber + "' WHERE item = 'Cucumber'";

                    MySqlCommand cmd = new MySqlCommand();

                    cmd.CommandText = query;
                    cmd.Connection = connection;

                    cmd.ExecuteNonQuery();

                    this.CloseConnection();
                    gt.RichText1.AppendText("Cucumbers removed -" + cu + "" + Environment.NewLine);


                }

                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }

            }
            else
            {


                gt.RichText1.AppendText("Not Enough Cucumber left" + Environment.NewLine);
            }

            //Capsicum

            if (i.Capsicum > ca)
            {
                try
                {

                    i.Capsicum = i.Capsicum - ca;

                    this.OpenConnection();

                    string query = "UPDATE items SET Quantity ='" + i.Capsicum + "' WHERE item = 'Capsicum'";

                    MySqlCommand cmd = new MySqlCommand();

                    cmd.CommandText = query;
                    cmd.Connection = connection;

                    cmd.ExecuteNonQuery();

                    this.CloseConnection();
                    gt.RichText1.AppendText("Capcisums removed -" + ca + "" + Environment.NewLine);


                }

                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }

            }
            else
            {


                gt.RichText1.AppendText("Not Enough Capsicum left" + Environment.NewLine);
            }

            //Egg

            if (i.Egg > eg)
            {
                try
                {

                    i.Egg = i.Egg - eg;

                    this.OpenConnection();

                    string query = "UPDATE items SET Quantity ='" + i.Egg + "' WHERE item = 'Egg'";

                    MySqlCommand cmd = new MySqlCommand();

                    cmd.CommandText = query;
                    cmd.Connection = connection;

                    cmd.ExecuteNonQuery();

                    this.CloseConnection();
                    gt.RichText1.AppendText("Eggs removed -" + eg + "" + Environment.NewLine);


                }

                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }

            }
            else
            {


                gt.RichText1.AppendText("Not Enough Eggs left" + Environment.NewLine);
            }

        }

        /// <summary>
        /// /End of Order Items
        /// </summary>

        private void OpenConnection()
        {
            try
            {
                connection.Open();
                

            }
            catch(MySqlException ex )
            {
                throw ex;
            }
        }

        private void CloseConnection()
        {
            try
            {
                connection.Close();
            }
            catch(MySqlException ex)
            {
                throw ex;
            }
        }


           
    }
}
