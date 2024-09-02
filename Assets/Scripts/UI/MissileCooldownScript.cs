using UnityEngine;
using UnityEngine.UI;

public class MissileCooldownScript : MonoBehaviour
{
    public RectTransform bar;
    public ShooterScript shooter;

    // Update is called once per frame
    void Update()
    {
        bar.localScale = 
            new Vector3(
                Mathf.Clamp(
                    (Singleton.Instance.currentMissileCooldown - shooter.missileCooldown) / Singleton.Instance.currentMissileCooldown,
                    0.0f,
                    1.0f), 1.0f, 1.0f);
    }
}
