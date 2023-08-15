using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position, 0.5f);
            Destroy(gameObject);
            FindObjectOfType<GameSession>().IncreaseScore();
        }
    }
}
