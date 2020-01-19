using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace CrossSum
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

        private void Btn_Go_Click(object sender, RoutedEventArgs e)
        {
            CalculateSum(Tbx_Input.Text);
        }

        private void CalculateSum(string input)
        {
            Regex rgx = new Regex(@"^\d{6}$");
            if (rgx.IsMatch(input))
            {
                int sum = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    sum += Convert.ToInt32(input[i]) - 48;
                }
                Tblk_Output.Text = string.Format("The result {0} is {1}", input, sum);
                Tblk_Output.Foreground = Brushes.Black;
            }
            else
            {
                Tblk_Output.Text = string.Format("Only 6 digits integer are allowed.");
                Tblk_Output.Foreground = Brushes.Red;
            }
            //MessageBox.Show("Input " + input + " successfully!");
        }

        private void Tbx_Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Tblk_Output.Text = "";
            }
            catch
            {

            }
        }

        private void Tbx_Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CalculateSum(Tbx_Input.Text);
            }
        }
    }
}
