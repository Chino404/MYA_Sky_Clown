using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; //Para utilizar los botones

//SE LO CARGAMOS AL STICK (SPRITE) DEL JOYSTICK
public class Joystick : ControllerMobile, IDragHandler, IEndDragHandler //IDragHandler es una interfaz que sirve para detectar el agarre - IEndHandler sirve para decirme cuando termino el agarre (Vienen con Unity)
{
    Vector3 _moveDir = default;
    Vector3 initialPosition = default;

    [Tooltip("Hasta donde permito que se mueva el Stick")]
    [SerializeField] float _maxMagnitude = 75;

    void Start()
    {
        initialPosition = transform.position; //Me guardo pa pos inicial
    }

    //Cuando aprieto
    public void OnDrag(PointerEventData eventData) //eventData es el que me dice que es lo que esta pasando en la pantalla, en este caso sería el dedo (Por ser un juego Mobile)
    {
                                           //Me lo coniverte a lo que esta entre parentesis (Vector3)
        _moveDir = Vector3.ClampMagnitude((Vector3)eventData.position - initialPosition, _maxMagnitude);

        transform.position = initialPosition + _moveDir; //Que se mueva a partir del inicio (initialPosition) + la nueva direccion (_moveDir) 
    }

    //Cuando suelto
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = initialPosition; //Me lo regresa a la posicion original
        _moveDir = Vector3.zero; //Lo igualo a cero para q se detenga
    }

    public override Vector3 GetMovementInput()
    {
        //Creo una nueva variable para guardarme los nuevos datos y despues poder modificarla sin miedo a perder esos datos

        //Vector3 moreDirModified = new Vector3(_moveDir.x, 0, _moveDir.y); //Con el eje Y del Stick, mueva el eje Z del jugador (CASO 3D)
        //Vector3 moreDirModified = new Vector3(_moveDir.x, _moveDir.y, 0f);
        Vector2 moreDirModified = new Vector3(_moveDir.x, 0f, 0f);


        moreDirModified = moreDirModified / _maxMagnitude; //Posicion / metros

        return moreDirModified;
    }
}
