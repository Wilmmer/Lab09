using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab09
{
    [Activity(Label = "Lab09", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
             SetContentView (Resource.Layout.Main);
            Validate();
        }
        private async void Validate()
        {
            var ServiceClient = new SALLab09.ServiceClient();
            string StudentEmail = "wilmmer_052@live.com.mx";
            string Password = "6fgyf0";
            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            var Result = await ServiceClient.ValidateAsync(StudentEmail, Password, myDevice);
            string NameUserTextView = $"{Result.Fullname}";
            string StatusTextView = $"{Result.Status}";
            string TokenTextView = $"{Result.Token}";

            FindViewById<TextView>(Resource.Id.UserNameValue).Text = NameUserTextView;
            FindViewById<TextView>(Resource.Id.StatusValue).Text = StatusTextView;
            FindViewById<TextView>(Resource.Id.TokenValue).Text = TokenTextView;

        }
    }
}

