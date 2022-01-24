using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public GameObject canvas;
    float startTime;
    public Text timeText;
    int i = 0;
    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 0;
    }


    // Update is called once per frame
    void Update()
    {
            i ++;
            Debug.Log(i);
            timeText.text = (30-i).ToString();
            if (i == 30)
            {
            Debug.Log("after few seconds");
            canvas.SetActive(false);
            Time.timeScale = 1.0f;
            }

    }
}
