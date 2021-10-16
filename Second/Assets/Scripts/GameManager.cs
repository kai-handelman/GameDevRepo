using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Android;

public class GameManager : MonoBehaviour {
    // Todo
    // Add a reset System that will override current Datamanger System

    private GameState curState = GameState.Overworld;
    private void Start()
    {
        FindObjectOfType<DataManager>().LoadDataFromJson();    
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) // Eventually Change this to event driven
        {
            FindObjectOfType<DataManager>().SaveIntoJson();
        }
    }
    enum GameState {
        Overworld,
        Dialogue
    }

    public int getState()
    {
        return (int)curState;
    }

    public void setState(int newState)
    {
        curState = (GameState) newState;
    }
}
