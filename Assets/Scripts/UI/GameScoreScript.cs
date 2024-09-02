using UnityEngine;
using UnityEngine.UI;

public class GameScoreScript : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = Singleton.Instance.score.ToString();
    }
}
