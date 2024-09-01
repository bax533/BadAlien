using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    public Camera camera;
    public GameObject missilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ShootMissile();
        }
    }

    void ShootMissile()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        GameObject missile = Instantiate(missilePrefab, this.transform.position + new Vector3(0.0f, -1.0f, 0.0f), Quaternion.identity * Quaternion.FromToRotation(Vector3.up, ray.direction));
    }
}
