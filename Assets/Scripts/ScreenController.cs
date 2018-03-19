using UnityEngine;
using System.Collections;

public static class ScreenController
{
	public static Vector2 DimensionScreen()		//Retorna las dimensiones de la pantalla de manera dinamica.
	{
		float width;
		float height;
		float aspectRatio;
		Camera cameraMainReference;						//Referencia a la camara principal.

		/* pixelWidth y pixelHeight corresponden al ancho y al largo de la camara en pixels, que igual corresponden a la resolucion, estos valores son enteros, 
		 * por eso se hace casting. */
		cameraMainReference = Camera.main;
		aspectRatio = cameraMainReference.pixelWidth / (float)cameraMainReference.pixelHeight;	

		Debug.Log (cameraMainReference.pixelWidth);
		Debug.Log (cameraMainReference.pixelHeight);

		/* orthographicSize devuelve el valor de size en la vista ortografica, que corresponde a la mitad del tamaño de la pantalla en vertical en 
		 * unidades visibles del mundo 3D. */
		height = cameraMainReference.orthographicSize * 2;

		width = height * aspectRatio;		//Ancho en unidades del mundo 3D.

		Debug.Log (aspectRatio);

		return new Vector2 (width, height);
	}
}
