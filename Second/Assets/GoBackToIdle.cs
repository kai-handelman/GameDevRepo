using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBackToIdle : StateMachineBehaviour {
    [SerializeField] private Vector2 IdlePosition;
    [SerializeField] private float MoveSpeed;
    private Vector2[] path;
    private Transform t;
    private int dummy;
    private Vector2 curGoal;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        t = animator.transform;
        dummy = 0;
        
        path = animator.transform.gameObject.GetComponent<NPCFollow>().catchPlayer(IdlePosition);
        curGoal = path[0];
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(t.position, curGoal) <= 0.05f)
        {
            dummy++;
            
            if (dummy == path.Length)
            {
                animator.SetInteger("Stage",0);
                
            }
            else
            {
                curGoal = path[dummy];
            }
        }
        else
        {
            t.position = Vector3.MoveTowards(t.position, curGoal, MoveSpeed);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
