using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartGame : MonoBehaviour
{
    public GameObject canvas;
    float startTime;
    public TMP_Text timeText;
    
    int i = 0;
    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 0;
    }

    void Start()
    {
         StartCoroutine(BeforeStart());
    }

    IEnumerator BeforeStart() 
    {
        timeText.text = "3";
        yield return new WaitForSecondsRealtime(1.0f);
        timeText.text = "2";
        yield return new WaitForSecondsRealtime(1.0f);
        timeText.text = "1";
        yield return new WaitForSecondsRealtime(1.0f);
        Time.timeScale = 1.0f;
        timeText.text = "Start";
        yield return new WaitForSecondsRealtime(0.5f);

        canvas.SetActive(false);

    }



}
