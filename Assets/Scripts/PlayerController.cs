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
    public LifeReduce[] dangerItems;
    private int indexTarget = 0; 
    private List<GameObject> wearItems = new List<GameObject>();
    public int historyIndex = 0;
    public HealthBar HealthBar;
    public TextMeshProUGUI objectifText;
    public Animator animator;
    

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
            StartCoroutine(VolumeLow(other));
            wearItems.Add(other.gameObject);
            other.GetComponent<DialogueTrigger>().TriggerDialogue(true);
            StopMovement();
        }
        else if (other.tag == "History")
        {
            StopMovement();
            GameObject.Find("HistoryZones").transform.GetChild(historyIndex).gameObject
                .GetComponentInChildren<DialogueTrigger>().TriggerDialogue(false);
            GameObject.Find("HistoryZones").transform.GetChild(historyIndex).gameObject.SetActive(false);
            historyIndex++;
        }
    }

    private IEnumerator VolumeLow(Collider2D other)
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().volume -= 0.2f;
        yield return new WaitForSeconds(0.45f);
        other.gameObject.SetActive(false);

    }

    private void Update()
    {
        // for (int i = 0; i < dangerItems.Length; i++)
        // {
        //     if (Mathf.Round(Vector2.Distance(transform.position, dangerItems[i].targetPosition)) < 10f)
        //     {
        //         // dangerItems[i].gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.position.x, transform.position.y));
        //     }
        // }
    }

    void FixedUpdate()
    {
       Movement();
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
        if (moveHorizontal < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        float moveVertical = Input.GetAxis("Vertical");
        animator.SetFloat("Speed", Mathf.Abs(moveHorizontal + moveVertical));
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