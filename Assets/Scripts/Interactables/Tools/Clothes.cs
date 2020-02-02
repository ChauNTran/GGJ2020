using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothes : Tool
{
    public LaundryMachine toilet;

    private void Start()
    {
        if (toilet == null)
        {
            toilet = FindObjectOfType<LaundryMachine>();
        }
    }
    public override void PickUp()
    {
        base.PickUp();
        toilet.HasTool();
    }
}
