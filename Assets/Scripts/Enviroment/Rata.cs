using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rata : MonoBehaviour
{


	public float radioPatrullar;
	public Rigidbody2D rigidbody2D;
	public Vector2 posicionAPatrullarA;

	float tiempoPatrullar=0;
	public float duracionPatrullar=1f;
	public float duracionEspera=2;
	float tiempoEspera=2;
	public bool patrullando=false;
	public bool activado=false;
	public bool esperar=false;
	public bool alertado=false;
	bool calcularPuntosPatrulla=false;
	bool irAlPuntoB=false;
	public float radioActivado=20;
	public float radioPatrullando=10;
	public float radioAlertado=5;
	public float tiempoAlerta;
	public float duracionAlerta=1;
	public float distancia;
	public Vector2 velocidad;
	public float rapidez=10;
	GameObject jugador=null;
	Vector2 posicionInicial;
	void Start()
	{
		posicionInicial=this.transform.position;
		jugador=GameObject.FindGameObjectWithTag("Player");
		rigidbody2D=GetComponent<Rigidbody2D>();
		radioPatrullar+=Random.Range(-2,5);
		//duracionEspera+=Random.Range(1,6);
	}
	void OnBecameInvisible()
	{
		Destroy(this);
	}

	// Update is called once per frame
	void Update()
	{

		distancia=Vector2.Distance(this.transform.position,jugador.transform.position);
		if(activado){
			

			if(patrullando&&!esperar){

				/*if(!calcularPuntosPatrulla){
					calcularPuntosPatrulla=true;
					posicionAPatrullarA=posicionInicial+new Vector2(Random.Range(-radioPatrullar,radioPatrullar),Random.Range(-radioPatrullar,radioPatrullar));

				}*/


				if(Vector2.Distance(this.transform.position,posicionAPatrullarA)>1){
					velocidad=-(Vector2)this.transform.position+posicionAPatrullarA;
					rigidbody2D.velocity=velocidad.normalized*rapidez;
				}
				if(Vector2.Distance(this.transform.position,posicionAPatrullarA)<1){
					
					esperar=true;
					tiempoEspera=Time.time+duracionEspera;

				}





			}



		}
	
		if(!activado&&distancia<radioActivado){

			activado=true;

		}

		if(activado&&!alertado&&!patrullando&&distancia<radioPatrullando){

			calcularPuntosPatrulla=false;
			patrullando=true;

		}





		if(rigidbody2D.velocity.x<0){
			this.transform.rotation=Quaternion.Euler(0,180,0);

		}

		if(rigidbody2D.velocity.x>0){
			this.transform.rotation=Quaternion.Euler(0,0,0);

		}
		if(esperar&&Time.time>tiempoEspera){

			esperar=false;
		}
	}
}
