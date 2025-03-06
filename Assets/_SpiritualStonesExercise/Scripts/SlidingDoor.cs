using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.UI;


public class SlidingDoor : MonoBehaviour
{
    [SerializeField] private Transform openDooraPosition;
    [SerializeField] private Transform closeDoorPosition;
    [SerializeField] private AnimationCurve curve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

    [Tooltip("Slide movement duration in seconds")]
    [SerializeField] private float slideDuration = 5.0f;

    //[SerializeField] StoneSocket fireStoneSocket;
    //[SerializeField] StoneSocket forestStoneSocket;
    //[SerializeField] StoneSocket waterStoneSocket;

    private Coroutine doorSlideCoroutine;

    private void OnEnable()
    {
        //subscribing to my event notifications
        StoneSocket.OnAllStonesPlaced += Open;
        //forestStoneSocket.OnAllStonesPlaced += Open;
        //waterStoneSocket.OnAllStonesPlaced += Open;
    }

    private void OnDisable()
    {
        //unsubscribing to my event notifications
        StoneSocket.OnAllStonesPlaced -= Open;
        //forestStoneSocket.OnAllStonesPlaced -= Open;
        //waterStoneSocket.OnAllStonesPlaced -= Open;
    }

    void Start()
    {
        Close();
    }

    IEnumerator SlideDoor(Vector3 endPosition)
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0;

        while (elapsedTime < slideDuration)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / slideDuration;

            transform.position = Vector3.Lerp(startPosition, endPosition, curve.Evaluate(percentageComplete));
            yield return null;
        }
        transform.position = endPosition; // Ensure the exact target position is reached
    }

    [ContextMenu("Open")] // This allows running the function from the Editor to test it (dotStack Menu next to Component Name). Only works for functions with no parameters.
    void Open( StoneSocket socket, float inValue)
    {
        StopDoorSlideCoroutine(); // Stop any existing coroutine to avoid conflicts
        doorSlideCoroutine = StartCoroutine(SlideDoor(openDooraPosition.position));

        Debug.Log("the " + socket.gameObject.name + " opened the door");
    }

    [ContextMenu("Close")]
    public void Close()
    {
        StopDoorSlideCoroutine();
        doorSlideCoroutine = StartCoroutine(SlideDoor(closeDoorPosition.position));
    }

    void StopDoorSlideCoroutine()
    {
        if (doorSlideCoroutine != null)
        {
            StopCoroutine(doorSlideCoroutine);
            doorSlideCoroutine = null;
        }
    }
}


