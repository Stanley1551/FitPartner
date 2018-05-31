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
using FitPartner.Droid.Enums;

namespace FitPartner.Droid.Models
{
    interface IStationaryEx
    {
        TimeSpan Time { get; set; }
        int Reps { get; set; }
        StationaryExercise StatID { get; set; }

    }
}