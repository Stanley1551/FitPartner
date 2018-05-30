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

namespace FitPartner.Droid.Models
{
    public class RunEx
    {
        public double Distance { get; set; }
        public TimeSpan Time { get; set; }
        public bool Treadmill { get; set; }
    }
}