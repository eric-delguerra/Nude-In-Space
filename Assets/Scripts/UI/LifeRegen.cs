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
            GetComponent<AudioSource>().Play();
            healthBar.SetHealth(player.GetHealth() + amountLife);
            StartCoroutine("Disable");
        }
    }

    private IEnumerator Disable()
    {
        yield return new WaitForSeconds(0.45f);
        gameObject.SetActive(false);
    }
}
