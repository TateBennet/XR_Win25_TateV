using UnityEngine;

public class collision : MonoBehaviour
{
    public Animator animator;  // Reference to the Animator

    // Trigger Zone Detection
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("walking", false);
        }
    }
}
