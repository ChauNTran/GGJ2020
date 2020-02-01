using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter
{
    string horizontalButtonLabel { get; set; }
    string verticalButtonLabel { get; set; }
    float movementSpeed { get; set; }

    void GetInputAxis();
    void MoveTransform(float xVal, float yVal);
    void MoveRigidbody(float xVal, float yVal);
}
