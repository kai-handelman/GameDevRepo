using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    // Todo
    // Add a reset System that will override current Datamanger System
    [SerializeField] private GameObject textBox;
    [SerializeField] private GameObject player;
    private bool talking;

    private void Start()
    {
        talking = false;
        FindObjectOfType<DataManager>().LoadDataFromJson();    
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) // Eventually Change this to event driven
        {
            FindObjectOfType<DataManager>().SaveIntoJson();
        }
        if (Input.GetKeyDown(KeyCode.A)) // Eventually Change this to event driven
        {
            player.GetComponent<PlayerController>().Interact();
        }

        if (player.GetComponent<PlayerController>().GetControllable() && !talking)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                player.GetComponent<PlayerController>().MoveContoller(true,new Vector2(Input.GetAxisRaw("Horizontal"),0));
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                player.GetComponent<PlayerController>().MoveContoller(true,new Vector2(0,Input.GetAxisRaw("Vertical")));
            }
            else
            {
                player.GetComponent<PlayerController>().MoveContoller(false,Vector2.zero);
            }
        }
    }

    public void ShowText(string displayText, bool done)
    {
        
        SetTalking(true);
        if (done)//Text has ended hid text box and make character is controllable now
        {
            Debug.Log("ji");
            textBox.SetActive(false);
            SetTalking(false);
            return;
        }
        textBox.SetActive(true);
        textBox.GetComponentInChildren<Text>().text = displayText;
    }

    public void SetTalking(bool t)
    {
        talking = t;
        if (t)
        {
            player.GetComponentInChildren<Animator>().SetBool("Moving",false);
        }
    }
}
