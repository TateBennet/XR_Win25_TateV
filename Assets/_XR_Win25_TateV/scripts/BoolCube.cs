using UnityEngine;

public class boolCube : MonoBehaviour
{
    private Animator cubeSpin;

    private void Start()
    {
       cubeSpin = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        cubeSpin.SetBool("isSpinning", true);
    }

    private void OnTriggerExit(Collider other)
    {
        cubeSpin.SetBool("isSpinning", false);
    }
}
