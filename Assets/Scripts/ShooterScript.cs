using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShooterScript : MonoBehaviour
{
    public Camera camera;
    public GameObject missilePrefab;
    public EventSystem eventSystem;

    public float missileCooldown { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        missileCooldown = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!Singleton.Instance.gameStarted)
            return;

        if(missileCooldown > 0.0f)
            missileCooldown -= Time.deltaTime;
        else
            missileCooldown = 0.0f;

        if(Input.GetMouseButtonDown(0) && !eventSystem.IsPointerOverGameObject() && missileCooldown <= 0.0f)
        {
            ShootMissile();
            missileCooldown = Singleton.Instance.currentMissileCooldown;
        }
    }

    void ShootMissile()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        GameObject missile = Instantiate(missilePrefab, this.transform.position + new Vector3(0.0f, -1.0f, 0.0f), Quaternion.identity * Quaternion.FromToRotation(Vector3.up, ray.direction));
    }
}
