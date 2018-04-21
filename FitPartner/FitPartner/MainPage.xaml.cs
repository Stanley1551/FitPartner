using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitPartner
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            Name = Application.Current.Properties["username"].ToString();
		}

        public MainPage(string name)
        {
            InitializeComponent();
            
            Name = name;
        }

        public string Name { get { return name; } set { if(name == value) return; name = value; nameText.Text = value; } }

        private string name;
	}
}
