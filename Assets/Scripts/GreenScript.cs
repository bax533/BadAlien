using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenScript : MonoBehaviour
{

    private bool spawnedCorrectly = false;
    private bool registered = false;
    private bool expanded;

    private float timeToExpand;

    void Awake()
    {
        // Do not show the tree before it is checked that it was spawned correctly.
        // Without this there were "blinking" trees visible to player when they were spawned incorrectly and instantly removed
        GetComponentInChildren<MeshRenderer>().enabled = false;
        
        spawnedCorrectly = false;
        registered = false;
        expanded = false;

    }

    void Start()
    {
        Vector3 posFromCenter = transform.position - GameObject.Find("Earth").transform.position;
        transform.rotation = Quaternion.identity * Quaternion.FromToRotation(Vector3.up, posFromCenter);

        timeToExpand = Singleton.Instance.timeToExpandGreen;
    }

    void Update()
    {
        if(!Singleton.Instance.gameStarted)
            return;

        SpawnCheckLogic();

        timeToExpand -= Time.deltaTime;
        if(timeToExpand <= 0.0f && !expanded)
        // if(Input.GetKeyDown("e"))
        {
            timeToExpand = Singleton.Instance.timeToExpandGreen;
            // Debug.Log("Expanding!!!");
            StartCoroutine(Expand());
            expanded = true;
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
        // float[] degrees = {Random.Range(0.1f, 179.0f), Random.Range(180.0f, 350.0f)};
        float[] degrees = {Random.Range(0.1f, 359.0f)};
        foreach(float curDeg in degrees)
        {
            Vector3 translateVec = Quaternion.AngleAxis(curDeg, transform.up) * transform.right;
            Vector3 newPos = transform.position + translateVec * 2.0f;
            Vector3 newPosFromCenter = newPos - GameObject.Find("Earth").transform.position;

            Quaternion newRotation = Quaternion.identity * Quaternion.FromToRotation(Vector3.up, newPosFromCenter);
            GameObject newGreen = Instantiate(gameObject, newPos, newRotation, GameObject.Find("Earth").transform);
            
            try
            {
                newGreen.transform.Translate(0.0f, 0.01f, 0.0f);
            } catch (System.Exception e) {}
            
            yield return new WaitForSeconds(.1f);

            try
            {
                newGreen.transform.Translate(0.0f, 0.01f, 0.0f);
            } catch (System.Exception e) {}
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        // Debug.Log("GreenTriggerEnter with: " + collider.gameObject.tag);

        if(collider.gameObject.tag == "EarthSphere")
            return;

        if(collider.gameObject.tag == "Explosion")
        {
            // Debug.Log("Explosion fault");
            Destroy(gameObject);
            Singleton.Instance.points += 1;
            return;
        }

        if(collider.gameObject.tag == "Green" && !spawnedCorrectly)
        {
            // Debug.Log("Green fault");
            Destroy(gameObject);
            return;
        }

        if(collider.gameObject.tag == "Respawn")
        {
            spawnedCorrectly = true;
        }
    }
}
