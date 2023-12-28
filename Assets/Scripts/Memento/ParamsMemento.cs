using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamsMemento
{
    public object[] parameters;
    
    public ParamsMemento(params object[] p)
    {
        parameters = p;
        //parameters = new object[p.Length];
        //for (int i = 0; i < p.Length; i++)
        //{
        //    parameters[i] = p[i];
        //}
    }
}
