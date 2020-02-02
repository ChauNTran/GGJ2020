using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }

    [SerializeField] public Text timerUI;

    public float timeLeft = 180.0f;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

    }

    void Update()
    {
        runTimer();
    }

    public void runTimer(){
        timeLeft -= Time.deltaTime;
        //Debug.Log("Time left: " + Mathf.Round(Time.deltaTime));
        //timeLeft = Mathf.Round(timeLeft);
        timerUI.text = "Time Remaining: " + Mathf.RoundToInt(timeLeft).ToString();
        if ( timeLeft < 0 )
        {
            //GameOver();
        }
    }

    public void ProcessObjective(bool isDone)
    {

    }
    public void ProcessObjective(float progreess)
    {

    }
}
