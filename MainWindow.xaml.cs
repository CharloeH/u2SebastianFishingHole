/* Sebastian Horton
March 30th, 2018
u2SebastianFishingHole
program takes user's input of point values for trout pike and pickerel as well as the maximum points and outputs all of the possible combinations
*/
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

namespace u2SebastianFishingHole
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> AllCombos = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateFishCombos(object sender, RoutedEventArgs e)
        {  
            string Input = txtInput.Text;
            int ACount = 0;
            int APoints = 0;
            int BCount = 0;
            int BPoints = 0;
            int CCount = 0;
            int CPoints = 0;
            int MaxPoints = 0;
            // Fetch input from window
            int.TryParse(Input.Substring(0, Input.IndexOf("\r")), out APoints);
            Input = Input.Substring(Input.IndexOf("\r") + 2);
            int.TryParse(Input.Substring(0, Input.IndexOf("\r")), out BPoints);
            Input = Input.Substring(Input.IndexOf("\r") + 2);
            int.TryParse(Input.Substring(0, Input.IndexOf("\r")), out CPoints);
            Input = Input.Substring(Input.IndexOf("\r") + 2);
            int.TryParse(Input.Substring(0, Input.Length), out MaxPoints);
            
            // get all combos 
            GetCombos(ACount, APoints, BCount, BPoints, CCount, CPoints, MaxPoints);

            lblOutput.Content = "Total Combinations: " + this.AllCombos.Count;
        }
        
        
        // Get all combinations possible given three point values for fish and the maximum points
        private void GetCombos(int ACount, int APoints, int BCount, int BPoints, int CCount, int CPoints, int MaxPoints)
        {
            // get combinations for A-B-C and A-C-B
            while ((ACount + 1) * APoints + BCount * BPoints + CCount * CPoints <= MaxPoints)
            {
                ACount++;
                AddCombo(ACount, BCount, CCount);
                while (ACount * APoints + (BCount + 1) * BPoints + CCount * CPoints <= MaxPoints)
                {
                    BCount++;
                    AddCombo(ACount, BCount, CCount);
                    while (ACount * APoints + BCount * BPoints + (CCount + 1) * CPoints <= MaxPoints)
                    {
                        CCount++;
                        AddCombo(ACount, BCount, CCount);
                    }
                    CCount = 0;
                }
                BCount = 0;
                while (ACount * APoints + BCount * BPoints + (CCount + 1) * CPoints <= MaxPoints)
                {
                    CCount++;
                    AddCombo(ACount, BCount, CCount);
                }
                CCount = 0;
            }
            
            // get combinations for B-A-C and B-C-A
            ACount = BCount = CCount = 0;
            while (ACount * APoints + (BCount + 1) * BPoints + CCount * CPoints <= MaxPoints)
            {
                BCount++;
                AddCombo(ACount, BCount, CCount);
                while ((ACount + 1) * APoints + BCount * BPoints + CCount * CPoints <= MaxPoints)
                {
                    ACount++;
                    AddCombo(ACount, BCount, CCount);
                    while (ACount * APoints + BCount * BPoints + (CCount + 1) * CPoints <= MaxPoints)
                    {
                        CCount++;
                        AddCombo(ACount, BCount, CCount);
                    }
                    CCount = 0;
                }
                ACount = 0;
                while (ACount * APoints + (BCount + 1) * BPoints + CCount * CPoints <= MaxPoints)
                {
                    BCount++;
                    AddCombo(ACount, BCount, CCount);

                }
                ACount = 0;
            }

            // get combinations for C-B-A and C-A-B
            ACount = BCount = CCount = 0;
            while (ACount * APoints + BCount * BPoints + (CCount + 1) * CPoints <= MaxPoints)
            {
                CCount++;
                AddCombo(ACount, BCount, CCount);
                while (ACount * APoints + (BCount + 1) * BPoints + CCount * CPoints <= MaxPoints)
                {
                    BCount++;
                    AddCombo(ACount, BCount, CCount);
                    while ((ACount + 1) * APoints + BCount * BPoints + CCount * CPoints <= MaxPoints)
                    {
                        ACount++;
                        AddCombo(ACount, BCount, CCount);
                    }
                    ACount = 0;
                }
                BCount = 0;
                while ((ACount + 1) * APoints + BCount * BPoints + CCount * CPoints <= MaxPoints)
                {
                    ACount++;
                    AddCombo(ACount, BCount, CCount);
                }
                ACount = 0;
            }

        }

 
        // add combos to list (ignore duplicates)
        private void AddCombo(int ACount, int BCount, int CCount)
        {
            //check for duplicates
            string StringCombo = ACount.ToString() + "," + BCount.ToString() + "," + CCount.ToString();
            foreach(string Combo in this.AllCombos)
            {
                if (Combo == StringCombo)
                {
                    return; // found duplicate - ignore
                }
            }
            // add combo
            this.AllCombos.Add(StringCombo);
            Label myLabel = new Label();
            myLabel.Content = "Trout " + ACount + ", " + " Pike " + BCount + ", " + " Pickerel " + CCount;
            myStackPanel.Children.Add(myLabel);
        }
    }
}



        
    

