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
}
