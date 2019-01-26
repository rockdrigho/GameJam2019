using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
	public GameObject[] assets;
	public Vector2 corrimiento;
	public int nivel;
	public Dictionary<int,int> capa=new Dictionary<int,int>(){
		{0,0},
		{1,-1},
		{2,-2}

	};

	void DibujarMapa(){
		for(int i=0;i<Niveles.mapas[nivel].Length;i++){
			for(int j=0;j<Niveles.mapas[nivel][i].Length;j++){
				int tipo=Niveles.mapas[nivel][i][j];
				if(tipo<assets.Length){
					GameObject g=(GameObject)Instantiate(assets[tipo], new Vector3(j*corrimiento.x, -i*corrimiento.y, capa[tipo]), Quaternion.identity);

					g.transform.parent=this.transform;
					g=(GameObject)Instantiate(assets[0], new Vector3(j*corrimiento.x, -i*corrimiento.y, capa[0]), Quaternion.identity);
					g.transform.parent=this.transform;
				}

			}
			
			
		}

	}
    void Start()
    {

		DibujarMapa();

        
    }

    
    void Update()
    {
        
    }
}
