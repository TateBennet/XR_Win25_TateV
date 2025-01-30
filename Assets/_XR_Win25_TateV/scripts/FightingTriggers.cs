using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class FightingTriggers : MonoBehaviour
{
    public Animator animator;
    public PlayerInput playerInput;
    private InputAction punchAction;
    private InputAction kickAction;
    private InputAction jumpAction;
    private InputAction dieAction;

    void Awake()
    {
        // Get Animator component
        animator = GetComponent<Animator>();

        // Get PlayerInput component
        playerInput = GetComponent<PlayerInput>();

        // Assign input actions
        punchAction = playerInput.actions["punch"];
        kickAction = playerInput.actions["kick"];
        jumpAction = playerInput.actions["taunt"];
        dieAction = playerInput.actions["die"];
    }

    void Update()
    {
        // Check if punch key was pressed
        if (punchAction.WasPressedThisFrame())
        {
            animator.SetTrigger("punch");
        }

        // Check if kick key was pressed
        if (kickAction.WasPressedThisFrame())
        {
            animator.SetTrigger("kick");
        }

        // Check if jump key was pressed
        if (jumpAction.WasPressedThisFrame())
        {
            animator.SetTrigger("taunt");
        }

        // Check if jump key was pressed
        if (dieAction.WasPressedThisFrame())
        {
            animator.SetTrigger("die");
        }
    }
}
