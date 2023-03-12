using System.Collections;
using System.Collections.Generic;
using Project.Scripts.FirebaseScripts;
using UnityEngine;

[RequireComponent(typeof(FirebaseConnection))]
public class FirebaseConnectionSingleton : MonoBehaviour
{
    public static FirebaseConnectionSingleton Instance { get; private set; }
    
    public static FirebaseConnection FirebaseConnection { get; private set; }

    void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
        
        DontDestroyOnLoad(this);

        FirebaseConnection = GetComponent<FirebaseConnection>();
    }
}
