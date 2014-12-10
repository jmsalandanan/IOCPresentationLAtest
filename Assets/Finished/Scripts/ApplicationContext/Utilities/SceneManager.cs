using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour{
	
	private static SceneManager _sharedInstance = null;
	public static SceneManager Instance {
		get {
			if(_sharedInstance == null)
				_sharedInstance = (SceneManager)GameObject.FindObjectOfType(typeof(SceneManager));
			return _sharedInstance;
		}
	}
	
	public void LoadScene(string sceneName) {
		if (!string.IsNullOrEmpty (sceneName)) {
			Application.LoadLevelAdditive (sceneName);
		}
	}
	
}	
