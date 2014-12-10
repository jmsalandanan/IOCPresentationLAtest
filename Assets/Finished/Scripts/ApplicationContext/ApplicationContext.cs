using UnityEngine;
using System.Collections;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;

public class ApplicationContext : MVCSContext {
	
	//Write in all the Cross-Context and non Cross-Context bindings
	//Preferably all cross contexts would be written at the main class
	//**This has been set up to use signals instead of events (Signals have type safety)
	public ApplicationContext () : base()
	{
	}
	
	public ApplicationContext (MonoBehaviour view, bool autoStartup) : base(view, autoStartup)
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
		ApplicationStartSignal startSignal = (ApplicationStartSignal)injectionBinder.GetInstance<ApplicationStartSignal>();
		startSignal.Dispatch();
		
		return this;
	}
	
	protected override void mapBindings()
	{
		//Hack for getting monobehaviours
		SceneManager sceneManager = GameObject.Find("Manager").GetComponent<SceneManager>();
		injectionBinder.Bind<SceneManager> ().ToValue(sceneManager).ToSingleton().CrossContext ();
		injectionBinder.Bind<PlayerFiredSignal>().ToSingleton().CrossContext();

		commandBinder.Bind<ApplicationStartSignal>().To<ApplicationStartCommand>().Once ();
	}
}