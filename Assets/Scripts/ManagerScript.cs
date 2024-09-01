using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour 
{
    public int numOfSpawnedGreens { get; set; }
    public float timeToExpandGreen { get; set; }

    public static Singleton Instance { get; private set; }

    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }

        Instance.numOfSpawnedGreens = 0;
        Instance.timeToExpandGreen = 5.0f;
    }

    public void RegisterSpawnedGreen()
    {
        Instance.numOfSpawnedGreens += 1;
    }
}
