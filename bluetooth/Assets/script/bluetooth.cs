using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bluetooth : MonoBehaviour {

	AndroidJavaClass UnityPlayer;
	AndroidJavaObject currentActivity;
	AndroidJavaObject context;

	string toastString;

	// Use this for initialization
	void Start () {

		if (Application.platform == RuntimePlatform.Android)
	        {
	            UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
	            currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
	            context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
	        }
	    
	    //openBlueTooth();
	    currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(openBlueTooth));
	    this.toastString = "Open BlueTooth";
	    this.showToast();
	    //this.openBlueTooth();
	    currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(showToast));
	    

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void openBlueTooth(){
		AndroidJavaClass bluetoothAdapt = new AndroidJavaClass("android.bluetooth.BluetoothAdapter");
		AndroidJavaObject default_adapt = bluetoothAdapt.CallStatic<AndroidJavaObject>("getDefaultAdapter");

		this.toastString = string.Concat("BT Status:", default_adapt.Call<bool>("isEnabled").ToString());
	    this.showToast();
		
		if(default_adapt.Call<bool>("isEnabled") == false){
			default_adapt.Call<bool>("enable");
			this.toastString = "BT Enable";
	   		this.showToast();
		}
	}

	void showToast(){

		AndroidJavaClass Toast = new AndroidJavaClass("android.widget.Toast");
		AndroidJavaObject javaString = new AndroidJavaObject("java.lang.String", toastString);
		AndroidJavaObject toast = Toast.CallStatic<AndroidJavaObject>("makeText", context, javaString, Toast.GetStatic<int>("LENGTH_SHORT"));
		toast.Call("show");

	}
}
