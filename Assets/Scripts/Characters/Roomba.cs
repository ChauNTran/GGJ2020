using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// movement

public class Roomba : MonoBehaviour
{
    [SerializeField] private string RoombaHorizontalMovementButton = "Horizontal";
    [SerializeField] private string RoombaVerticalMovementButton = "Vertical";
    [SerializeField] private float speed = 1.5f;
    private Rigidbody2D rigid;
    float x_value;
    float y_value;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Mathf.Abs(Input.GetAxis(RoombaHorizontalMovementButton)) > 0.1)
        {
            x_value = Input.GetAxis(RoombaHorizontalMovementButton);
        }
        else if (Mathf.Abs(Input.GetAxis(RoombaVerticalMovementButton)) > 0.1)
        {
            y_value = Input.GetAxis(RoombaVerticalMovementButton);
        }
        else
        {
            rigid.velocity = Vector2.zero;

            return;
        }
        MoveCharacter(x_value, y_value);
    }
    void MoveCharacter(float xVal, float yVal)
    {
        //Debug.Log($"xVal {xVal} yVal {yVal}");
        rigid.AddForce(new Vector2(xVal * speed, yVal * speed));
    }
}
