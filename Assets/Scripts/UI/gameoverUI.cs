using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameoverUI : MonoBehaviour
{
    [SerializeField] private GameObject timeoutGO;
    [SerializeField] private GameObject catWinGO;
    [SerializeField] private GameObject roombaWinGO;


    private void Start()
    {
        timeoutGO.SetActive(false);
        catWinGO.SetActive(false);
        roombaWinGO.SetActive(false);
    }

    public void DisPlayTimeOut()
    {
        timeoutGO.SetActive(true);
        Invoke("DisplayCatwin", 2f);
    }
    public void DisplayRoombaWin()
    {
        roombaWinGO.SetActive(true);
    }
    public void DisplayCatwin()
    {
        timeoutGO.SetActive(false);
        catWinGO.SetActive(true);
    }
}
