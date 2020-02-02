using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toilet : MonoBehaviour,
                      IFixable
{


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
        GameManager.Instance.UImanager.SetPlungerAccquire();

    }
    public void Fix()
    {
        GameManager.Instance.UImanager.SetToiletComplete();
    }
}
