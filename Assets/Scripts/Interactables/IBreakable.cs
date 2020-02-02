using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBreakable
{
    bool canMess { get; set; }
    void MessUp();
}
