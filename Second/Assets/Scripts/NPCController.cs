using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    string [] talkText = {"Hi", "Hello", "Test", "Done"};
    private int talkTextLength;
    private int talkTextIndex = 0;
    protected Vector2 pos;

    private void Start()
    {
        talkTextLength = talkText.Length;
        pos = transform.position;
    }

    public Tuple<string,bool> Interact()
    {
        if (talkTextIndex + 1 > talkTextLength)
        {
            talkTextIndex = 0;
            return  Tuple.Create("", false);
        }
        var interactInfo = Tuple.Create( talkText[talkTextIndex], true);
        talkTextIndex += 1;
        return interactInfo;
    }
}
