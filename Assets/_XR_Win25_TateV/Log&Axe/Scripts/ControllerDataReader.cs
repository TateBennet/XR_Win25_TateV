using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// This script is in charge of reading data from the touch controllers
/// </summary>

public class ControllerDataReader : MonoBehaviour
{

    [SerializeField] InputActionProperty velocityProperty;
    
    public Vector3 Velocity { get; private set; } = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        Velocity = velocityProperty.action.ReadValue<Vector3>();
        Debug.Log("Velocity: " + Velocity);
    }
}
