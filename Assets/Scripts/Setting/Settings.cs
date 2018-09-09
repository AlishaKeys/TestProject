using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    static Settings instance;
    public static Settings Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Settings>();
            }
            return instance;
        }
    }

    public SettingsData settings;
}
