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
    /// Interaction logic for Show_Items.xaml
    /// </summary>
    public partial class Show_Items : Window
    {
        public Show_Items()
        {
            InitializeComponent();
        }
        SpeechRecognitionEngine spe = new SpeechRecognitionEngine();
        SpeechSynthesizer sps = new SpeechSynthesizer();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Main_Menu mm = new Main_Menu();
            mm.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DBHandler db = new DBHandler();

            db.Showitems(this);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
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
                MessageBox.Show("" + er);
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

    }
}
