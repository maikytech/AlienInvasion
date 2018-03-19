using UnityEngine;
using System.Collections;

public class CollisionDestruction : MonoBehaviour
{
	public int scoreValue;									//Puntaje por cada asteroide destruido.
	public GameObject AsteriodExplosionReference;			//Referencia al Game Object de la explosion del asteriode.
	public GameObject PlayerExplosionReference;				//Referencia al Game Object de la explosion del Player.


	private GameController GameControllerClassReference;		//Referencia a la clase GameController.


	void Awake()
	{
		//FindWithTag retorna el Game Object del objecto que tenga el tag buscado.
		GameControllerClassReference = GameObject.FindWithTag("GameController").GetComponent<GameController> ();
	}

	void OnTriggerEnter(Collider other)				//Si el Asteriode colisiona con un collider....
	{
		switch (other.tag)					//Si el nombre del tag es...
		{
			case ("Player"):	//Si colisiona con el Player.
				Instantiate (PlayerExplosionReference, other.transform.position, other.transform.rotation);	//Se instancia la explosion del Player.
				ColisionAsteroid (other);
				GameControllerClassReference.GameOver ();		//Se activa la funcion Gameover().
				
				
				break;
			case("Bolt"):
				
				ColisionAsteroid(other);
				break;
			default:
				break;
		}
	}

	void ColisionAsteroid(Collider other)			//Configura las explosiones y la destruccion de los asteriodes.
	{
		Instantiate (AsteriodExplosionReference, transform.position, transform.rotation);		//Se instancia la explosion del Asteroide.
		GameControllerClassReference.AddScore(scoreValue);	//Llama al metodo AddScore de la clase GameController y suma los puntos al marcador
		Destroy (other.gameObject);						//Se destruye el objeto colisionado.
		Destroy (gameObject);							//Se destruye el objeto collisionador.

	}
}
