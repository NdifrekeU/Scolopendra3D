using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            return _instance;
        }

        set
        {
            _instance = value;
        }
    }




    public virtual void Awake()
    {
        if (Instance == null)
            Instance = FindObjectOfType<T>();
        else if (Instance != this)
            Destroy(Instance.gameObject);

    }


}
