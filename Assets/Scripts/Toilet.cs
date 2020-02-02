using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toilet : MonoBehaviour,
                      IFixable
{


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.GetComponent<Roomba>() != null)
        {
            if (collision.collider.gameObject.GetComponent<Roomba>().currentTool is ToiletPlunger)
            {
                Fix();
                collision.collider.gameObject.GetComponent<Roomba>().removeTool();
                
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
        Debug.Log("fixed toilet");
        // Objective done
    }
}
