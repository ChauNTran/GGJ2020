using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// movement

public class Roomba : MonoBehaviour
{
    [SerializeField] private string RoombaHorizontalMovementButton = "Horizontal";
    [SerializeField] private string RoombaVerticalMovementButton = "Vertical";
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private bool moveWithPhysics = true;
    private Rigidbody2D rigid;


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float x_value = 0;
        float y_value = 0;
        if (Mathf.Abs(Input.GetAxis(RoombaHorizontalMovementButton)) > 0.5)
        {
            x_value = Input.GetAxis(RoombaHorizontalMovementButton);
        }
        else if (Mathf.Abs(Input.GetAxis(RoombaVerticalMovementButton)) > 0.5)
        {
            y_value = Input.GetAxis(RoombaVerticalMovementButton);
        }
        else
        {
            if (moveWithPhysics)
                rigid.velocity = Vector2.zero;
            return;
        }
        if (moveWithPhysics)
            MoveRigidbody(x_value, y_value);
        else
            MoveTransform(x_value, y_value);


    }
    void MoveRigidbody(float xVal, float yVal)
    {
        //Debug.Log($"xVal {xVal} yVal {yVal}");
        //Vector2 movementVector = new Vector2(xVal, yVal);

        //rigid.AddForce(movementVector, ForceMode2D.Force);
        Vector2 movePosition = (Vector2)transform.position + (new Vector2(xVal, yVal) * 0.02f);
        rigid.MovePosition(movePosition);
    }
    void MoveTransform(float xVal, float yVal)
    {
        transform.position += new Vector3(xVal * Time.deltaTime * speed, yVal * Time.deltaTime * speed, 0);
    }
}
