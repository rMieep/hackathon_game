using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public float startTime;
    public Text timer;
    private int elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        timer.color = Color.white;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime = (int) (Time.time - startTime);
        timer.text = "Score: " + elapsedTime.ToString();
    }
}
