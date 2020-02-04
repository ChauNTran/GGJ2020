using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public string objectiveName;
    public bool isCompleted = false;
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.Instance.gameOver)
            return;
    }
}
