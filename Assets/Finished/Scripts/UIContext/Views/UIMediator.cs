using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

public class UIMediator : Mediator {

	[Inject]
	public UIView uiView {get;set;}

	[Inject]
	public PlayerFiredSignal playerFiredSignal {get;set;}

	public override void PreRegister(){
	}
	public override void OnRegister(){
		base.OnRegister();
		uiView.onFire.AddListener(OnPlayerFired);
	}
	
	public override void OnRemove (){
		uiView.onFire.RemoveListener(OnPlayerFired);
	}

	private void OnPlayerFired(){
		Debug.Log("Fire");
		playerFiredSignal.Dispatch();
	}
}