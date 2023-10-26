using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObservableImpulse
{
    void Subscribe(IObserverImpulse obs);

    void Unsubscribe(IObserverImpulse obs);
}
