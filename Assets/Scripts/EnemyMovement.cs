using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myRigidbody;
    BoxCollider2D frontCollider;
    bool IsTurnRight = true;
    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        frontCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (frontCollider.IsTouchingLayers(LayerMask.GetMask("Platform")))
        {
            myRigidbody.velocity = new Vector2((IsTurnRight ? 1 : -1) * moveSpeed, 0f);
        }
        else
        {
            IsTurnRight = !IsTurnRight;
            transform.localScale = new Vector2(IsTurnRight ? 1f : -1f, 1.0f);
        }
    }
}
