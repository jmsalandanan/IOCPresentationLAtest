using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;

public class ApplicationRoot : ContextView {
	
	//Every context starts by attaching a ContextView to a GameObject.
	//The main job of this ContextView is to instantiate the Context.
	//Remember, if the GameObject is destroyed, the Context and all your
	//bindings go with it.
	
	//This ContextView has two jobs:
	//1. Provide the Cross-Context dependencies (see TempContext)
	//2. Load the other Contexts (see StartCommand)
	
	void Start () {
		context = new ApplicationContext(this,false);
		context.Start();
	}
	
}
