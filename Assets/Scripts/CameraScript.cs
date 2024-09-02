using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject earth;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("s"))
        {
            transform.RotateAround(earth.transform.position, Vector3.left, Singleton.Instance.currentMovementSpeed * Time.deltaTime);
        }
        if(Input.GetKey("w"))
        {
            transform.RotateAround(earth.transform.position, Vector3.right, Singleton.Instance.currentMovementSpeed * Time.deltaTime);
        }
        if(Input.GetKey("a"))
        {
            transform.RotateAround(earth.transform.position, Vector3.up, Singleton.Instance.currentMovementSpeed * Time.deltaTime);
        }
        if(Input.GetKey("d"))
        {
            transform.RotateAround(earth.transform.position, Vector3.down, Singleton.Instance.currentMovementSpeed * Time.deltaTime);
        }
    }
}
