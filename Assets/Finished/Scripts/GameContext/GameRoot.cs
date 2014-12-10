using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;

public class GameRoot : ContextView {

	void Start () {
		context = new GameContext(this,false);
		context.Start();
	}
}
