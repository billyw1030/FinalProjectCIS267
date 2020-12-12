using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King_IdleWatch : StateMachineBehaviour
{
    private GameObject sirSheppard;
    private SirSheppardStateManager stateManager;
    private MoveTrigger moveTrigger;
    private Animator stateMachine;
    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stateMachine = animator;
        sirSheppard = animator.gameObject.transform.parent.gameObject;
        stateManager = sirSheppard.GetComponent<SirSheppardStateManager>();
        moveTrigger = stateManager.getTrigger().GetComponent<MoveTrigger>();
        setupTrigger();
        stateManager.setIsFighting(true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {


    }

    private void setupTrigger()
    {
        moveTrigger.setManagingScript(this);
    }

    public void activateTrigger()
    {
        stateMachine.SetTrigger("moveTrigger");
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stateMachine.ResetTrigger("moveTrigger");
        stateManager.setIsFighting(false);
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
