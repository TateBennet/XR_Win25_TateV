using UnityEngine;

public class AppleStateManager : MonoBehaviour
{

    AppleBaseState currentState;
    public AppleGrowingState GrowingState = new AppleGrowingState();
    public AppleChewedState ChewedState = new AppleChewedState();
    public AppleRottenState RottenState = new AppleRottenState();
    public AppleWholeState WholeState = new AppleWholeState();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // starting state for the state machine
        currentState = GrowingState;

        // "this" is a reference to this exact monobehaviour script
        currentState.EnterState(this);
    }

    void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(AppleBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
