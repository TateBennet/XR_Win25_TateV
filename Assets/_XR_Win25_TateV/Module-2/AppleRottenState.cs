using UnityEngine;
using UnityEngine.Rendering;

public class AppleRottenState : AppleBaseState
{

    private Renderer appleRenderer;

    public override void EnterState(AppleStateManager apple)
    {
        Debug.Log("hello from the rotten state");
        appleRenderer = apple.GetComponent<Renderer>();
        appleRenderer.material.color = new Color(0f, 0f, 0f);

    }

    public override void UpdateState(AppleStateManager apple)
    {

    }

    public override void OnCollisionEnter(AppleStateManager apple, Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            // would implement if i had a robust character controller
            // other.GetComponent<PlayerController>().detractHealth();

            apple.SwitchState(apple.ChewedState);
            Debug.Log("Eww, health down!");
        }
    }
}
