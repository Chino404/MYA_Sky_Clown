using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Impulse : MonoBehaviour, IObserverImpulse
{
    [SerializeField] ForceMode2D _impulseMode;
    [Range(0,10)]
    [SerializeField] int _force;
    [Range(0,1), Tooltip("Valor del realntizamiento")]
    [SerializeField] float _slowedDown = 0.2f;
    [Range(0,3), Tooltip("Tiempo realentizado")]
    [SerializeField] float _slowedDownTime =3f;


    private void Start()
    {
        _slowedDownTime *= _slowedDown;
    }

    public void Action (Rigidbody2D rb2d/*, Vector2 dir*/)
    {
        //StartCoroutine(Timer());
        rb2d.AddForce(Vector2.up * _force, _impulseMode);
        Debug.Log("Impulso");

    }

    IEnumerator Timer()
    {

        Time.timeScale = _slowedDown;

        yield return new WaitForSeconds(_slowedDownTime);

        Time.timeScale = 1.0f;

        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IObservableImpulse>() != null)
            collision.gameObject.GetComponent<IObservableImpulse>().Subscribe(this);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IObservableImpulse>() != null)
            collision.gameObject.GetComponent<IObservableImpulse>().Unsubscribe(this);

    }

}
