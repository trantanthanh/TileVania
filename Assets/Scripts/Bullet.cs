using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 1f;
    PlayerMovement player;
    Rigidbody2D myRigidbody;
    private float speedX;
    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
    }

    void Start()
    {
        speedX = Mathf.Sign(player.transform.localScale.x) * bulletSpeed;
        transform.localScale = new Vector2(Mathf.Sign(player.transform.localScale.x), 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector2(speedX, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
}
