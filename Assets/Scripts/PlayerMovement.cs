using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float runSpeed = 10.0f;
    [SerializeField] float jumpSpeed = 10.0f;
    Vector2 playerVelocity = new Vector2();

    Vector2 moveInput;
    Rigidbody2D myRigidbody;

    Animator myAnimator;
    // Start is called before the first frame update

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
    }

    void Run()
    {
        // Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed * Time.deltaTime, myRigidbody.velocity.y);
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            myRigidbody.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1.0f);
        }
        myAnimator.SetBool("IsRunning", playerHasHorizontalSpeed);
    }
}
