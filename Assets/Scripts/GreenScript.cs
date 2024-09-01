using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenScript : MonoBehaviour
{

    private bool spawnedCorrectly = false;
    private bool registered = false;

    private float timeToExpand;

    void Awake()
    {
        // Do not show the tree before it is checked that it was spawned correctly.
        // Without this there were "blinking" trees visible to player when they were spawned incorrectly and instantly removed
        GetComponentInChildren<MeshRenderer>().enabled = false;
        
        spawnedCorrectly = false;
        registered = false;

    }

    void Start()
    {
        Vector3 posFromCenter = transform.position - GameObject.Find("Earth").transform.position;
        transform.rotation = Quaternion.identity * Quaternion.FromToRotation(Vector3.up, posFromCenter);

        timeToExpand = Singleton.Instance.timeToExpandGreen;
    }

    void Update()
    {
        SpawnCheckLogic();

        timeToExpand -= Time.deltaTime;
        if(timeToExpand <= 0.0f)
        {
            timeToExpand = Singleton.Instance.timeToExpandGreen;
            Debug.Log("Expanding!!!");
            StartCoroutine(Expand());
        }
    }

    void SpawnCheckLogic()
    {
        if(!spawnedCorrectly)
        {
            Destroy(gameObject);
        }
        else if(!registered)
        {
            GetComponentInChildren<MeshRenderer>().enabled = true;
            Singleton.Instance.RegisterSpawnedGreen();
            registered = true;
        }
    }

    IEnumerator Expand()
    {
        float[] degrees = {Random.Range(0.1f, 179.0f), Random.Range(180.0f, 350.0f)};
        foreach(float curDeg in degrees)
        {
            Vector3 translateVec = Quaternion.AngleAxis(curDeg, transform.up) * transform.right;
            Vector3 newPos = transform.position + translateVec * 3.5f;
            Vector3 newPosFromCenter = newPos - GameObject.Find("Earth").transform.position;

            Quaternion newRotation = Quaternion.identity * Quaternion.FromToRotation(Vector3.up, newPosFromCenter);
            GameObject newGreen = Instantiate(GameObject.Find("Earth").GetComponent<EarthScript>().greenPrefab, newPos, newRotation, GameObject.Find("Earth").transform);
            yield return new WaitForSeconds(.1f);
        }
    }

    void OnTriggerEnter(Collider collider)
    {

        if(collider.gameObject.tag == "Explosion")
        {
            Destroy(gameObject);
            return;
        }

        if(collider.gameObject.tag == "Green" && !spawnedCorrectly)
        {
            Destroy(gameObject);
            return;
        }

        if(collider.gameObject.tag == "Respawn")
        {
            spawnedCorrectly = true;
        }
    }
}
