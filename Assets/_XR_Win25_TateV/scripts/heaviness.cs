using UnityEngine;

public class heaviness : MonoBehaviour
{
    Animator animator;
    [SerializeField] float heavy = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetFloat("weight", heavy);
    }

}
