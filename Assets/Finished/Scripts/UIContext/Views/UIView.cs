using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class UIView : View {

	public Signal onFire;
	
	//Add display code here and input checking 
	void Start(){
		base.Start();

	}

	void Awake(){
		onFire = new Signal();
	}

	void OnGUI() {
		if (GUI.Button(new Rect(10, 10, 150, 100), "Fire"))
			onFire.Dispatch();
	}
}