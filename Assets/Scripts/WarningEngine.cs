using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class WarningEngine : MonoBehaviour
{
    [SerializeField] private List<Text> texts;
    public static WarningEngine instance;
    public bool trigger = false;
    private bool exitAreaTrigger = false;
    private float timer = 10f;
    public Image img;
    public float fadeRate = 10f;


    public Text timerText;
    public GameObject UiArt;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (trigger)
        {
            for (int i = 0; i < texts.Count; i++)
            {
                texts[i].gameObject.SetActive(true);
            }
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("F1"); //Pour voir uniquement 1 float
            FadeImage(1.0f);
            if (timer <= 0f)
            {
                print("Refroidi");
                trigger = false;
            }
        }

        if (!trigger && timer < 10)
        {
            for (int i = 0; i < texts.Count; i++)
            {
                texts[i].gameObject.SetActive(false);
            }
            FadeImage(0f);
            timer += Time.deltaTime;
            if (timer >= 10f)
            {
                UiArt.SetActive(false);
            }
            {
                
            }
        }
    }

    public void EnterArea()
    {
        UiArt.SetActive(true);
        trigger = true;
    }

    public void ExitArea()
    {
        trigger = false;
    }

    private void FadeImage(float targetAlpha)
    {
        Color curColor = img.color;
        float alphaDiff = Mathf.Abs(curColor.a - targetAlpha);
        if (alphaDiff > 0.0001f)
        {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, fadeRate * Time.deltaTime);
            img.color = curColor;
        }
    }
}