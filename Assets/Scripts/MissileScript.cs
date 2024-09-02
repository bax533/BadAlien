using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public GameObject explosionPrefab;
    public float lifetime = 10.0f;
    
    private Vector3 earthCenterPos;
    private float rotationSpeed;

    void Start()
    {
        speed = Singleton.Instance.currentMissileSpeed;
        earthCenterPos = GameObject.Find("Earth").transform.position;
        rotationSpeed = Random.Range(5.0f, 50.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        transform.Rotate(0.0f, rotationSpeed * Time.deltaTime, 0.0f, Space.Self);

        lifetime -= Time.deltaTime;
        if(lifetime <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        // Debug.Log("COLLISION!!!!");
        if(collider.gameObject.tag == "EarthSphere" || collider.gameObject.tag == "Green")
        {
            Vector3 explosionUpVec = (transform.position - earthCenterPos);
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity * Quaternion.FromToRotation(Vector3.up, explosionUpVec), GameObject.Find("Earth").transform);
            explosion.transform.localScale = new Vector3(Singleton.Instance.currentExplosionRange, 1.0f, Singleton.Instance.currentExplosionRange);
            // Debug.Log("BOOM!");
            Destroy(gameObject);
        }
    }
}
