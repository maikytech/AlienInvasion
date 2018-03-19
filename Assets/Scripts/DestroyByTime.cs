using UnityEngine;
using System.Collections;

//Scrip que controla el tiempo que durarán las explosiones.

public class DestroyByTime : MonoBehaviour
{
	public int lifeTime;					//Tiempo de vida del objeto a destruir.

	// Use this for initialization
	void Start ()
	{
		Destroy (gameObject, lifeTime);		//Destruye el objeto.
	}
}
