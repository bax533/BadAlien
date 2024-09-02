using UnityEngine;
using UnityEngine.UI;

public class TimeUpdateScript : MonoBehaviour
{
    public TMPro.TextMeshProUGUI timeText;

    // Update is called once per frame
    void Update()
    {
        if(Singleton.Instance.timeLeft > 10000)
            timeText.text = "Unlimited";
        else
            timeText.text = ((int)Singleton.Instance.timeLeft).ToString();
    }
}
