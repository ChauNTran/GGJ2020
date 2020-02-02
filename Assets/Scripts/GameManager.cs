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
    public UIManager UImanager { get; private set; }

    public float timeLeft = 180.0f;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        UImanager = GetComponentInChildren<UIManager>();
    }

    void Update()
    {
        runTimer();
    }

    public void runTimer()
    {

        timeLeft -= Time.deltaTime;

        if ( timeLeft < 0 )
        {
            //GameOver();
        }
    }

}
