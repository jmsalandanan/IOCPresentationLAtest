using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class PlayerView : View {
	
	private GameObject bulletPrefab;
	public Signal playerAwake;
	//Add display code here and input checking 
	void Start(){
//		base.Start();
		bulletPrefab = (GameObject)Resources.Load("Prefabs/BulletKunwari") as GameObject;

	}

	void Awake(){
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.LeftControl))
		{
			Fire();
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			MoveLeft();
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			MoveRight();
		}
		if(Input.GetKeyDown(KeyCode.Space)){
			Jump();
		}
	}

	public void Fire(){
		Debug.Log("FIRE");
		Vector3 position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
		Instantiate(bulletPrefab, position, Quaternion.identity);
	}

	public void MoveLeft(){
		transform.Translate(Vector3.left * Time.deltaTime * 10f);
	}

	public void MoveRight(){
		transform.Translate(Vector3.right * Time.deltaTime * 10f);
	}

	public void Jump(){
		rigidbody.AddForce(Vector3.up * 400f);
	}
}