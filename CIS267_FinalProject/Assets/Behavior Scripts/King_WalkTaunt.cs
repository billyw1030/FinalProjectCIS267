using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King_WalkTaunt : StateMachineBehaviour
{
    private GameObject sirSheppard;
    private Rigidbody2D sirSheppardRigidBody;
    private SirSheppardStateManager stateManager;
    private Animator stateMachine;

    private float timer;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stateMachine = animator;
        sirSheppard = animator.gameObject.transform.parent.gameObject;
        stateManager = sirSheppard.GetComponent<SirSheppardStateManager>();
        sirSheppardRigidBody = sirSheppard.GetComponent<Rigidbody2D>();
        sirSheppardRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;

        stateManager.setForceRight(true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        sirSheppardRigidBody.velocity = new Vector2(2, sirSheppardRigidBody.velocity.y);
        if(timer >= 0.5)
        {
            stateMachine.SetTrigger("newRoom");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        sirSheppardRigidBody.velocity = new Vector2(0, sirSheppardRigidBody.velocity.y);
        sirSheppardRigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        stateManager.setForceRight(false);
        stateMachine.ResetTrigger("newRoom");
    }

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
