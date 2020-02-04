﻿using System.Collections;
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
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (collision.collider.gameObject.GetComponent<Roomba>().currentTool != null)
        {
            Tool currentTool = collision.collider.gameObject.GetComponent<Roomba>().currentTool;
            if (currentTool is ToiletPlunger)
            {
                Fix(currentTool);
                collision.collider.gameObject.GetComponent<Roomba>().removeTool();
                
            }
                
        }
    }
    public void HasTool()
    {
        GameManager.Instance.UImanager.SetPlungerAccquire();
    }
    public void Fix(Tool tool = null)
    {
        animator.SetTrigger("fix");
        isCompleted = true;
        GameManager.Instance.ObjectiveComplete(this, tool);
        GameManager.Instance.UImanager.SetToiletComplete();
        
        // Objective done
    }
}
