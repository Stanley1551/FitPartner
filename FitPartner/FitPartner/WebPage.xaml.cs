using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitPartner
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WebPage : ContentPage
	{
		public WebPage ()
		{
			InitializeComponent();
            //WebView webView = new WebView() { Source = "https://www.facebook.com/v2.12/dialog/oauth?client_id=214187729343795&redirect_uri=https://www.facebook.com/connect/login_success.html&response_type=token" };

            //Content = webView;


		}

        public WebPage(string url)
        {
            Url = url;
            InitializeComponent();

            WebView webView = new WebView() { Source = url };

            Content = webView;

            webView.Navigated += WebViewOnNavigated;
        }

        private async void WebViewOnNavigated(object sender, WebNavigatedEventArgs e)
        {
            var token = ExtractAccessToken(e.Url);

            if(token != null && token != "")
            {
                await GetProfileInfoAsync(token);
            }
        }

        private string ExtractAccessToken(string url)
        {
            if(url.Contains("access_token") && url.Contains("&expires_in"))
            {
                var at = url.Replace("https://www.facebook.com/connect/login_success.html#access_token=", "");

                var token = at.Remove(at.IndexOf("&expires_in="));

                return token;
            }

            return string.Empty;
        }

        private async Task GetProfileInfoAsync(string token)
        {
            var requestUrl = "https://graph.facebook.com/v2.7/me/" + "?fields=name" + "&access_token=" + token;

            var httpClient = new HttpClient();

            var userJson = await httpClient.GetStringAsync(requestUrl);

            httpClient.Dispose();

            JToken jToken = JToken.Parse(userJson);

            var name = jToken["name"];

            //await Navigation.PopAsync(); Navigation.

            Application.Current.Properties.Add("username",(string) name);

            await Navigation.PushAsync(new MainPage());
        }

        private string url;

        public string Url { get { return url; } set { if(value == url) return; url = value; } }

	}
}