using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }

    public List<Interactables> objectives = new List<Interactables>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

    }
    public void ProcessObjective(bool isDone)
    {

    }
    public void ProcessObjective(float progreess)
    {

    }
}
