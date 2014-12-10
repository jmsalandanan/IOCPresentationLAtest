using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class PlayerView : View {
	
	private GameObject bulletPrefab;
	//Add display code here and input checking 
	void Start(){
		base.Start();
		bulletPrefab = (GameObject)Resources.Load("Prefabs/BulletKunwari") as GameObject;
	}

	void Awake(){


	}

	public void Fire(){
		Debug.Log("FIRE");
		Vector3 position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
		Instantiate(bulletPrefab, position, Quaternion.identity);
	}
}