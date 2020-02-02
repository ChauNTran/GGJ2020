using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameoverUI : MonoBehaviour
{
    [SerializeField] private GameObject timeoutGO;
    [SerializeField] private GameObject catWinGO;
    [SerializeField] private GameObject roombaWinGO;
    [SerializeField] private GameObject gameOverPanel;

    private void Start()
    {
        timeoutGO.SetActive(false);
        catWinGO.SetActive(false);
        roombaWinGO.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void DisPlayTimeOut()
    {
        gameOverPanel.SetActive(true);
        timeoutGO.SetActive(true);
        catWinGO.SetActive(true);

    }
    public void DisplayRoombaWin()
    {
        gameOverPanel.SetActive(true);
        roombaWinGO.SetActive(true);
    }

}
