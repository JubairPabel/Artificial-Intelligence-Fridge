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
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;

namespace AI_Fridge
{
    /// <summary>
    /// Interaction logic for Get_Items.xaml
    /// </summary>
    /// 
    
    public partial class Get_Items : Window
    {

        
        public Get_Items()
        {
            InitializeComponent();
        }

     
       

        SpeechRecognitionEngine spe = new SpeechRecognitionEngine();
        SpeechSynthesizer sps = new SpeechSynthesizer();
        
       

        



        private void btnspeak_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                spe.SetInputToDefaultAudioDevice();
                spe.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"TextFile1.txt")))));
                spe.SpeechRecognized += Recognizer;
                spe.SpeechDetected += un_Recognizer;
                spe.RecognizeAsync(RecognizeMode.Multiple);
            }

            catch (Exception er)
            {
                MessageBox.Show(""+er);
            }
        }
        private void un_Recognizer(object sender, SpeechDetectedEventArgs e)
        {

        }

        private void Recognizer(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
         

            if (speech == "Go Back")
            {
                Main_Menu g = new Main_Menu();
                spe.RecognizeAsyncCancel();
                this.Hide();
                
                g.Show();




            }
        }

        private void btnback_Click(object sender, RoutedEventArgs e)
        {

            spe.RecognizeAsyncCancel();
            Main_Menu g = new Main_Menu();
            this.Hide();
            g.Show();
        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DBHandler db = new DBHandler();
            int chiq = Int32.Parse(textbox1.Text);
            int beq = Int32.Parse(textbox2.Text);
            int miq = Int32.Parse(textbox3.Text);
            int cuq = Int32.Parse(textbox4.Text);
            int caq = Int32.Parse(textbox5.Text);
            int egq = Int32.Parse(textbox6.Text);

            db.getAllquantity();

            db.getitemscalculation(chiq, beq, miq, cuq, caq, egq,this);

        }
    }
}
