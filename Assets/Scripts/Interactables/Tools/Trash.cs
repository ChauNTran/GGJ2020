using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : Tool
{
    public TrashCan trashCan;

    private void Start()
    {
        if (trashCan == null)
        {
            trashCan = FindObjectOfType<TrashCan>();
        }
    }
    public override void PickUp()
    {
        base.PickUp();
        trashCan.HasTool();
    }
}
