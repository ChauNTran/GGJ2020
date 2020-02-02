using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toilet : Objective,
                      IFixable
{

    private Animator animator;
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
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
        animator.SetTrigger("fix");
        isCompleted = true;
        GameManager.Instance.ObjectiveComplete(this);
        GameManager.Instance.UImanager.SetToiletComplete();
        
        // Objective done
    }
}
