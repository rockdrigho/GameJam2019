using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaJugador : MonoBehaviour
{
	public GameObject explosion;
	public GameObject spriteJugador;
    // Start is called before the first frame update
    void Start()
    {
		explosion.SetActive(false);
    }
	void Matar(){
		spriteJugador.SetActive(false);
		Debug.Log("me mato");
		explosion.SetActive(true);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
