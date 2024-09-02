using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    public TMPro.TextMeshProUGUI scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Points " + Singleton.Instance.points.ToString();
    }
}
