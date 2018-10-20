This is a Xamarin Android project where the goal was to implemented some back-end to an application, in this case
in the form of cloud messaging service provided by Google Firebase.

Based on the exercise/tutorial here: https://docs.microsoft.com/en-us/xamarin/android/data-cloud/google-messaging/remote-notifications-with-fcm?tabs=windows

Firebase: https://firebase.google.com/

For security & safety reasons the uploaded commit for remote repositories does not contain direct references to original API 
keys used to run the application.

Thus, if you wish to download and try this material yourself, perform the following steps to get started
(or refer to the original exercise/tutorial material);

1. Create you own Firebase Cloud Messaging project at Firebase Console and save the resulting "google-services.json" 
   file to your project root
   
2. Include the file to your project and remember to set it's build action to "GoogleServicesJson".

3. Within "AndroidManifest.xml" <intent-filter> section, change the name in <category> to ${applicationID}.
   
