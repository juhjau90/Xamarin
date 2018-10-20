using System;
using Android.App;
using Android.Content;
using Android.Media;
using Android.Util;
using Firebase.Messaging;
using XamarinFCM;
using System.Collections.Generic;
using Android.Support.V4.App;

namespace XamarinFCM
{
    [Service]
    [IntentFilter(new [] { "com.google.firebase.MESSAGING_EVENT" })]
    public class OwnFirebaseMessagingService : FirebaseMessagingService
    {
        const string TAG = "OwnFirebaseMessagingService";

        public override void OnMessageReceived(RemoteMessage message)
        {
            Log.Debug(TAG, "From: " + message.From);

            var body = message.GetNotification().Body;
            Log.Debug(TAG, "Notification Message Body: " + message.GetNotification().Body);

            SendNotification(body, message.Data);
        }

        void SendNotification(string msgBody, IDictionary<string, string> dt)
        {
            var intent = new Intent(this, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTop);

            foreach (var key in dt.Keys)
            {
                intent.PutExtra(key, dt[key]);
            }

            var pendingIntent = PendingIntent.GetActivity(this, MainActivity.NOTIFICATION_ID, intent, PendingIntentFlags.OneShot);

            var notificationBuilder = new NotificationCompat.Builder(this, MainActivity.CHANNEL_ID)
                .SetSmallIcon(Resource.Drawable.abc_action_bar_item_background_material) //Small icon is required. otherwisely an exception error is thrown.
                .SetContentTitle("FCM Message")
                .SetContentText(msgBody)
                .SetAutoCancel(true)
                .SetContentIntent(pendingIntent);

            var notificationMng = NotificationManagerCompat.From(this);

            notificationMng.Notify(MainActivity.NOTIFICATION_ID, notificationBuilder.Build());
        }
    }
}