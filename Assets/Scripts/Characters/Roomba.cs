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
        }
        else if (Mathf.Abs(Input.GetAxis(_verticalButtonLabel)) > 0.5)
        {
            y_value = Input.GetAxis(_verticalButtonLabel);
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
            case MoveState.moveUp:
                animator.SetTrigger("moveUp");
                break;
            case MoveState.moveDown:
                animator.SetTrigger("moveDown");
                break;
            case MoveState.moveLeft:
                animator.SetTrigger("moveLeftRight");
                break;
            case MoveState.moveRight:
                animator.SetTrigger("moveLeftRight");
                break;
        }
    }

    void PlayMoveUpAnimation()
    {
        animator.SetBool("moveUp", true);
    }
    void PlayMoveDownAnimation()
    {
        animator.SetBool("moveDown", true);
    }
    void PlayLeftAnimation()
    {
        animator.SetBool("moveLeftRight", true);
        sprite.flipY = true;
    }
    void PlayRightAnimation()
    {
        animator.SetBool("moveLeftRight", true);
        sprite.flipY = true;
    }
}
