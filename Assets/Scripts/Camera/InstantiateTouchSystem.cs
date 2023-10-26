using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateTouchSystem : MonoBehaviour
{
    [SerializeField] LayerMask _currentMask = default; //En que layer quiero que interactue
    [SerializeField] List<GameObject> _objectsPrefabs = new List<GameObject>();

    void Update()
    {
        // Input.touchCount;  Cuenta cantidad de touches en pantalla.
        // Input.touches[0];   Array de tu touches.
        // Input.touchSupported; Tu dispositivo soporte touches.
        // Input.multiTouchEnabled; Habilita con true o false si se permite multiple click.


        if (Input.touchCount <= 0) return; //Si no hay toque, no pasa nada


        for (int i = 0; i < Input.touchCount; i++)
        {
            //El Touch me va contando lo toques que le hago a la pantallas
            Touch currenTouch = Input.touches[i];

            if (currenTouch.phase == TouchPhase.Began)
            {
                //Began = Un usuario a a tocado la pantalla con el dedo en este fotograma    

                /*Creo un Ray que me guarde en que posicion de la pantalla interactue
                 - El ScreenPointToRay me genera un rayo perpendicular a donde yo toque
                 - El ScreenToWorldPoint va con un angulo, depende como lo este viendo
                 - (currentTouch.position) En que posicion de la pantalla estoy respecto al Touch */
                Ray touchRay = Camera.main.ScreenPointToRay(currenTouch.position);

                RaycastHit raycastHit; //Contra lo que interactue

                //Utilizo Phisics xq voy a interactuar con algo fisico
                if (Physics.Raycast(touchRay, out raycastHit, 100000, _currentMask, QueryTriggerInteraction.Ignore))
                {

                                 //(Hit de camara, Donde golpea mi rayo, Distancia maxima, Mascara de layer para saber si clickeaste ahi, Ignora colliders)
                    print("hola");

                    int random = Random.Range(0, _objectsPrefabs.Count);

                    GameObject spawnedObject = Instantiate(_objectsPrefabs[random].gameObject);
                    spawnedObject.transform.position = new Vector2(raycastHit.point.x, raycastHit.point.y + 1f); 

                }

            }

        }

        /*Touch firstTouch = Input.touches[0];

        if (firstTouch.phase == TouchPhase.Began)
        {
            Ray touchRay = Camera.main.ScreenPointToRay(firstTouch.position);
            RaycastHit hit;

            if (Physics.Raycast(touchRay, out hit, 100000, _floorMask, QueryTriggerInteraction.Ignore))
            {
                //Hit de camara
                //Donde golpea mi rayo
                //Distancia maxima
                //Mascara de layer para saber si clickeaste ahi
                //Ignora colliders

                int random = Random.Range(0, _spherePrefabs.Count);

                GameObject spawnedObject = Instantiate(_spherePrefabs[random].gameObject);
                spawnedObject.transform.position = new Vector3(hit.point.x, hit.point.y + 1.5f, hit.point.z);

            }

        }*/
    }
}
