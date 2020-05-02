using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeRegen : MonoBehaviour
{
    public int amountLife;
    public HealthBar healthBar;
    public PlayerController player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            healthBar.SetHealth(player.GetHealth() + amountLife);
            gameObject.SetActive(false);
        }
    }
}
