using UnityEngine;
using System.Collections;

public class BoltController : MonoBehaviour
{
	public float speedBolt;

	private Rigidbody rigidbodyReference;			//Referencia al componente Rigidbody del Bolt.

	void Awake()
	{
		rigidbodyReference = GetComponent<Rigidbody> ();		//Se hace referencia al Rigidbody del Bolt.
	}

	void MovementBolt()												//Funcion que controla el movimiento del Bolt.
	{
		rigidbodyReference.velocity = transform.forward * speedBolt;		//El Bolt se movera hacia adelante en el eje z.
	}
		
	void Start ()
	{
		MovementBolt ();
	}
}
