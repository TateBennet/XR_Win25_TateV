using UnityEngine;

public class TriggerDoor : MonoBehaviour
{

    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent <Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger("open");
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetTrigger("close");
    }
}
