using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenScript : MonoBehaviour
{
    private bool spawnedCorrectly = false;
    private bool registered = false;
    // Start is called before the first frame update
    void Start()
    {
        spawnedCorrectly = false;
        registered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!spawnedCorrectly)
        {
            Destroy(gameObject);
        }
        else if(!registered)
        {
            Singleton.Instance.RegisterSpawnedGreen();
            registered = true;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Respawn")
        {
            spawnedCorrectly = true;
        }
    }
}
