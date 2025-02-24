using UnityEngine;

public class AppleGrowingState : AppleBaseState
{

    Vector3 startingAppleSize = new Vector3(0.1f, 0.1f, 0.1f);
    Vector3 growAppleScalar = new Vector3(0.1f, 0.1f, 0.1f);
    public override void EnterState(AppleStateManager apple)
    {
        Debug.Log("hello from the growing state");
        apple.transform.localScale = startingAppleSize;
    }

    public override void UpdateState(AppleStateManager apple)
    {
        if(apple.transform.localScale.x < 1)
        {
            apple.transform.localScale += growAppleScalar * Time.deltaTime;
        } else
        {
            // immediately switch to the WholeState once complete
            apple.SwitchState(apple.WholeState);
        }
    }

    public override void OnCollisionEnter(AppleStateManager apple, Collision collision)
    {

    }
}
