using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlollow : MonoBehaviour
{
    //Le asigno un objetico q siga
    public Transform objetivo;

    //La velocidad en la q se va a mover
    [Range(0,1f)] //Está sujeto al rango [0,1]
    public float suavizado;

    //LIMITES DE LA CAMERA
    public Vector2 maxPos;
    public Vector2 minPos;

    private void FixedUpdate()
    {
        if(transform.position != objetivo.position) //Si la posicion de la camera es distinta al objetivo, entonces muevo la camara
        {
            /*1- Creo una variable de tipo Vector3
              2- Le asigno un nuevo Vector 3 
              3- Dentro del Vector3 creado le asigno la posicioes X e Y del objetivo
              4- En la parte del eje Z le asigno el valor que le asigne por el inspector (-10)*/
            Vector3 objetivoPos = new Vector3(objetivo.position.x, objetivo.position.y, transform.position.z);

            
            /*Clamp es una funcion que me limita el movimiento
              1- El primer valor se refiere a que es lo que queremos recortar/limitar, en este caso, el seguimiento al jugador
              2- Y entre que valores, minimos y maximos, lo queremos recortar/limitar*/
            objetivoPos.x = Mathf.Clamp(objetivoPos.x, minPos.x, maxPos.x);
            objetivoPos.y = Mathf.Clamp(objetivoPos.y, minPos.y, maxPos.y);

            /*Lerp = linear Interpolation (Interpolacion Lineal)
             Se usa mas que nada para transicionar elementos de forma suave desde un estado A a un estado B en un tiempo determinado
             - Ejemplos: Que un objeto cambie su color graduarlmente, que se mueva de una posicion a otra, hacer un fade ir o fade out de la música o
               algún elemento gráfico, animar botones, etc.
             link video explicativo: https://www.youtube.com/watch?v=_nqF57833YY */
            transform.position = Vector3.Lerp(transform.position, objetivoPos, suavizado);
        }
    }
}
