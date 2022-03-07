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

        private decimal number1;
        private string operatorName;
        private bool isClickedOperator;
        private bool isClickedDecimal = false;

        private void btnNumber_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if(LabelResult.Text == "0" || isClickedOperator)
            {
                isClickedOperator = false;
                LabelResult.Text = button.Text;
            }
            else
            {
                LabelResult.Text += button.Text;
            }
        }

        private void resetButton_Clicked(object sender, EventArgs e)
        {
            LabelResult.Text = "0";
            isClickedOperator = false;
            isClickedDecimal = false;
            number1 = 0;
        }

        private void deleteButton_Clicked(object sender, EventArgs e)
        {
            string number = LabelResult.Text;
            char decimalPoint = number[number.Length-1];
            if(number != "0")
            {
                if(decimalPoint == '.')
                {
                   isClickedDecimal = false;
                }
                number = number.Remove(number.Length - 1, 1);
                if (string.IsNullOrEmpty(number))
                {
                    LabelResult.Text = "0";
                }
                else
                {
                    LabelResult.Text = number;
                }
            }
        }

        private void operationButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            isClickedOperator = true;
            operatorName = button.Text;
            isClickedDecimal = false;
            try
            {
                number1 = Convert.ToDecimal(LabelResult.Text);
            }catch
            {
                DisplayAlert("Error", "Syntax Error", "Okay");
            }
        }

        private void equalButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                decimal number2 = Convert.ToDecimal(LabelResult.Text);
                string finalResult = calcuResult(number1, number2).ToString("0.##");
                LabelResult.Text = finalResult;
            }
            catch(Exception ex)
            {
                DisplayAlert("Error", ex.Message, "Okay");
            }
          
        }

        public decimal calcuResult(decimal number1, decimal number2)
        {
            decimal result = 0;
            switch (operatorName)
            {
                case "+": result = number1 + number2; break;
                case "-": result = number1 - number2; break;
                case "x": result = number1 * number2; break;
                case "/": result = number1 / number2; break;
            }
            return result;
        }

        private void decimalButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (isClickedDecimal)
            {
                DisplayAlert("Error", "Can't add another Decimal Point", "Okay");
            }
            else
            {
                LabelResult.Text += button.Text;
                isClickedDecimal = true;
            }

        }
    }
}
