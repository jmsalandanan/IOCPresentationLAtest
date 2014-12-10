using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using strange.extensions.context.api;

public class ApplicationStartCommand : Command {
	
	//Add commands at execute method
	//Commands get destroyed after execute is done - You can also add Retain() for it to not be destroyed but 
	//make sure to call Release() after
	[Inject(ContextKeys.CONTEXT_VIEW)]
	public GameObject contextView{get;set;}

	[Inject]
	public SceneManager sceneManager {get;set;}
	
	
	public override void Execute()
	{
		//Bootstrapping phase
		//preferably push loading screen here
		sceneManager.LoadScene("UIScene");
		sceneManager.LoadScene("GameScene");
	}
}