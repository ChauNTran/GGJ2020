using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : Objective,
                        IFixable
{
    [SerializeField] private GameObject TrashSprite;

    void Start()
    {
        TrashSprite.SetActive(false);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (collision.collider.gameObject.GetComponent<Roomba>().currentTool != null)
        {
            Tool currentTool = collision.collider.gameObject.GetComponent<Roomba>().currentTool;
            if (collision.collider.gameObject.GetComponent<Roomba>().currentTool is Trash)
            {
                Fix(currentTool);
                collision.collider.gameObject.GetComponent<Roomba>().removeTool();

            }

        }
    }
    public void HasTool()
    {
        GameManager.Instance.UImanager.SetTrashAccquire();
    }
    public void Fix(Tool tool = null)
    {
        isCompleted = true;
        TrashSprite.SetActive(true);
        GameManager.Instance.ObjectiveComplete(this);
        GameManager.Instance.UImanager.SetTrashComplete();

        // Objective done
    }
}
