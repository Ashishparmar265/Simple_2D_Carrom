using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerController : MonoBehaviour

{
    float cntdnw = 120.0f;
    public Text disvar;
    public Text Minutes;
    public Text Seconds;

    void Update()
    {
        if (cntdnw > 0)
        {
            cntdnw -= Time.deltaTime;
        }
        double b = System.Math.Round(cntdnw, 2);
        disvar.text = b.ToString();
        float minutes = Mathf.FloorToInt(cntdnw / 60);
        Minutes.text = minutes.ToString();
        float seconds = Mathf.FloorToInt(cntdnw % 60);
        Seconds.text = seconds.ToString();
        if (cntdnw < 0)
        {
            Debug.Log("Completed");
        }
        if (cntdnw<=0)
        {
            GameOver();
            

        }

    }
    public void GameOver()
    {
        Application.Quit();
    }
}
