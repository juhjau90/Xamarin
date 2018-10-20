using Android.Content;
using Android.Telephony;
using Phoneword.Droid;
using System.Linq;
using Xamarin.Forms;
using Uri = Android.Net.Uri;

[assembly: Dependency(typeof(PhoneDialer))]
namespace Phoneword.Droid
{
    public class PhoneDialer : IDialer
    {
        public bool Dial (string nmr)
        {
            var ctx = MainActivity.Instance;

            if (ctx == null)
                return false;

            var itt = new Intent (Intent.ActionDial);
            itt.SetData(Uri.Parse ("tel:" + nmr));

            if (IsIntentAvailable(ctx, itt)) {
                ctx.StartActivity(itt);
                return true;
            }

            return false;
        }

        public static bool IsIntentAvailable(Context ctx, Intent itt)
        {
            var pkcMng = ctx.PackageManager;

            var lst = pkcMng.QueryIntentServices(itt, 0)
                .Union(pkcMng.QueryIntentActivities(itt, 0));

            if (lst.Any())
                return true;

            var mng = TelephonyManager.FromContext(ctx);
            return mng.PhoneType != PhoneType.None;
        }
    }
}