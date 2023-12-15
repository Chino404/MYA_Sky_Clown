using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    [SerializeField] private Image _lifeBar;

    private void Awake()
    {
        _lifeBar = GetComponent<Image>();
    }

    private void Start()
    {
        EventManager.Subscribe("LifeBar", ProjectLife);
    }

    public void ProjectLife(params object[] parameters)
    {
        var maxLife = (float)parameters[0];
        var actualLife = (float)parameters[1];

        _lifeBar.fillAmount = actualLife / maxLife;
    }
}
