using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

public class PlayerMediator : Mediator {

	[Inject]
	public PlayerView playerView {get;set;}

	[Inject]
	public FireObjectSignal fireObjectSignal {get;set;}

	public override void PreRegister(){
		Debug.Log("Pre Register");
	}
	public override void OnRegister(){
		base.OnRegister();
		Debug.Log("On Register");
		fireObjectSignal.AddListener(FireObject);
	}
	
	public override void OnRemove (){
		Debug.Log("On Remove");
	}

	private void FireObject(){
		Debug.Log("Fire Object");
		playerView.Fire();
	}
}