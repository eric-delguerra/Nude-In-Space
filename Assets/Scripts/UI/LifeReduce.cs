using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeReduce : MonoBehaviour
{
    public int amountLife;
    public HealthBar healthBar;
    public PlayerController player;

    public Vector2 targetPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
            healthBar.SetHealth(player.GetHealth() - amountLife);
            gameObject.SetActive(false);
        }
    }
}
