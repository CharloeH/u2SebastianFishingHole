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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace u2SebastianTXTMSG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           


        }

        private void btnClick_Click(object sender, RoutedEventArgs e)
        {
            string Input = txtInput.Text;
            string Output = "";
            string Line;
            string LineEnding = "\r\n";
            string LastLine = "TTYL";
            int LineEndingLength = LineEnding.Length;
            do
            {
                int EndIndex = Input.IndexOf(LineEnding);
                if (EndIndex == -1)
                {
                    EndIndex = Input.Length;
                }
                Line = Input.Substring(0, EndIndex);
                if (Line == "CU")
                {
                    Output = Output + "See you" + LineEnding;
                }
                else if (Line == ":-)")
                {
                    Output = Output + "I'm happy" + LineEnding;
                }
                else if (Line == ":-(")
                {
                    Output = Output + "I'm Sad" + LineEnding;
                }
                else if (Line == ";-)")
                {
                    Output = Output + "Wink" + LineEnding;
                }
                else if (Line == ":-P")
                {
                    Output = Output + "stick out my toungue" + LineEnding;
                }
                else if (Line == "(~.~)")
                {
                    Output = Output + "sleepy" + LineEnding;
                }
                else if (Line == "TA")
                {
                    Output = Output + "totally awesome" + LineEnding;
                }
                else if (Line == "CCC")
                {
                    Output = Output + "Canadian Computing Competition" + LineEnding;
                }
                else if (Line == "CUZ")
                {
                    Output = Output + "thank-you" + LineEnding;
                }
                else if (Line == "YW")
                {
                    Output = Output + "you're welcome" + LineEnding;
                }
                else if (Line == LastLine)
                {
                    Output = Output + "Talk to you later";
                }

                else
                {
                    Output = Output + Line + LineEnding;
                }
                if (Line != LastLine)
                {
                    Input = Input.Substring(EndIndex + LineEndingLength, Input.Length - EndIndex - LineEndingLength);
                }
            } while (Line != LastLine);
            lblOutput.Content = Output;
        }
    }
}
