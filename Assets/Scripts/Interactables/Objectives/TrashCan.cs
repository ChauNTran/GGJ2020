using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : Objective,
                        IFixable
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.GetComponent<Roomba>() != null)
        {
            if (collision.collider.gameObject.GetComponent<Roomba>().currentTool is Trash)
            {
                Fix();
                collision.collider.gameObject.GetComponent<Roomba>().removeTool();

            }

        }
    }
    public void HasTool()
    {
        GameManager.Instance.UImanager.SetTrashAccquire();
    }
    public void Fix()
    {
        isCompleted = true;
        GameManager.Instance.ObjectiveComplete(this);
        GameManager.Instance.UImanager.SetTrashComplete();

        // Objective done
    }
}
