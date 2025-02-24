using System;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;


public class StoneSocket : MonoBehaviour
{
    [Tooltip("Drag one of the three spiritual stones in here")] //This allows us to display some text when hovering over the variable name in the editor.
    [SerializeField] private GameObject stoneReference;
    [SerializeField] string stoneTag;
    [SerializeField] SlidingDoor slidingDoor;
    [SerializeField] AudioSource audioSource;

    bool isOccupied = false;
    public static int stoneCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(stoneTag))
        {
            isOccupied = true;
            stoneCount++;

            Debug.Log($"{other.gameObject.name} gameobject entered the trigger and stone count is now {stoneCount}");
        }

        //if(stoneCount == 3)
        //{
        //    slidingDoor.Open();
        //    audioSource.Play();
        //}
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(stoneTag))
        {
            isOccupied = false;
            stoneCount--;
            Debug.Log($"{other.gameObject.name} gameobject exited the trigger and stone count is now {stoneCount}");
        }
    }
}


