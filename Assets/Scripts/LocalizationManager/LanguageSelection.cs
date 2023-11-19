using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageSelection : MonoBehaviour
{
    
    public void English()
    {
        LocalizationManager.instance.language =SystemLanguage.English;
    }

    public void Spanish()
    {
        LocalizationManager.instance.language = SystemLanguage.Spanish;

    }
}
