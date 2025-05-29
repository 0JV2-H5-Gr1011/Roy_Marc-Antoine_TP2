using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountDownTimer : MonoBehaviour
{
    public TMP_Text timer;
    private float timeRemain = 60f;
    private bool timerRun = true;

    private void Update()
    {
        if (timerRun)
        {
            if (timeRemain > 0)
            {
                timeRemain -= Time.deltaTime;
                timer.text = Mathf.CeilToInt(timeRemain).ToString();
            }
            else
            {
                timeRemain = 0;
                timerRun = false;
                SceneManager.LoadScene("finPerdu");
            }
        }
    }
}
