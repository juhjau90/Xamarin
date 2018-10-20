using System;
using Android.App;
using Firebase.Iid;
using Android.Util;

namespace XamarinFCM
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class FirebaseIIDService : FirebaseInstanceIdService
    {
        const string TAG = "FirebaseIIDService";

        public override void OnTokenRefresh()
        {
            var rfsToken = FirebaseInstanceId.Instance.Token;
            Log.Debug(TAG, "Refreshed token: " + rfsToken);
            SendRegistrationToServer(rfsToken);
            SendRegistrationToAppServer(rfsToken);
        }

        void SendRegistrationToServer(string token)
        {

        }

        void SendRegistrationToAppServer(string token)
        {

        }
    }
}