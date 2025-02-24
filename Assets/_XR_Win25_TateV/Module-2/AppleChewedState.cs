using UnityEngine;

public class AppleChewedState : AppleBaseState
{

    float destroyCountdown = 5.0f;

    public override void EnterState(AppleStateManager apple)
    {
        Debug.Log("hello from the chewed state");
    }

    public override void UpdateState(AppleStateManager apple)
    {
        if(destroyCountdown > 0)
        {
            destroyCountdown -= Time.deltaTime;
        }
        else
        {
            Object.Destroy(apple.gameObject);
        }
    }

    public override void OnCollisionEnter(AppleStateManager apple, Collision collision)
    {

    }
}
