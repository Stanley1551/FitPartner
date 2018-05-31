using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using FitPartner.Droid.Database;
using Acr.UserDialogs;

namespace FitPartner
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            BackgroundImage = "menu_bg.png";
            Name = Application.Current.Properties["username"].ToString();
		}

        public MainPage(string name)
        {
            InitializeComponent();
            
            Name = name;
        }

        public string Name { get { return name; } set { if(name == value) return; name = value; nameText.Text = value; } }

        private string name;

        private void VidTrainerButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VideoPlayerPage());
        }

        private void ProfileButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProfilePage());
        }

        private void StatButtonClicked(object sender, EventArgs e)
        {
            using(DatabaseHandler dbHandler = new DatabaseHandler())
            {
                User user = dbHandler.Db.Get<User>(1);
                if (user.Birth == null || user.Birth == DateTime.MinValue
                    || user.Height <= 0
                    || user.Weight <= 0)
                {
                    Task.Run(async () => await UserDialogs.Instance.AlertAsync("Mandatory fields are missing! Please fill your data on \"My profile\" page.", "Warning", "OK")); 
                    
                    return;
                }
            }
            Navigation.PushAsync(new AnalyticsPage());
        }
    }
}
