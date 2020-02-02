using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toilet : MonoBehaviour,
                      IFixable
{

    public plungerUIHandler plungerUIController;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.GetComponent<Roomba>()!=null)
        {
            if (collider.gameObject.GetComponent<Roomba>().currentTool is ToiletPlunger)
            {
                collider.gameObject.GetComponent<Roomba>().removeTool();
                Fix();
            }
                
        }
    }
    public void HasTool()
    {
        plungerUIController.SetStatusAcquired();

    }
    public void Fix()
    {
        plungerUIController.SetStatusCompleted();
    }
}
