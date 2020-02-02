using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletPlunger : Tool
{
    public Toilet toilet;

    private void Start()
    {
        if(toilet == null)
        {
            toilet = FindObjectOfType<Toilet>();
        }
    }
    public override void PickUp()
    {
        base.PickUp();
        toilet.HasTool();
    }
}
