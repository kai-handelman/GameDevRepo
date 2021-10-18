using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCGotoPlayer : StateMachineBehaviour
{
    private RaycastHit2D rcH;
    [SerializeField] private Vector2[] PatrolArea;
    [SerializeField] private float MoveSpeed;
    private Vector2[] path;
    private Vector2 target;
    private int dummy;
    private Vector2 curGoal;
    private Transform moveNPC;

    private Transform t;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        t = animator.transform;
        dummy = 0;
        foreach (Vector2 coord in PatrolArea)
        {
            rcH = Physics2D.Raycast(coord, Vector2.up,0.1f);
            if (rcH && rcH.transform.CompareTag("Player"))
            {
                target = coord;
                path = animator.transform.gameObject.GetComponent<NPCFollow>().catchPlayer(target);
                animator.transform.gameObject.GetComponent<NPCFollow>().engage();
                rcH.transform.gameObject.GetComponent<PlayerAnimatorController>().changeFacing(path[path.Length-2]);
                curGoal = path[0];
                return;
            }
        }
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(t.position, curGoal) <= 0.05f)
        {
            dummy++;
            curGoal = path[dummy];
            if (dummy > path.Length - 2)//Stopping Condition is incorrect
            {
                Debug.Log("Go To Stopping");
                
                animator.SetInteger("Stage",2);
                return;
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
