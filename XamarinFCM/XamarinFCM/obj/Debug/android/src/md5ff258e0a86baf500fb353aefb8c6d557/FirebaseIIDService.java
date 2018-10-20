package md5ff258e0a86baf500fb353aefb8c6d557;


public class FirebaseIIDService
	extends com.google.firebase.iid.FirebaseInstanceIdService
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTokenRefresh:()V:GetOnTokenRefreshHandler\n" +
			"";
		mono.android.Runtime.register ("XamarinFCM.FirebaseIIDService, XamarinFCM", FirebaseIIDService.class, __md_methods);
	}


	public FirebaseIIDService ()
	{
		super ();
		if (getClass () == FirebaseIIDService.class)
			mono.android.TypeManager.Activate ("XamarinFCM.FirebaseIIDService, XamarinFCM", "", this, new java.lang.Object[] {  });
	}


	public void onTokenRefresh ()
	{
		n_onTokenRefresh ();
	}

	private native void n_onTokenRefresh ();

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
