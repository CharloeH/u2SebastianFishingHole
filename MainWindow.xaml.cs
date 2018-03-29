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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClick_Click(object sender, RoutedEventArgs e)
        {
            string Input = txtInput.Text;

            int TroutFishNumber = 0;
            int TroutPoints = 0;
            int PikeFishNumber = 0;
            int PikePoints = 0;
            int PickerelFishNumber = 0;
            int PickerelPoints;
            int TotalPoints;
            int TotalFish = TroutFishNumber + PikeFishNumber + PickerelFishNumber;
            int.TryParse(Input.Substring(0, Input.IndexOf("\r")), out TroutPoints);
            Input = Input.Substring(Input.IndexOf("\r") + 2);
            //MessageBox.Show(TroutPoints.ToString());
            int.TryParse(Input.Substring(0, Input.IndexOf("\r")), out PikePoints);
            Input = Input.Substring(Input.IndexOf("\r") + 2);
            //MessageBox.Show(PikePoints.ToString());
            int.TryParse(Input.Substring(0, Input.IndexOf("\r")), out PickerelPoints);
            Input = Input.Substring(Input.IndexOf("\r") + 2);
            //MessageBox.Show(PickerelPoints.ToString());
            int.TryParse(Input.Substring(0, Input.IndexOf("\r")), out TotalPoints);
            //MessageBox.Show(TotalPoints.ToString());
            int Output = 0;
            while ((TroutFishNumber*TroutPoints) + (PikeFishNumber*PikePoints) + (PickerelFishNumber*PickerelPoints) != TotalPoints & (TroutFishNumber * TroutPoints) + (PikeFishNumber * PikePoints) + (PickerelFishNumber * PickerelPoints) < TotalPoints)
            {
               
                
                    TroutFishNumber++;
                    MessageBox.Show("trout: " + TroutFishNumber.ToString());
                    CreateLabel(TroutFishNumber, 0, 0);
                    if ((TroutFishNumber * TroutPoints) == TotalPoints)
                    {
                        PikeFishNumber++;
                        MessageBox.Show("pike: " + PikeFishNumber.ToString());
                        CreateLabel(0, PikeFishNumber, 0);
                        if ((PikeFishNumber * PikePoints) == TotalPoints)
                        {
                            PickerelFishNumber++;
                            MessageBox.Show("Pickerel: " + PickerelFishNumber.ToString());
                            CreateLabel(0, 0, PickerelFishNumber);
                        }
                    
                }
                if ((TroutFishNumber * TroutPoints) + (PikeFishNumber * PikePoints) + (PickerelFishNumber * PickerelPoints) == TotalPoints)
                {
                    CreateLabel(TroutFishNumber, PikeFishNumber, PickerelFishNumber);
                }
            } 
            

        }
        
        private void CreateLabel( int fish1, int fish2, int fish3)
        {
            Label myLabel = new Label();
            myLabel.Content = "Trout: " + fish1 + " Pike: " + fish2 + " Pickerel: " + fish3; 
            myStack.Children.Add(myLabel);
        }
    }
}



    

        
        
