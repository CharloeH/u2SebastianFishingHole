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

            int TroutFish = 0;
            int TroutPoints = 0;
            int PikeFish = 0;
            int PikePoints = 0;
            int PickerelFish = 0;
            int PickerelPoints;
            int TotalPoints;
            int.TryParse(Input.Substring(0, Input.IndexOf("\r")), out TroutPoints);
            Input = Input.Substring(Input.IndexOf("\r") + 2);

            int.TryParse(Input.Substring(0, Input.IndexOf("\r")), out PikePoints);
            Input = Input.Substring(Input.IndexOf("\r") + 2);
       
            int.TryParse(Input.Substring(0, Input.IndexOf("\r")), out PickerelPoints);
            Input = Input.Substring(Input.IndexOf("\r") + 2);
         
            int.TryParse(Input.Substring(0, Input.IndexOf("\r")), out TotalPoints);
            int Output = 0;
            while (TroutFish * TroutPoints != TotalPoints & TroutFish * TroutPoints < TotalPoints)
            {
                TroutFish++;
                CreateLabel(TroutFish, 0, 0);
                Output = Output + 1;
            }
            while (PikeFish * PikePoints != TotalPoints & PikeFish * PikePoints < TotalPoints)
            {
                PikeFish++;
                CreateLabel(0, PikeFish,  0);
                Output = Output + 1;
            }
            while (PickerelFish * PickerelPoints != TotalPoints & PickerelFish * PickerelPoints < TotalPoints)
            {
                PickerelFish++;
                CreateLabel( 0, 0, PickerelFish);
                Output = Output + 1;
            } lblOutput.Content = "Total Combinations: " + Output;
        }

        private void CreateLabel( int fish1, int fish2, int fish3)
        {
            Label myLabel = new Label();
            myLabel.Content = "Trout: " + fish1 + " Pike: " + fish2 + " Pickerel: " + fish3; 
            myStack.Children.Add(myLabel);
        }
    }
}
