using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float MoveSpeed = 5f;
    [SerializeField] private Transform movePoint;
    [SerializeField] private LayerMask block;
    
    
    private Transform t;
    private PlayerAnimatorController pAC;
    void Start()
    {
        movePoint.parent = null;
        t = transform;
        pAC = GetComponent<PlayerAnimatorController>();
    }

    // Update is called once per frame
    void Update()
    {
        t.position = Vector3.MoveTowards(t.position, movePoint.position, MoveSpeed * Time.deltaTime);
        if (Vector3.Distance(t.position, movePoint.position) <= 0.05f)
        {
            MoveContoller();
        }
        
    }

    private void MoveContoller()
    {
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f && !Physics2D.Raycast(t.position, new Vector2(Input.GetAxisRaw("Horizontal"), 0),1.1f,block))
        {
            movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0);
            pAC.SetAnimation(Input.GetAxisRaw("Horizontal"), 2,true);
        }
        else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f  && !Physics2D.Raycast(t.position, new Vector2(0,Input.GetAxisRaw("Vertical")),1.1f,block))
        {
            movePoint.position += new Vector3(0, Input.GetAxisRaw("Vertical"));
            pAC.SetAnimation(Input.GetAxisRaw("Vertical"), 3,true);
        }else
            pAC.SetAnimation(0, 0,false);
    }
}
