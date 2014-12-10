using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using strange.extensions.context.api;

public class PlayerFiredCommand : Command {

	[Inject(ContextKeys.CONTEXT_VIEW)]
	public GameObject contextView{get;set;}

	[Inject]
	public FireObjectSignal fireObjectSignal {get;set;}
	public override void Execute()
	{
		Debug.Log("Update something on the server or model or whatever");
		fireObjectSignal.Dispatch();
	}
}
