using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthScript : MonoBehaviour
{
    public float rotationSpeed = 5.0f;
    public float spawnTimer = 5.0f;
    private float spawnTimer_;

    public int n_spawn_attempts = 200;

    public GameObject greenPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Random.seed = (int)System.DateTime.Now.Ticks;

        spawnTimer_ = spawnTimer;
    }

    IEnumerator SpawnGreens()
    {
        int currentGreensSpawned = Singleton.Instance.numOfSpawnedGreens;
        while(Singleton.Instance.numOfSpawnedGreens < currentGreensSpawned + 10)
        {
            // Debug.Log(Singleton.Instance.numOfSpawnedGreens + "before");
            SpawnGreen();
            yield return new WaitForSeconds(.01f);
            // Debug.Log(Singleton.Instance.numOfSpawnedGreens + "after");
        }
    }

    // Update is called once per frame
    void Update()
    {
        EarthRotation();
        spawnTimer_ -= Time.deltaTime;
        if(Input.GetKeyDown("space"))
        {
            // Debug.Log("spawning");
            spawnTimer_ = spawnTimer;
            StartCoroutine(SpawnGreens());
        }
    }

    void EarthRotation()
    {
        transform.Rotate(0.0f, rotationSpeed * Time.deltaTime, 0.0f, Space.Self);
    }

    public void SpawnGreen()
    {
        Vector3 posFromCenter = GetRandomSpawnPosition();

        GameObject newGreen = Instantiate(greenPrefab, this.transform.position + posFromCenter, Quaternion.identity * Quaternion.FromToRotation(Vector3.up, posFromCenter), this.transform);
        // newGreen.transform.rotation = Quaternion.LookRotation(Quaternion.AngleAxis(90, Vector3.right) * posFromCenter, posFromCenter + posFromCenter);
    }

    public Vector3 GetRandomSpawnPosition()
    {
        float radius = 52.20f;
        float r_tmp = 0.0f;

        float a = Random.Range(1.0f, 100.0f);
        float b = Random.Range(1.0f, 100.0f);
        float c = Random.Range(1.0f, 100.0f);

        r_tmp = a + b + c;

        a = a * radius * radius / r_tmp;
        b = b * radius * radius / r_tmp;
        c = c * radius * radius / r_tmp;

        a = Mathf.Sqrt(a);
        b = Mathf.Sqrt(b);
        c = Mathf.Sqrt(c);

        if(Random.Range(0.0f, 100.0f) >= 50.0f){ a *= -1; }
        if(Random.Range(0.0f, 100.0f) >= 50.0f){ b *= -1; }
        if(Random.Range(0.0f, 100.0f) >= 50.0f){ c *= -1; }

        return new Vector3(a, b, c);
    }
}
