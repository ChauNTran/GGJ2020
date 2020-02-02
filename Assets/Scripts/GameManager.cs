using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }
    public UIManager UImanager { get; private set; }

    public List<Objective> objectiveList = new List<Objective>();

    public float timeLeft = 180.0f;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        UImanager = GetComponentInChildren<UIManager>();
    }

    void Update()
    {
        runTimer();
    }

    public void runTimer()
    {

        timeLeft -= Time.deltaTime;

        if ( timeLeft < 0 )
        {
            GameOver();
        }
    }
    public void ObjectiveComplete(Objective obj)
    {
        Debug.Log(obj.gameObject.name);
        if (CheckForRoombaWinCondition())
            RoombaWin();
    }
    public void ObjectiveOpen(Objective obj)
    {
        if(!objectiveList.Contains(obj))
        {
            objectiveList.Add(obj);
        }
        if (obj is DirtPot)
            UImanager.SetPotUIActive();
    }
    private bool CheckForRoombaWinCondition()
    {
        int numberOfComplete = 0;
        bool roombaWin = true;

        foreach(var obj in objectiveList)
        {
            if (!obj.isCompleted)
                roombaWin = false;
            else
                numberOfComplete++;
        }
        return roombaWin;
    }
    void CatWin()
    {
        Debug.Log("CatWin");
        UImanager.DisplayCatwin();
    }
    void RoombaWin()
    {
        Debug.Log("RoombaWin");
        UImanager.DisplayRoombaWin();
    }
    private void GameOver()
    {
        UImanager.DisPlayTimeOut();
    }
}
