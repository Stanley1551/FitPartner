using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FitPartner.Droid.Database;
using Acr.UserDialogs.Builders;
using Acr.UserDialogs;

namespace FitPartner
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            using(DatabaseHandler dbHandler = new DatabaseHandler())
            {
                User user = dbHandler.Db.Get<User>(1);
                
                Name = user.Username;
                Birthday = user.Birth;
                Height = user.Height;
                Weight = user.Weight;
                if(user.Male != null)
                {
                    GenderPicker.SelectedIndex = (user.Male == true ? 0 : 1);
                }

                Task.Run(async () => await BeginFading());
                RegisterRecognizers();
            }
        }

        

        private string name;
        private DateTime birthday;
        private int height;
        private int weight;
        private bool male;

        public bool Male {
            get { return male; }
            set { if(value == male) return; male = value; }
        }

        public int Weight {
            get { return weight; }
            set { if(value == weight) return; weight = value; weightText.Text = value.ToString(); }
        }
        public int Height {
            get { return height; }
            set { if(value == height) return; height = value; heightText.Text = value.ToString(); }
        }
        public DateTime Birthday {
            get { return birthday; }
            set { if(value == birthday) return; birthday = value; birthdayText.Text = BirthdayToString(birthday); }
        }
        public string Name {
            get { return name; }
            set { if(value == name) return; name = value; nameText.Text = value; }
        }

        async void BirthdayEditButtonOnClick(object sender, EventArgs e)
        {

            DatePromptResult result = await UserDialogs.Instance.DatePromptAsync(new DatePromptConfig { CancelText = "Cancel", Title = "Pick your birthday!", OkText = "OK" });
            if(result.Ok)
            {
                using(DatabaseHandler dbHandler = new DatabaseHandler())
                {
                    int dbRes = dbHandler.Db.Update(new User(1,Name, result.SelectedDate, String.Empty, Height, Weight, Male));
                    Birthday = result.SelectedDate;
                }
            }
        }

        async void HeightEditButtonOnClick(object sender, EventArgs e)
        {
            PromptResult result = await UserDialogs.Instance.PromptAsync("Your current height:","Please set your current height!","OK","Cancel","Ex.: 180",InputType.Number);
            if(result.Ok)
            {
                using(DatabaseHandler dbHandler = new DatabaseHandler())
                {
                    int dbRes = dbHandler.Db.Update(new User(1, Name, Birthday, String.Empty, int.Parse(result.Text), Weight, Male));
                    Height = int.Parse(result.Text.Trim());
                }
            }

        }

        async void WeightEditButtonOnClick(object sender, EventArgs e)
        {
            PromptResult result = await UserDialogs.Instance.PromptAsync("Your current weight:", "Please set your current weight!", "OK", "Cancel", "Ex.: 70", InputType.Number);
            if(result.Ok)
            {
                using(DatabaseHandler dbHandler = new DatabaseHandler())
                {
                    int dbRes = dbHandler.Db.Update(new User(1, Name, Birthday, String.Empty, Height, int.Parse(result.Text), Male));
                    Weight = int.Parse(result.Text.Trim());
                }
            }
        }

        async void genderPicked(object sender, EventArgs e)
        {
            var index = GenderPicker.SelectedIndex;

            using(DatabaseHandler dbHandler = new DatabaseHandler())
            {
                int dbRes = dbHandler.Db.Update(new User(1, Name, Birthday, String.Empty, Height, Weight, index == 1 ? false : true));
            }
        }

        private async Task BeginFading()
        {
            await nameGrid.FadeTo(1, 1000);
            await bdayGrid.FadeTo(1, 1000);
            await heightGrid.FadeTo(1, 1000);
            await weightGrid.FadeTo(1, 1000);
            await GenderPicker.FadeTo(1, 1000);
        }

        private void RegisterRecognizers()
        {
            TapGestureRecognizer bdayTap = new TapGestureRecognizer();
            bdayTap.Tapped += BirthdayEditButtonOnClick;
            bdayEditBtn.GestureRecognizers.Add(bdayTap);

            TapGestureRecognizer heightTap = new TapGestureRecognizer();
            heightTap.Tapped += HeightEditButtonOnClick;
            heightEditBtn.GestureRecognizers.Add(heightTap);

            TapGestureRecognizer weightTap = new TapGestureRecognizer();
            weightTap.Tapped += WeightEditButtonOnClick;
            weightEditBtn.GestureRecognizers.Add(weightTap);
        }
        private string BirthdayToString(DateTime birthday)
        {
            return birthday.Year.ToString() + "." + birthday.Month.ToString() + "." + birthday.Day.ToString();
        }
    }
}