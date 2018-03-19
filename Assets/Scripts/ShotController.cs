using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;

public class ShotController : MonoBehaviour
{
	
	public float  fireRate;									//Tasa de disparo.
	public GameObject BoltGameObjectReference;				//Referencia al Game Object del Bolt.
	public GameController gameControllerClassReference;		//Referencia a la clase GameController.

	private float nextFire;									//Tiempo para el proximo disparo.

	//Funcion que ejecuta la orden de disparo, debera pasar un periodo de tiempo definido por la variable fireRate para volver a disparar.
	void ShootOrder()			
	{
		if(!gameControllerClassReference.isGameOver)
		{
			//Time.time es el tiempo en segundos desde el inicio del juego.
			//Si el jugador pulsa el boton de disparo y el Time.time es mayor que el tiempo para el proximo disparo...
			if(CrossPlatformInputManager.GetButton("Fire1") && Time.time > nextFire)	
			{
				nextFire = Time.time + fireRate;		//Se incrementa el tiempo para el proximo disparo.	

				//La funcion Instantiate crea un copia del objeto solicitado y retorna el nombre del objeto.
				//Quaternion.identity corresponde a la identidad de la rotacion, es decir que el objeto no rotará.
				Instantiate(BoltGameObjectReference, gameObject.transform.position, Quaternion.identity);
			}
		}
	}

	void Update ()
	{
		ShootOrder ();
	}
}
