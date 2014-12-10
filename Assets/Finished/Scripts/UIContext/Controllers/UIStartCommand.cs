using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using strange.extensions.context.api;

public class UIStartCommand : Command {

	[Inject(ContextKeys.CONTEXT_VIEW)]
	public GameObject contextView{get;set;}

	public override void Execute(){
		Debug.Log("Game has started,Instantiating Player");
		GameObject ui = new GameObject();
		ui.name = "Player";          
		ui.AddComponent<UIView>();          
		ui.transform.parent = contextView.transform;   
	}
}
