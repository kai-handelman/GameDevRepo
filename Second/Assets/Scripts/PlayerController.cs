using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float MoveSpeed = 5f;
    [SerializeField] private Transform movePoint;
    [SerializeField] private LayerMask block;
    [SerializeField] private LayerMask interActableObjects;
    [SerializeField] private GameObject textBox;

    private bool isControllable = true;
    private Transform t;
    private PlayerAnimatorController pAC;
    private Vector3 dir = new Vector2(0,-1);
    void Start()
    {
        movePoint.parent = null;
        t = transform;
        pAC = GetComponent<PlayerAnimatorController>();
    }


    void Update()
    {
        t.position = Vector3.MoveTowards(t.position, movePoint.position, MoveSpeed * Time.deltaTime);
        input();
    }

    
    public void input()
    {
        if (Vector3.Distance(t.position, movePoint.position) <= 0.05f) // If not true char is mid movement
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Interact(); 
            }

            if (isControllable)
            {
                MoveContoller();
            }
        }
    }
    
    
    private void Interact() //Make this Event driven As well
    {
        // Make sure is in dialgue will check if true
        // Text.next state for text box 
        // Check if text ended and then Switch the state
        RaycastHit2D target = Physics2D.Raycast(t.position, dir, 1f, interActableObjects);
        
        if (target)
        {
            isControllable = false;
            var textInfo = target.transform.gameObject.GetComponent<NPCController>().Interact();
            if (!textInfo.Item2)//Text has ended hid text box and make character is controllable now
            {
                isControllable = true;
                textBox.SetActive(false);
                //hide textbox
                return;
            }

            textBox.SetActive(true);

            textBox.GetComponentInChildren<Text>().text = textInfo.Item1;
            
            
            Debug.Log("Hello");
        }
    }

    private void MoveContoller()
    {
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
        {
            dir = new Vector2(Input.GetAxisRaw("Horizontal"),0);
            if (!Physics2D.Raycast(t.position, new Vector2(Input.GetAxisRaw("Horizontal"), 0),1.1f,interActableObjects|block))
            {
                movePoint.position += dir;
            }

            
            pAC.SetAnimation(Input.GetAxisRaw("Horizontal"), 2,true);
        }
        else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
        {
            dir = new Vector2(0,Input.GetAxisRaw("Vertical"));
            if (!Physics2D.Raycast(t.position, new Vector2(0,Input.GetAxisRaw("Vertical")),1.1f,interActableObjects|block))
            {
                movePoint.position += dir;
            }
            pAC.SetAnimation(Input.GetAxisRaw("Vertical"), 3,true);
        }else
            pAC.SetAnimation(0, 0,false);
    }
}
