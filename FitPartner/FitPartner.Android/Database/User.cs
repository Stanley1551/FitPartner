using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FitPartner.Droid.Database
{
    public sealed class User
    {
        public User()
        { }

        public User(string username, DateTime birth)
        {
            Username = username;
            Birth = birth;
            Age = Birth == DateTime.MinValue ? int.MinValue : (int)(DateTime.Now - birth).TotalDays / 365;
        }

        public User(string username, DateTime birth, string email)
        {
            Username = username;
            Birth = birth;
            Age = Birth == DateTime.MinValue ? int.MinValue : (int)(DateTime.Now - birth).TotalDays / 365;
            Email = email;
        }
        public int ID { get; set; }
        public string Username { get; set; }

        public DateTime Birth { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }
    }
}