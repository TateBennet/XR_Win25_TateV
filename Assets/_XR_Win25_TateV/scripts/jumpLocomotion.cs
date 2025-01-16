using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class jumpLocomotion : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] InputActionReference jumpInput;

    private void OnEnable()
    {
        jumpInput.action.performed += jump;
    }

    private void jump(InputAction.CallbackContext context)
    {
        Debug.Log("jump is pressed");
    }
}
