using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodeP : MonoBehaviour {
	private int velocidad = 6, CoorX, CoorZ, vida = 2;
	private Rigidbody rb;
	private AudioSource golpe;
	public GameObject capsulaNueva;
	// Use this for initialization
	void Start () {
		rb=GetComponent<Rigidbody> ();
		golpe = GetComponent<AudioSource> ();
		CoorX = Random.Range (0, 2);
		if (CoorX == 0)
			CoorX = -1;
		CoorZ = Random.Range (0, 2);
		if (CoorZ == 0)
			CoorZ = 1;
		rb.velocity = new Vector3 (velocidad * CoorX, 0, velocidad * CoorZ);
	}//fin del start
	
	// Update is called once per frame
	void Update () {
		
	}//fin del update

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "bala") {
			vida--;
			golpe.Play ();
			Destroy (col.gameObject);
			if (vida == 0) {
				GameObject clonCapsula = Instantiate (capsulaNueva, transform.position, transform.rotation) as GameObject;
				Destroy (gameObject);
			}
		}
	}// fin del OnCollisionEnter
}
