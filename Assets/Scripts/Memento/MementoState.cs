using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MementoState
{
    ParamsMemento data;
    

    public void Rec(params object[] paremeter)
    {
        Debug.Log("guardo");
        
        data = new ParamsMemento(paremeter); 
    }

    public bool IsRemember()
    {
        return data != null;
        //return _remembers.Count > 0;
    }
    
    public ParamsMemento Remember()
    {
        //var remember = _remembers[_remembers.Count - 1];
        //_remembers.RemoveAt(_remembers.Count - 1);
        //return remember;
        return data;
    }

}
