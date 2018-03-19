using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script que genera el efecto Parallax al Background.

public class BackgroundScroller : MonoBehaviour
{
	public float scrollSpeed;					//Velocidad con la que se moverá el scroll.

	private Vector3 backgroundStartPosition;	//Posicion inicial del background.
	private float tileSizeBackground;			//Altura del background ¿¿¿?

	void Start ()
	{
		backgroundStartPosition = transform.position;		//Se asigna la posicion inicial.
		tileSizeBackground = transform.localScale.y;		//Se asigna el valor de la escala en el componente "y" del background.
	}
	

	void Update ()
	{
		//Magnitud de desplazamiento del background.
		//La funcion Mathf.Repeat hace un loop desde Time.time hasta el valor de tileSizeBackground.
		//Time.time realiza el conteo desde el inicio de juego, retorna el valor cada segundo.
		//scrollSpeed debe ser menor que uno, para que el efecto de desplazamiento sea mas continuo y natural.
		float desplazamiento = Mathf.Repeat(Time.time * -scrollSpeed, tileSizeBackground);		
		
		Vector3 vectorDeDesplazamiento = Vector3.forward * desplazamiento;	//Vector de desplazamiento del background.

		//El Background se despalazará en el eje z en cada fotograma.
		//Se suma el vector de despalazamiento a la posicion inicial del background.
		transform.position = backgroundStartPosition + vectorDeDesplazamiento;
	}
}
