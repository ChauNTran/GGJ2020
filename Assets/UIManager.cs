using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Roomba Canvas")]
    [SerializeField] private plungerUIHandler plungerUIRoomba;

    [Header("Cat Canvas")]
    [SerializeField] private plungerUIHandler plungerUICat;


    public void SetPlungerAccquire()
    {
        plungerUIRoomba.SetStatusAcquired();
        plungerUICat.SetStatusAcquired();
    }
    public void SetToiletComplete()
    {
        plungerUIRoomba.SetStatusCompleted();
        plungerUICat.SetStatusCompleted();
    }
}
