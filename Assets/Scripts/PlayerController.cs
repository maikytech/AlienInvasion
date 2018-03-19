using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;		//Libreria para el manejo de controles virtuales.
using System.Collections;

public class PlayerController : MonoBehaviour
{
	[Header("Movement")]
	public float speed;											//Rapidez deseada para el movimiento del player.
	public float tilting;										//Grados de inclinacion del Player.
	public GameObject SandBoxGameObjectReference;				//Referencia al Gameobject del SandBox.

	private SandBoxController SandBoxControllerClassReference;	//Referencia a la clase SandBoxController.
	private Rigidbody rigidbodyReference;						//Referencia al componente Rigidbody del Player.

	void Awake()
	{
		rigidbodyReference = GetComponent<Rigidbody> ();		//Se hace referencia al Rigidbody del jugador.
		SandBoxControllerClassReference = SandBoxGameObjectReference.GetComponent<SandBoxController>();	//Se referencia a la clase SandBoxController del objeto SandBox
	}
		
	void Movement()			//Funcion que controla el movimiento del Player.
	{
		float horizontalMovement = CrossPlatformInputManager.GetAxis ("Horizontal");		//Devuelve un valor entre -1 y 1, simulando un axis horizontal.
		float verticalMovement = CrossPlatformInputManager.GetAxis ("Vertical");

		/* Math.CLamp retorna un valor float restringido dentro de un intervalo determinado, en este caso, la posicion del rigidbody no se saldra de este
		 * intervalo, asi el Player no se saldra de la pantalla. */
		Vector3 velocityVector = new Vector3 (horizontalMovement, 0f, verticalMovement);
		Vector3 vectorPosition = new Vector3 ((Mathf.Clamp(rigidbodyReference.position.x, SandBoxControllerClassReference.xMin, SandBoxControllerClassReference.xMax)), 0f, Mathf.Clamp(rigidbodyReference.position.z, SandBoxControllerClassReference.zMin, SandBoxControllerClassReference.zMax));

		rigidbodyReference.velocity = velocityVector * speed;			//Velocidad con la que se movera el Player.
		rigidbodyReference.position = vectorPosition;					//Posicion del Player.

		//El Player rotará en el eje z de acuerdo a su movimiento en el eje x, el tilting equivale a los grados de inclinacion de la nave.
		rigidbodyReference.rotation = Quaternion.Euler(0f, 0f, horizontalMovement * tilting);
	}
		
	void FixedUpdate()
	{
		Movement ();
	}
}
