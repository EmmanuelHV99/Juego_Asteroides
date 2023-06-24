using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (0, 0, 4) * Time.deltaTime);
		//Destruir la bala despues de 2 segundos de invocarla
		Destroy(gameObject,2);
	}
}
