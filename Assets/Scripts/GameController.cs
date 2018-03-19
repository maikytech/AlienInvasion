using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour
{
	
	public int asteroidCount;								//Cantidad de asteroides que se crearan en cada tanda.
	public float spawnDelay;								//Tiempo de espera entre la creacion de asteoides.
	public float startDelay;								//Tiempo de espera para el comienzo de la corrutina.
	public float waveDelay;									//Tiempo de espera entre hordas de asteroides.
	public bool isGameOver;									//El juego se ha terminado?..
	public Text ScoreTextReference;							//Referencia al objeto ScoreText.
	public GameObject[] AsteriodsReferences;				//Array que contiene la referencia a los Asteriodes.
	public GameObject GameOverGameObjectReference;			//Referencia al GameObject GameOver.
	public GameObject RestartGameObjectReference;			//Referencia al GameObject Restart.
	public GameObject SandBoxReference;						//Referencia al GameObject del SandBox.

	private int score;										//Variable que contiene la puntuacion.
	private bool isRestartEnable;							//El boton de restart se encuentra activado?..
	private SandBoxController SandBoxControllerReference;	//Referencia a la clase SandBoxController.

	void Awake()
	{
		SandBoxControllerReference = SandBoxReference.GetComponent<SandBoxController> (); //Se asigna la referencia al componente SandBoxController.
	}

	void Start ()
	{
		isGameOver = false;
		isRestartEnable = false;
		GameOverGameObjectReference.SetActive (false);
		RestartGameObjectReference.SetActive (false);
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnAsteriods ());	
	}
	
	IEnumerator SpawnAsteriods()					//Corruntina que crea asteroides.
	{
		yield return new WaitForSeconds (startDelay);	//Delay para la creacion de asteroides.

		while (true)
		{
			for (int i = 0; i < asteroidCount; i++)
			{	
				Vector3 positionSpawnAsteriods = new Vector3 (Random.Range (SandBoxControllerReference.xMin, SandBoxControllerReference.xMax), 0, 180);

				//Se instancia un asteroide aleatoriamente.
				Instantiate (AsteriodsReferences[Random.Range (0,AsteriodsReferences.Length)], positionSpawnAsteriods, Quaternion.identity);

				yield return new WaitForSeconds (spawnDelay);
			}

			yield return new WaitForSeconds (waveDelay);

			if(isGameOver)
			{
				//Se activara el boton Restart despues de que terminen de generarse los ultimos asteroides.
				RestartGameObjectReference.SetActive (true);
				isRestartEnable = true;
				break;						//Esta instruccion nos saca fuera de la instruccion While, por los cual, se dejan de generar asteriodes.
			}
		}
	}

	public void AddScore(int scoreValue)			//Aumenta el valor de la variable score.
	{
		score += scoreValue;
		UpdateScore ();
	}

	void UpdateScore ()				//Actualiza el puntaje en pantalla.
	{
		ScoreTextReference.text = "Score: " + score;
	}

	public void GameOver()
	{
		isGameOver = true;
		GameOverGameObjectReference.SetActive (true);
	}

	public void Restart()		//La funcion Restart debe de ser publica para que salga en el listado de On Click del boton Restart.	
	{
		//SceneManager.GetActiveScene().name retorna el nombre de la escena atual.
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	void RestartMacPc()		//Funcion Restart para Mac y Pc.
	{
		if (isRestartEnable == true && Input.GetKeyDown (KeyCode.R))	//Si el boton Restart esta activo y se pulsa la tecla R se cargara de nuevo la scena actual.
		{
			Restart ();
		}
	}
		
	void Update()
	{
		RestartMacPc ();
	}
}
