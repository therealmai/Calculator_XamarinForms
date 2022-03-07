using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Leano_Calculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnNumber_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if(LabelResult.Text == "0")
            {
                LabelResult.Text = button.Text;
            }
            else
            {
                LabelResult.Text += button.Text;
            }
        }
    }
}
