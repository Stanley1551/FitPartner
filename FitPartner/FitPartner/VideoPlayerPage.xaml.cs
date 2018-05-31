using Octane.Xamarin.Forms.VideoPlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Acr.UserDialogs;
using Octane.Xamarin.Forms.VideoPlayer.Constants;

namespace FitPartner
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VideoPlayerPage : ContentPage
	{
		public VideoPlayerPage ()
		{
			InitializeComponent ();
            index = 0;
            Player.Source = VideoSource.FromResource(Queue[index]);


            SubscribeEvents();
            
        }

        private void SubscribeEvents()
        {
            Player.Failed += async (sender, e) => { await UserDialogs.Instance.AlertAsync("Video failed to load...", "Error", "OK"); };

            Player.PlayerStateChanged += (sender, args) =>
            {
                switch(args.CurrentState)
                {
                    case PlayerState.Initialized:
                        ExerciseTitle.Text = (index+1) +". " + Queue[index].Replace(".mp4", "");
                        break;
                    case PlayerState.Prepared:
                        Player.Play(); 
                        break;
                    case PlayerState.Completed:
                        if(index >= Queue.Length-1) index = -1;
                        Player.Source = VideoSource.FromResource(Queue[++index]);
                        break;
                    case PlayerState.Error:
                        DisplayAlert("Error Playing Video", "We're sorry but something is wrong with this video.", "OK");
                        break;
                }
            };
        }

        private string[] Queue = { "LegRaise.mp4", "MountainClimer.mp4", "Plank.mp4", "Pushup.mp4", "Sideplank.mp4", "Situp.mp4" };
        private int index;

    }
}