using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Rewind[] rewinds;

    private void Start()
    {
        instance = this;
    }

    public void SaveGame()
    {
        foreach (var item in rewinds)
        {
            item.Save();
        }
    }

    public void LoadGame()
    {
        foreach (var item in rewinds)
        {
            item.Load();
        }
    }
}
