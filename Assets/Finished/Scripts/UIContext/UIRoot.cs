using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;

public class UIRoot : ContextView {

	void Start () {
		context = new UIContext(this,false);
		context.Start();
	}
}
