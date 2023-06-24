using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour {
	public GameObject balaNueva;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Disparar con la barra espaciadora
		if (Input.GetKeyDown (KeyCode.Space)|ControlDisparo.disparoVirtual&Input.GetMouseButtonDown(0)) {
			GameObject clonBala = Instantiate (balaNueva, transform.position, transform.rotation);
		}//Fin del disparo con espacio
		//Disparar con la barra espaciadora
	}
}
