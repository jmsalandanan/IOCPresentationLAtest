using UnityEngine;
using System.Collections;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;

public class GameContext : MVCSContext {

	public GameContext () : base()
	{
	}
	
	public GameContext (MonoBehaviour view, bool autoStartup) : base(view, autoStartup)
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
		GameStartSignal startSignal = (GameStartSignal)injectionBinder.GetInstance<GameStartSignal>();
		startSignal.Dispatch();
		return this;
	}
	
	protected override void mapBindings()
	{
		//Hack for getting monobehaviours
		injectionBinder.Bind<FireObjectSignal>().ToSingleton();
		mediationBinder.Bind<PlayerView>().To<PlayerMediator>();
		commandBinder.Bind<GameStartSignal>().To<GameStartCommand>().Once ();
		commandBinder.Bind<PlayerFiredSignal>().To<PlayerFiredCommand>();
	}
	
}
