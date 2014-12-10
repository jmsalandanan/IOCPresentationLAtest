using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using strange.extensions.context.api;

public class GameStartCommand : Command {

	[Inject(ContextKeys.CONTEXT_VIEW)]
	public GameObject contextView{get;set;}

	public override void Execute(){
		Debug.Log("Game has started,Instantiating Player");
		GameObject player = GameObject.CreatePrimitive(PrimitiveType.Cube);     
		player.name = "Player";          
		player.AddComponent<PlayerView>();          
		player.transform.parent = contextView.transform;   
	}
}
