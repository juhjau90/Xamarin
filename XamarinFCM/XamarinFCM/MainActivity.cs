using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Gms.Common;
using Firebase.Messaging;
using Firebase.Iid;
using Android.Util;

namespace XamarinFCM
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        static readonly string TAG = "MainActivity";

        internal static readonly string CHANNEL_ID = "notification_channel";
        internal static readonly int NOTIFICATION_ID = 100;

        TextView msgText;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_main);
            msgText = FindViewById<TextView>(Resource.Id.msgText);

            if(Intent.Extras != null)
            {
                foreach (var key in Intent.Extras.KeySet())
                {
                    var value = Intent.Extras.GetString(key);
                    Log.Debug(TAG, "Key: {0} Value: {1}", key, value);
                }
            }

            ArePlayServicesReachable();

            CreateNotificationChannel();

            var logTokenButton = FindViewById<Button>(Resource.Id.logTokenButton);

            logTokenButton.Click += delegate {
                Log.Debug(TAG, "InstanceID token: " + FirebaseInstanceId.Instance.Token);
            };

            var subscribeButton = FindViewById<Button>(Resource.Id.subscribeButton);

            subscribeButton.Click += delegate {
                FirebaseMessaging.Instance.SubscribeToTopic("news");
                Log.Debug(TAG, "Subscribed to remote notifications.");
            };

            var unsubscribeButton = FindViewById<Button>(Resource.Id.unsubscribeButton);

            unsubscribeButton.Click += delegate {
                FirebaseMessaging.Instance.UnsubscribeFromTopic("news");
                Log.Debug(TAG, "Unsubscribed from remote notifications.");
            };
        }

        /*Method that is used to check if Google Play Services are even accesible.
         Including method like this is recomended for any service utilizing Google Play Services or something tied to them.*/
        public bool ArePlayServicesReachable()
        {
            int rstCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);

            if (rstCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(rstCode))
                    msgText.Text = GoogleApiAvailability.Instance.GetErrorString(rstCode);
                else
                {
                    msgText.Text = "This device is not supported. Google Play Services are unavailable.";
                    Finish();
                }
                return false;
            }
            else
            {
                msgText.Text = "Google Play Services are available.";
                return true;
            }
        }

        /*Android APIs at 26 and forward (Android 8.0) must use folloeing method to push their notification messages.*/
        void CreateNotificationChannel()
        {
            /*If Android API is older then 26, do not create anything.*/
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                return;
            }

            var chn = new NotificationChannel(CHANNEL_ID, "FCM Notifications", NotificationImportance.Default)
            {
                Description = "Channel used by Firebase Cloud Messages."
            };

            var notificationMng = (NotificationManager)GetSystemService(Android.Content.Context.NotificationService);

            notificationMng.CreateNotificationChannel(chn);

        }
    }
}

