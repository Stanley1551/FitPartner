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
    public interface ISimpleEx
    {
        int Reps { get; set; }
        int Quantity { get; set; }
        SimpleExercise SimpleID { get; set; }
    }
}