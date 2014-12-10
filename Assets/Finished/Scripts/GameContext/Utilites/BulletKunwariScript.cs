using UnityEngine;
using System.Collections;

public class BulletKunwariScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(transform.forward * Time.deltaTime * 20f) ;
	}
}
