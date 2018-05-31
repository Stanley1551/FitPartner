using Android.Net;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Android.Content.PM;
using Android.Content;
using SQLite;
using System.IO;
using FitPartner.Droid.Database;

namespace FitPartner
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        public LoginPage()
        {
            InitializeComponent();
            BackgroundImage = "login_bg.png";
            Title = "FitPartner";
            Task.Run(async () => await BeginFading());

            var tapImage = new TapGestureRecognizer();
            tapImage.Tapped += FacebookLoginButtonOnClick;

            fbLoginButton.GestureRecognizers.Add(tapImage);
        }

        private async Task BeginFading()
        {
            await welcomeLabel.FadeTo(1, 1500);
            await typeNameLabel.FadeTo(1, 1500);
            await nameField.FadeTo(1, 1500);
        }

        private void OnCompleted(object sender, EventArgs e)
        {
            string name = nameField.Text;

            Application.Current.Properties["username"] = name;

            InitializeDB();

            Navigation.PushAsync(new MainPage(name));

            FlushNavigationStack();
            
        }

        async void FacebookLoginButtonOnClick(object sender, EventArgs e)
        {
            if(CheckConnection())
            {
                //await Navigation.PushAsync(new WebPage());
                await this.Navigation.PushAsync(new WebPage("https://www.facebook.com/v2.12/dialog/oauth?client_id=214187729343795&response_type=token&redirect_uri=https://www.facebook.com/connect/login_success.html"));
                FlushNavigationStack();
            }
            else
            {
                var resp = await DisplayAlert("Alert", "No internet connection detected!","OK","Open WiFi settings...");

                if (resp == false)
                {
                    Forms.Context.StartActivity(new Intent(Android.Provider.Settings.ActionWifiSettings));
                }
                
            }
        }

        private bool CheckConnection()
        {
            return CrossConnectivity.Current.IsConnected;
        }

        private void FlushNavigationStack()
        {
            Navigation.RemovePage(Navigation.NavigationStack.FirstOrDefault());
        }

        private void InitializeDB()
        {
            using(DatabaseHandler dbHandler = new DatabaseHandler())
            {
                dbHandler.Db.CreateTable<User>();
                dbHandler.Db.Insert(new User(1,Application.Current.Properties["username"].ToString(), DateTime.MinValue,String.Empty,0,0,null));
            }
        }
    }
}