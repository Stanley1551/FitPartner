using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FitPartner.Droid.Database;

namespace FitPartner
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AnalyticsPage : ContentPage
	{
		public AnalyticsPage ()
		{
			InitializeComponent ();
            
            using(DatabaseHandler handler = new DatabaseHandler())
            {
                User user = handler.Db.Get<User>(1);
                double meters = (double) user.Height / 100;
                Bmi = Math.Round(user.Weight / Math.Pow(meters, 2),2);

                BMI.Text = Bmi.ToString();
                if(Bmi >= 40)
                {
                    Resolution.Text = "You are morbidly Obese...";
                }
                else if(Bmi > 35)
                {
                    Resolution.Text = "You are severely Obese!";
                }
                else if(Bmi > 30)
                {
                    Resolution.Text = "You are Obese.";
                }
                else if(Bmi > 25)
                {
                    Resolution.Text = "You are overweight.";
                }
                else if(Bmi > 18.5)
                {
                    Resolution.Text = "You are healthy! :)";
                }
                else Resolution.Text = "You are underweight.";


                Task.Run(async () => BeginFading());
            }
		}

        double Bmi { get; set; }

        private async void BeginFading()
        {
            await BMI.FadeTo(1, 1000);
            await Resolution.FadeTo(1, 1000);
        }
	}
}