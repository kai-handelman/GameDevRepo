using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour {
    [SerializeField] private Animator anime;

    public void SetAnimation(float Direction,int axis, bool Moving)
    {
        if (!Moving)
        {
            anime.SetBool("Moving",false);
        }
        else
        {
            anime.SetBool("Moving",true);
            anime.SetInteger("Direction",axis+(int)Direction);
            
        }
    }
    
    public void changeFacing(Vector2 dirToLook)
    {
        Vector2 diff = (dirToLook-(Vector2) transform.position).normalized;
        anime.SetBool("Moving",false);
        GetComponent<PlayerController>().SetDir(diff);
        if (diff.x == 1)
        {
            anime.SetInteger("Direction",3);
            anime.Play("PlayerIdleRight");
        }else if (diff.x == -1)
        {
            anime.SetInteger("Direction",1);
            anime.Play("PlayerIdleLeft");
        }else if (diff.y == 1)
        {            
            anime.SetInteger("Direction",4);
            anime.Play("PlayerIdleUp");
        }
        else
        {
            anime.SetInteger("Direction",2);
            anime.Play("PlayerIdleDown");
        }
    }
}
