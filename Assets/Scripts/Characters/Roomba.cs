using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roomba : MonoBehaviour,
                      ICharacter
{
    public enum MoveState { none, moveUp, moveDown, moveLeft, moveRight}
    private MoveState _moveState = MoveState.none;
    public MoveState moveState
    {
        get { return moveState; }
        set { if (value != _moveState)
            {
                _moveState = value;
                PlayAnimation(_moveState);
            }
        }
    }

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
    private SpriteRenderer sprite;

    [HideInInspector]public bool hasTool = false;
    [HideInInspector]public Tool currentTool = null;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        GetInputAxis();
    }
    public void GetInputAxis()
    {
        float x_value = 0;
        float y_value = 0;
        if (Mathf.Abs(Input.GetAxis(_horizontalButtonLabel)) > 0.5)
        {
            x_value = Input.GetAxis(_horizontalButtonLabel);
            if (x_value < 0)
                moveState = MoveState.moveLeft;
            else
                moveState = MoveState.moveRight;
        }
        else if (Mathf.Abs(Input.GetAxis(_verticalButtonLabel)) > 0.5)
        {
            y_value = Input.GetAxis(_verticalButtonLabel);
            if (y_value < 0)
                moveState = MoveState.moveDown;
            else
                moveState = MoveState.moveUp;
        }
        else
        {
            moveState = MoveState.none;
            if (moveWithPhysics)
                rigid.velocity = Vector2.zero;
            return;
        }
        if (moveWithPhysics)
            MoveRigidbody(x_value, y_value);
        else
            MoveTransform(x_value, y_value);
    }

    public void MoveRigidbody(float xVal, float yVal)
    {
        //Debug.Log($"xVal {xVal} yVal {yVal}");
        Vector2 movePosition = (Vector2)transform.position + (new Vector2(xVal, yVal) * 0.02f);
        rigid.MovePosition(movePosition);
    }
    public void MoveTransform(float xVal, float yVal)
    {
        transform.position += new Vector3(xVal * Time.deltaTime * _movementSpeed, yVal * Time.deltaTime * _movementSpeed, 0);
    }

    void PlayAnimation (MoveState movestate)
    {
        switch(movestate)
        {
            case MoveState.none:
                animator.SetTrigger("idle");
                Debug.Log("play idle");
                break;
            case MoveState.moveUp:
                animator.SetTrigger("moveUp");
                Debug.Log("play moveUp");
                break;
            case MoveState.moveDown:
                animator.SetTrigger("moveDown");
                Debug.Log("play moveDown");
                break;
            case MoveState.moveLeft:
                animator.SetTrigger("moveLeftRight");
                sprite.flipX = true;
                Debug.Log("play moveLeftRight");
                break;
            case MoveState.moveRight:
                animator.SetTrigger("moveLeftRight");
                sprite.flipX = false;
                Debug.Log("play moveLeftRight");
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (hasTool)
            return;
        if(collider.gameObject.GetComponent<Tool>() != null)
        {
            currentTool = collider.gameObject.GetComponent<Tool>();
            currentTool.PickUp();
        }
    }
    public void removeTool()
    {
        hasTool = false;
        currentTool = null;
    }
}
