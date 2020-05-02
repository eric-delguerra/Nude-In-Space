using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private int health;
    private int maxHealth = 100;
    private Rigidbody2D rb2d;
    public Targets[] targetses;
    private int indexTarget = 0; 
    private List<GameObject> wearItems = new List<GameObject>();
    public int historyIndex = 0;
    public HealthBar HealthBar;
    public TextMeshProUGUI objectifText;
    

    void Start()
    {
        
        rb2d = GetComponent<Rigidbody2D>();
        health = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);
        InvokeRepeating("Oxygen", 1f, 1f);
                     
   }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wear")
        {
            wearItems.Add(other.gameObject);
            foreach (var wear in wearItems)
            {
                print(wear.name);
            }

            GameObject.Find("WearsItems").gameObject.GetComponentInChildren<DialogueTrigger>().TriggerDialogue();
            StopMovement();
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "History")
        {
            StopMovement();
            GameObject.Find("HistoryZones").transform.GetChild(historyIndex).gameObject
                .GetComponentInChildren<DialogueTrigger>().TriggerDialogue();
            GameObject.Find("HistoryZones").transform.GetChild(historyIndex).gameObject.SetActive(false);
            historyIndex++;
        }
    }

    void FixedUpdate()
    {
       Movement();
       print(Mathf.Round(Vector2.Distance(transform.position, targetses[0].targetPosition)));
       objectifText.text = targetses[indexTarget].name + " se trouve à " +
                           Mathf.Round(Vector2.Distance(transform.position, targetses[0].targetPosition)) + "m.";

    }

    private void Oxygen()
    {
        health -= 1;
        HealthBar.SetHealth(health);
    }

    void StopMovement()
    {
        rb2d.velocity = Vector2.zero;
        gameObject.GetComponent<PlayerController>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Movement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    public int GetHealth()
    {
        return health;
    }

    public void SetHealth(int amount)
    {
        health = amount;
    }
}