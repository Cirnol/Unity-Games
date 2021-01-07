using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/State")]
public class State : ScriptableObject
{
    public EnemyAction[] actions;
    public Transition[] transitions;

    public void UpdateState(EnemyStateController controller)
    {
        DoActions(controller);
        CheckTransitions(controller);
    }

    public void StopState(EnemyStateController controller)
    {
        foreach (EnemyAction action in actions)
        {
            action.Stop(controller);
        }
    }

    private void DoActions(EnemyStateController controller)
    {
        for(int i = 0; i < actions.Length; i++)
        {
            actions[i].Act(controller);
        }
    }

    private void CheckTransitions(EnemyStateController controller)
    {
        for (int i = 0;  i <transitions.Length; i++)
        {
            bool decisionTrue = transitions[i].decision.Decide(controller);

            if(decisionTrue)
            {
                controller.TransitionToState(transitions[i].trueState);
            }
            else
            {
                controller.TransitionToState(transitions[i].falseState);
            }
        }
    }
}
