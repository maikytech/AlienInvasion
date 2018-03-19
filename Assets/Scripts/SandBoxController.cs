using UnityEngine;
using System.Collections;

public class SandBoxController : MonoBehaviour
{
	//Valores minimos y maximos para que el Player no salga de la pantalla, se asignaran de manera dinamica.

	public float xMin;
	public float xMax;
	public float zMin;
	public float zMax;

	private Vector2 halfWideScreen;		//Vector que representa la mitad de la medida horizontal de la pantalla.

	// La funcion OnTriggerExit() se activa cuando el tipo de collider especificado deja de tener contacto con el trigger. 
	void OnTriggerExit(Collider other)
	{
		Destroy (other.gameObject);		//Se destruye el gameobject detectado.
	}

	void UpdateBoundary()				//Actualiza las medidas del ancho de la pantalla.
	{
		//DimensionScreen es una funcion estatica de la clase ScreenController.
		//DimensionScreen retorna las dimensiones de la pantalla de manera dinamica.
		halfWideScreen = ScreenController.DimensionScreen () / 2;

		Debug.Log (halfWideScreen);

		//Las 8.5, 75 y -1 unidades del mundo 3D fueron asignadas arbitrareamente, equivalen a borde o distancia de tolerancia con respecto a la pantalla.

		xMin = -halfWideScreen.x + 8.5f;
		xMax = halfWideScreen.x - 8.5f;
		zMin = -halfWideScreen.y + 75;
		zMax = halfWideScreen.y - 1;

	}

	void Start()
	{
		UpdateBoundary ();

	}
}
