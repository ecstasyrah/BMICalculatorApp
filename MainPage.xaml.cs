    using System;
    using Microsoft.Maui.Controls;

    namespace BMICalculatorApp;

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCalculate(object? sender, EventArgs e)
        {
            if (double.TryParse(WeightInput.Text, out double weight) && 
                double.TryParse(HeightInput.Text, out double height))
            {
                if (height <= 0) 
                {
                    await DisplayAlert("Error", "Height must be greater than 0", "OK");
                    return;
                }

                double bmi = weight / (height * height);
                ResultLabel.Text = bmi.ToString("F1");

                if (bmi < 18.5) { CategoryLabel.Text = "Underweight"; CategoryLabel.TextColor = Colors.Blue; }
                else if (bmi < 25) { CategoryLabel.Text = "Normal"; CategoryLabel.TextColor = Colors.Green; }
                else if (bmi < 30) { CategoryLabel.Text = "Overweight"; CategoryLabel.TextColor = Colors.Orange; }
                else { CategoryLabel.Text = "Obese"; CategoryLabel.TextColor = Colors.Red; }
            }
            else
            {
                await DisplayAlert("Invalid Input", "Please enter numbers for weight and height.", "OK");
            }
        }
    }