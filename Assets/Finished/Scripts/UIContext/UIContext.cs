using UnityEngine;
using System.Collections;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;

public class UIContext : MVCSContext {

	public UIContext () : base()
	{
	}
	
	public UIContext (MonoBehaviour view, bool autoStartup) : base(view, autoStartup)
	{
	}

	protected override void addCoreComponents()
	{
		base.addCoreComponents();
		injectionBinder.Unbind<ICommandBinder>();
		injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
	}
	
	override public IContext Start()
	{
		base.Start();
		UIStartSignal startSignal = (UIStartSignal)injectionBinder.GetInstance<UIStartSignal>();
		startSignal.Dispatch();
		return this;
	}
	
	protected override void mapBindings()
	{
		//Hack for getting monobehaviours
		mediationBinder.Bind<UIView>().To<UIMediator>();
		commandBinder.Bind<UIStartSignal>().To<UIStartCommand>().Once ();
		
	}
	
}
