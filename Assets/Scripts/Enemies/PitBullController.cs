using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitBullController : MonoBehaviour
{
	public GameObject alerta;
	public float radioPatrullar;
	public Rigidbody2D rigidbody2D;
	public Vector2 posicionAPatrullarA;
	public Vector2 posicionAPatrullarB;
	float tiempoPatrullar=0;
	public float duracionPatrullar=1f;
	public float duracionEspera=2;
	float tiempoEspera=2;
	public bool patrullando=false;
	public bool activado=false;
	public bool esperar=false;
	public bool alertado=false;
	public bool persiguiendo=false;
	bool calcularPuntosPatrulla=false;
	bool irAlPuntoB=false;
	public float radioActivado=20;
	public float radioPatrullando=10;
	public float radioAlertado=5;
	public float radioPerseguir=2;
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

    }
	 void OnCollisionEnter2D(Collision2D col)
    {
      if(persiguiendo&&col.gameObject.tag=="Player"){
			Debug.Log("te alcance");
		  col.gameObject.SendMessage("Matar");
		  
	  }
    }
	
	
    // Update is called once per frame
    void Update()
    {

		distancia=Vector2.Distance(this.transform.position,jugador.transform.position);
		if(activado){
			if(alertado){
				persiguiendo=true;

			}
			if(persiguiendo){
				velocidad=-(Vector2)this.transform.position+(Vector2)jugador.transform.position;
				rigidbody2D.velocity=velocidad.normalized*rapidez;


			}
			if(patrullando&&!esperar){

				if(!calcularPuntosPatrulla){
					calcularPuntosPatrulla=true;
					posicionAPatrullarA=posicionInicial+new Vector2(Random.Range(-radioPatrullar,radioPatrullar),Random.Range(-radioPatrullar,radioPatrullar));
					posicionAPatrullarB=posicionInicial+new Vector2(Random.Range(-radioPatrullar,radioPatrullar),Random.Range(-radioPatrullar,radioPatrullar));

				}

				if(irAlPuntoB&&Vector2.Distance(this.transform.position,posicionAPatrullarB)>1){
					velocidad=-(Vector2)this.transform.position+posicionAPatrullarB;
					rigidbody2D.velocity=velocidad.normalized*rapidez;
				}
				if(irAlPuntoB&&Vector2.Distance(this.transform.position,posicionAPatrullarB)<1){
					irAlPuntoB=false;
					esperar=true;
					tiempoEspera=Time.time+duracionEspera;
					if(Random.Range(-10,10)<0){
						calcularPuntosPatrulla=false;

					}
				}
				if(!irAlPuntoB&&Vector2.Distance(this.transform.position,posicionAPatrullarA)>1){
					velocidad=-(Vector2)this.transform.position+posicionAPatrullarA;
					rigidbody2D.velocity=velocidad.normalized*rapidez;
				}
				if(!irAlPuntoB&&Vector2.Distance(this.transform.position,posicionAPatrullarA)<1){
					irAlPuntoB=true;
					esperar=true;
					tiempoEspera=Time.time+duracionEspera;
					if(Random.Range(-10,10)<0){
						calcularPuntosPatrulla=false;

					}
				}





			}



		}
		alerta.SetActive(alertado);
		if(!activado&&distancia<radioActivado){

			activado=true;

		}

		if(activado&&!alertado&&!persiguiendo&&!patrullando&&distancia<radioPatrullando){
			
			calcularPuntosPatrulla=false;
			patrullando=true;

		}

	
		if(alertado&&tiempoAlerta<Time.time){
			alertado=false;

		}
		if(activado&&!alertado&&!persiguiendo&&!alertado&&distancia<radioAlertado){
			patrullando=false;
			alertado=true;
			tiempoAlerta=Time.time+duracionAlerta;
		}


		if(activado&&alertado&&!persiguiendo&&!persiguiendo&&distancia<radioPerseguir){
			patrullando=false;
			persiguiendo=true;
			alertado=true;
			tiempoAlerta=Time.time+duracionAlerta;

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
