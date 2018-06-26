using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class toast : MonoBehaviour {

	AndroidJavaClass UnityPlayer;
	AndroidJavaObject currentActivity;
	AndroidJavaObject context;

	string toastString;

  
	void Start ()
	{

	    if (Application.platform == RuntimePlatform.Android)
	        {
	            UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
	            currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
	            context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
	        }

	        this.toastString = "Hello Unity!";
	        currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(showToast));
	    }
	  
	void showToast()
	    {
	        AndroidJavaClass Toast = new AndroidJavaClass("android.widget.Toast");
	        AndroidJavaObject javaString = new AndroidJavaObject("java.lang.String", toastString);
	        AndroidJavaObject toast = Toast.CallStatic<AndroidJavaObject>("makeText", context, javaString, Toast.GetStatic<int>("LENGTH_SHORT"));
	        toast.Call("show");
	    }

}