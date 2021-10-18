using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    protected string [] talkText = {"Hi", "Hello", "Test", "Done"};
    protected int talkTextLength;
    private int talkTextIndex = 0;
    protected Vector2 pos;
    public GameObject gm;

    private void Start()
    {
        bConstruc();   
        // talkTextIndex = 0;
    }

    protected void bConstruc()
    {
        talkTextLength = talkText.Length;
        pos = transform.position;
        gm = GameObject.FindGameObjectWithTag("GameController");
    }

    public void Interact()
    {
        if (talkTextIndex == talkTextLength)
        {
            talkTextIndex = 0;
            gm.GetComponent<GameManager>().ShowText("", true);
            return;
        }

        gm.GetComponent<GameManager>().ShowText(talkText[talkTextIndex],false);
        talkTextIndex++;
    }

    public void engage()
    {
        gm.GetComponent<GameManager>().SetTalking(true);
        
    }
    
    
}
