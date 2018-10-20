using System;
using Xamarin.Forms;

namespace Phoneword
{
    /*This class sets the functionality behind the opening page interface.
     Tällä luokalla määritellään aloitussivun käyttöliittymän toiminnot.*/
	public partial class MainPage : ContentPage
	{
        string traPhnmb;

		public MainPage()
		{
			InitializeComponent();
		}

        void OnTranslate(object sdr, EventArgs e)
        {
            traPhnmb = PhonewordTranslator.ToNumber(phoneNumberText.Text);

            /*If something is translated to number, the call button becomes available to use.
             Jos jotain on käännetty numeroksi, "call" painike on käytettävissä.*/
            if (!string.IsNullOrWhiteSpace(traPhnmb))
            {
                callButton.IsEnabled = true;
                callButton.Text = "Call " + traPhnmb;
            }
            else
            {
                callButton.IsEnabled = false;
                callButton.Text = "Call";
            }
        }

        /*If call button is pressed, display confirmation dialog. Upon calling, save number to Call History collection.
         Jos "call" painiketta painetaan, tuodaan esiin vahvistus dialogi. Soiton tapahtuessa numero tallentuu soittohistoria kokoelmaan.*/
        async void OnCall(object sdr, EventArgs e)
        {
            if (await this.DisplayAlert(
                "Dial a Number",
                "Would you like to call " + traPhnmb + "?",
                "Yes",
                "No"))
            {
                var dialer = DependencyService.Get<IDialer>();

                if (dialer != null)
                    App.PhoneNumbers.Add(traPhnmb);
                    callHistoryButton.IsEnabled = true;
                    dialer.Dial(traPhnmb);
            }
        }

        async void OnCallHistory(object sdr, EventArgs e)
        {
            await Navigation.PushAsync (new CallHistoryPage());
        }
	}
}
