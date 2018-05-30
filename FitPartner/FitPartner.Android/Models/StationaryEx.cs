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
    public class StationaryEx : IStationaryEx
    {
        private TimeSpan time;
        private int reps;
        private StationaryExcercise stationaryID;

        public TimeSpan Time { get { return time; } set { if (value != time) time = value; } }
        public int Reps { get { return reps; } set { if(value != reps) reps = value; } }
        public StationaryExcercise StatID { get { return stationaryID; } set {if(value != stationaryID) stationaryID = value; } }
    }
}