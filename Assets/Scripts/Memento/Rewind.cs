using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rewind : MonoBehaviour
{
    public MementoState currentState;

    private void Awake()
    {
        currentState = new MementoState();
    }

    public abstract void Save();

    public abstract void Load();
}
