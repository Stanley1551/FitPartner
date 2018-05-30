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
    class SimpleEx : ISimpleEx
    {
        private int reps;
        private int quantity;
        private SimpleExcercise simpleID;

        public int Reps {
            get {
                return reps;
            }
            set {
                if (value != reps)
                {
                    reps = value;
                }
            }
        }
        public int Quantity {
            get {
                return quantity;
            }
            set {
                if (value != quantity)
                    quantity = value;
            }
        }
        public SimpleExcercise SimpleID {
            get {
                return simpleID;
            }
            set {
                if (value != simpleID)
                    simpleID = value;
            }
        }
    }
}