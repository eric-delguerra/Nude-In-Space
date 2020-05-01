using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

    public float speed;     
    private Rigidbody2D rb2d;
    private List<GameObject> wearItems = new List<GameObject>();
    public int historyIndex = 0;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
       

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
        } else if (other.tag == "History")
        {
            StopMovement();
            GameObject.Find("HistoryZones").transform.GetChild(historyIndex).gameObject.GetComponentInChildren<DialogueTrigger>().TriggerDialogue();
            GameObject.Find("HistoryZones").transform.GetChild(historyIndex).gameObject.SetActive(false);
            historyIndex++;
        }
        
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
        rb2d.AddForce (movement * speed);
    }

    void StopMovement()
    {
        rb2d.velocity = Vector2.zero;
        gameObject.GetComponent<PlayerController>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}