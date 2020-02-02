using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletPlunger : Tool
{
    public Toilet toilet;

    public override void PickUp()
    {
        base.PickUp();
        toilet.HasTool();
    }
}
