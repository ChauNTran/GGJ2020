using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UIManager : MonoBehaviour
{
    [Header("Roomba Canvas")]
    [SerializeField] private plungerUIHandler plungerUIRoomba;
    [SerializeField] private clothesUI clothesUIRoomba;
    [SerializeField] private trashUI trashUIRoomba;
    [SerializeField] private dirtUI dirtUIRoomba;
    [SerializeField] private gameoverUI gameoverUIRoomba;
    [SerializeField] private Button playagainButton;
    [Header("Cat Canvas")]
    [SerializeField] private plungerUIHandler plungerUICat;
    [SerializeField] private clothesUI clothesUICat;
    [SerializeField] private trashUI trashUICat;
    [SerializeField] private dirtUI dirtUICat;
    [SerializeField] private gameoverUI gameoverUICat;

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

    public void SetClothesAccquire()
    {
        clothesUIRoomba.SetStatusAcquired();
        clothesUICat.SetStatusAcquired();
    }
    public void SetClothesComplete()
    {
        clothesUIRoomba.SetStatusCompleted();
        clothesUICat.SetStatusCompleted();
    }

    public void SetTrashAccquire()
    {
        trashUIRoomba.SetStatusAcquired();
        trashUICat.SetStatusAcquired();
    }
    public void SetTrashComplete()
    {
        trashUIRoomba.SetStatusCompleted();
        trashUICat.SetStatusCompleted();
    }
    public void DisPlayTimeOut()
    {
        gameoverUIRoomba.DisPlayTimeOut();
        gameoverUICat.DisPlayTimeOut();
        EventSystem.current.SetSelectedGameObject(playagainButton.gameObject);
    }
    public void DisplayRoombaWin()
    {
        gameoverUIRoomba.DisplayRoombaWin();
        gameoverUICat.DisplayRoombaWin();
        EventSystem.current.SetSelectedGameObject(playagainButton.gameObject);
    }
    public void SetPotUIActive()
    {
        dirtUIRoomba.setUIActive();
        dirtUICat.setUIActive();
    }
    public void SetPotNotComplete()
    {
        dirtUIRoomba.SetStatusNotCompleted();
        dirtUICat.SetStatusNotCompleted();
    }
    public void SetPotCompleted()
    {
        dirtUIRoomba.SetStatusCompleted();
        dirtUICat.SetStatusCompleted();
    }
}
