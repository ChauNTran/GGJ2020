using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerUI : MonoBehaviour
{
    [SerializeField] private Text timerText;


    private void Update()
    {
        DisplayTimer();

    }

    void DisplayTimer()
    {
        if (GameManager.Instance == null)
            return;
        timerText.text = "Time Remaining: " + Mathf.RoundToInt(GameManager.Instance.timeLeft).ToString();
    }
}
