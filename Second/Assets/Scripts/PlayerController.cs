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
    Vector3 dir = Vector2.down;

    void Start()
    {
        movePoint.parent = null;
        t = transform;
        pAC = GetComponent<PlayerAnimatorController>();
    }


    void Update()
    {
        t.position = Vector3.MoveTowards(t.position, movePoint.position, MoveSpeed * Time.deltaTime);
        if (Vector3.Distance(t.position, movePoint.position) <= 0.05f) // If not true char is mid movement
        {
            isControllable = true;
        }
        else
        {
            isControllable = false;
        }
    }

    
    public bool GetControllable()
    {
        return isControllable;
    }
    
    
    public void Interact() //Make this Event driven As well
    {
        // Make sure is in dialgue will check if true
        // Text.next state for text box 
        // Check if text ended and then Switch the state
        RaycastHit2D target = Physics2D.Raycast(t.position, dir, 1f, interActableObjects);
        if (target)
        {
            target.transform.gameObject.GetComponent<NPCController>().Interact();
        }
    }

    public void MoveContoller(bool input,Vector3 ndir)
    {
        if (input)
        {
            dir = ndir;
            
            if (dir.x != 0)
            {
                if (!Physics2D.Raycast(t.position, new Vector2(Input.GetAxisRaw("Horizontal"), 0), 1.1f,
                    interActableObjects | block))
                {
                    movePoint.position += dir;
                }

                pAC.SetAnimation(Input.GetAxisRaw("Horizontal"), 2, true);
            }
            else if (dir.y != 0)
            {
                if (!Physics2D.Raycast(t.position, new Vector2(0, Input.GetAxisRaw("Vertical")), 1.1f,
                    interActableObjects | block))
                {
                    movePoint.position += dir;
                }

                pAC.SetAnimation(Input.GetAxisRaw("Vertical"), 3, true);
            }
        }
        else
            pAC.SetAnimation(0, 0,false);
    }

    public void SetDir(Vector2 ndir)
    {
        dir = ndir;
    }    
}
