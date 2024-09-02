using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthScript : MonoBehaviour
{
    public GameObject End_Canvas;
    public GameObject UI_Canvas;

    public float radius = 52.5f;
    public float rotationSpeed = 5.0f;
    public float spawnTimer = 18.0f;
    private float spawnTimer_;

    public int n_spawn_attempts = 200;

    public GameObject[] greenPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        Random.seed = (int)System.DateTime.Now.Ticks;

        spawnTimer_ = 2.0f;
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
        if(!Singleton.Instance.gameStarted)
            return;

        EarthRotation();
        spawnTimer_ -= Time.deltaTime;
        if(spawnTimer_ <= 0.0f)
        {
            // Debug.Log("spawning");
            spawnTimer_ = spawnTimer;
            StartCoroutine(SpawnGreens());
        }
    }

    void EarthRotation()
    {

        // if(Input.GetKey("left")) rotationSpeed = 20.0f;
        // else if(Input.GetKey("right")) rotationSpeed = -20.0f;
        // else rotationSpeed = 0.0f;

        transform.Rotate(0.0f, rotationSpeed * Time.deltaTime, 0.0f, Space.Self);
    }

    public void SpawnGreen()
    {
        Vector3 posFromCenter = GetRandomSpawnPosition();

        int prefab_it = Random.Range(0, greenPrefabs.Length);
        GameObject newGreen = Instantiate(greenPrefabs[prefab_it], this.transform.position + posFromCenter, Quaternion.identity * Quaternion.FromToRotation(Vector3.up, posFromCenter), this.transform);
        // newGreen.transform.rotation = Quaternion.LookRotation(Quaternion.AngleAxis(90, Vector3.right) * posFromCenter, posFromCenter + posFromCenter);
    }

    public Vector3 GetRandomSpawnPosition()
    {
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
