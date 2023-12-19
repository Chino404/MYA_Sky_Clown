using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MementoState
{
    ParamsMemento data;

    public void Rec(params object[] paremeter)
    {
        data = new ParamsMemento(paremeter);
    }

    public bool IsRemember()
    {
        return data != null;
    }

    public ParamsMemento Remember()
    {
        return data;
    }

}
