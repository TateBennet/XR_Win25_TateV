using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayDeathAnim()
    {
        animator.SetTrigger("die");
    }

    public void PlayThumbsUp()
    {
        animator.SetTrigger("thumb");
    }

    public void PlayWaveAnim()
    {
        animator.SetTrigger("wave");
    }
}
