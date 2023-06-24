using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Nave : MonoBehaviour {
	private int vel = 3,giro= 150, contador = 0, total, nivelActual;
	public Text tContador, tVida;
	public Slider bVida;
	private AudioSource[] sonidos;
	public Button bInicio, bJugar, bAvanzar;

	// Use this for initialization
	void Start () {
		sonidos = GetComponents<AudioSource> ();
		//Ocultar botones de control de escena
		bInicio.gameObject.SetActive(false);
		bJugar.gameObject.SetActive(false);
		bAvanzar.gameObject.SetActive(false);
		//Determinar el nivel en el que estamos de acuerdo el indice del contructor
		nivelActual=SceneManager.GetActiveScene().buildIndex;
		//definir el total de capsulas a recolectar de acuerdo al nivel
		switch (nivelActual) {
		case 1:
			total = 6;
			break;
		case 2:
			total = 13;
			break;
		case 3:
			total = 20;
			break;
		}//fin del switch
	}//fin de start
	
	// Update is called once per frame
	void Update () {
		//Mover nave hacia adelante
		if (Input.GetKey(KeyCode.W)) {
			transform.Translate (new Vector3 (0, -vel, 0) * Time.deltaTime);
		}
		//Mover nave hacia atras
		if (Input.GetKey(KeyCode.S)) {
			transform.Translate (new Vector3 (0, vel, 0) * Time.deltaTime);
		}
		//Mover nave hacia izquierda
		if (Input.GetKey(KeyCode.A)) {
			transform.Rotate (new Vector3 (0, 0, -giro) * Time.deltaTime);
		}
		//Mover nave hacia derecha
		if (Input.GetKey(KeyCode.D)) {
			transform.Rotate (new Vector3 (0, 0, giro) * Time.deltaTime);
		}
		ControlNaveVirtual ();

	}//Fin del update

	void ControlNaveVirtual(){
		//Verificar si el control virtual se mueve hacia arriba o abajo
		if(ControlVirtual.inputVector.z!=0){
			transform.Translate (new Vector3 (0, -ControlVirtual.inputVector.z*vel, 0) * Time.deltaTime);
		}
		//Verificar si el control virtual se mueve hacia izquierda o derecha
		if(ControlVirtual.inputVector.x!=0){
			transform.Rotate (new Vector3 (0, 0,ControlVirtual.inputVector.x*giro) * Time.deltaTime);
		}
	}//Fin de ControlnaveVirtual

	void OnTriggerEnter(Collider trig){
		if (trig.tag == "capsula") {
			sonidos [0].Play ();
			contador++;
			tContador.text = "" + contador;
			bVida.value += 5;
			tVida.text = "" + bVida.value + "%";
			Destroy (trig.gameObject);
			if (contador == total) {
				//mostrar botones al completar el nivel
				bInicio.gameObject.SetActive(true);
				bJugar.gameObject.SetActive(true);
				bAvanzar.gameObject.SetActive(true);
			}//fin de contador = total
		}//fin de recolectar capsula
	}
	void OnCollisionEnter(Collision col){
		//Golpe de asteriode chico
		if(col.gameObject.tag=="asteroideP"){
			bVida.value-=5;
			sonidos[1].Play();
		}
		//golpe de asteroide mediano
		if(col.gameObject.tag=="asteroideM"){
			bVida.value-=10;
			sonidos[1].Play();
		}
		//golpe de asteriode grande
		if(col.gameObject.tag=="asteroideG"){
			bVida.value-=20;
			sonidos[1].Play();
		}
		tVida.text = "" + bVida.value + "%";
		//Validar si la vida llega a 0
		if (bVida.value == 0) {
			SceneManager.LoadScene (nivelActual);
		}
	}
}//Fin del codigo
