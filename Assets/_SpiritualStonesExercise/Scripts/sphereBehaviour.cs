using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class sphereBehaviour : MonoBehaviour
{

    [SerializeField] StoneSocket fireStoneSocket;
    [SerializeField] StoneSocket forestStoneSocket;
    [SerializeField] StoneSocket waterStoneSocket;

    private void OnEnable()
    {
        StoneSocket.OnAllStonesPlaced += Disappear;
        //forestStoneSocket.OnAllStonesPlaced += Disappear;
        //waterStoneSocket.OnAllStonesPlaced += Disappear;
    }

    private void OnDisable()
    {
        //unsubscribing to my event notifications
        StoneSocket.OnAllStonesPlaced -= Disappear;
        //forestStoneSocket.OnAllStonesPlaced -= Disappear;
        //waterStoneSocket.OnAllStonesPlaced -= Disappear;
    }

    private void Disappear(StoneSocket socket, float inValue)
    {
        gameObject.SetActive(false);
    }
}
