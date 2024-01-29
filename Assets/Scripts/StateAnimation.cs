using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StateAnimation : MonoBehaviour
{
    [MenuItem("MyMenu/Create Controller")]
    static void CreateController()
    {

        // Creates the controller
        var controller = UnityEditor.Animations.AnimatorController.CreateAnimatorControllerAtPath("Assets/Prefab/StateMachineTransitions.controller");
        
        // Add parameters

        // Add StateMachines
        var rootStateMachine = controller.layers[0].stateMachine;

        // Add States
        var stateA1 = rootStateMachine.AddState("stateA1");

        // Add Transitions
        var exitTransition = stateA1.AddExitTransition();

        var resetTransition = rootStateMachine.AddAnyStateTransition(stateA1);
    }
}
