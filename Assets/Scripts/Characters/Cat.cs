using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour,
                   ICharacter
{
    [SerializeField] private string _horizontalButtonLabel = "Horizontal";
    [SerializeField] private string _verticalButtonLabel = "Vertical";
    [SerializeField] private float _movementSpeed = 1.5f;

    public string horizontalButtonLabel
    {
        get { return _horizontalButtonLabel; }
        set { _horizontalButtonLabel = value; }
    }
    public string verticalButtonLabel
    {
        get { return _verticalButtonLabel; }
        set { _verticalButtonLabel = value; }
    }
    public float movementSpeed
    {
        get { return _movementSpeed; }
        set { _movementSpeed = value; }
    }

    [SerializeField] private bool moveWithPhysics = true;
    private Rigidbody2D rigid;
    private Animator animator;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        GetInputAxis();
    }
    public void GetInputAxis()
    {
        float x_value = 0;
        float y_value = 0;
        if (Mathf.Abs(Input.GetAxis(_horizontalButtonLabel)) > 0.2)
        {
            x_value = Input.GetAxis(_horizontalButtonLabel);
        }
        if (Mathf.Abs(Input.GetAxis(_verticalButtonLabel)) > 0.2)
        {
            y_value = Input.GetAxis(_verticalButtonLabel);
        }
        if (x_value == 0f && y_value == 0f)
        {
            if (moveWithPhysics)
                rigid.velocity = Vector2.zero;
            return;
        }
        if (moveWithPhysics)
            MoveRigidbody(x_value, y_value);
        else
            MoveTransform(x_value, y_value);
        PlayAnimation(x_value, y_value);
    }

    public void MoveRigidbody(float xVal, float yVal)
    {
        //Debug.Log($"xVal {xVal} yVal {yVal}");
        Vector2 movePosition = (Vector2)transform.position + (new Vector2(xVal, yVal) * 0.02f);
        rigid.MovePosition(movePosition);
    }
    public void MoveTransform(float xVal, float yVal)
    {
        //Debug.Log($"xVal {xVal} yVal {yVal}");
        transform.position += new Vector3(xVal * Time.deltaTime * _movementSpeed, yVal * Time.deltaTime * _movementSpeed, 0);
    }
    void PlayAnimation(float xVal, float yVal)
    {

    }
}
