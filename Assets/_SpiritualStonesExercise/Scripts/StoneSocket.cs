using System;
using UnityEngine;
using UnityEngine.Events;
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

    #region
    public static event Action<StoneSocket, float> OnAllStonesPlaced;
    [SerializeField] UnityEvent sampleUnityEvent;

    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(stoneTag))
        {
            isOccupied = true;
            stoneCount++;
            
            if(stoneCount == 1)
            {
                sampleUnityEvent.Invoke();
            }

            if(stoneCount == 3)
            {
                OnAllStonesPlaced.Invoke(this,21.3f); //add a ? if getting error?
            }

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


