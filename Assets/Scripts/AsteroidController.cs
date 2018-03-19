using UnityEngine;
using System.Collections;

public class AsteroidController : MonoBehaviour
{
	public float speedRotation;									//Rapidez de rotacion.
	public float speedAsteriod;									//Rapidez del asteriode.

	private Rigidbody rigidbodyReference;						//Referencia al componente Rigidbody del asteriode.

	void Awake()
	{
		rigidbodyReference = GetComponent<Rigidbody> ();		//Se hace referencia al Rigidbody del asteriode.

	}
		
	void Start ()
	{
		Movement ();
		Rotation ();
	}

	void Movement()														//Funcion que controla el movimiento del asteriode.
	{
		rigidbodyReference.velocity = transform.forward	 * -speedAsteriod;		//El asteriode se movera hacia atras en el eje z.
	}
		
	void Rotation()				//El asteriode rotará de forma aleatoria en todos los ejes a traves del vector normalizado (magnitud uno).
	{
		//insideUnitSphere retorna un punto aleatorio dentro de una esfera de radio uno, no esta normalizado, por lo cual los asteriodes tendran diferentes velocidades.
		rigidbodyReference.angularVelocity = Random.insideUnitSphere * speedRotation;
	}
}
