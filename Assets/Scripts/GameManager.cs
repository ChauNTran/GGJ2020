using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public List<Transform> allObjectiveTransform = new List<Transform>();
    public List<Transform> allToolTransform = new List<Transform>();

    public List<Transform> objectiveSpawns = new List<Transform>();
    public List<Transform> toolSpawns = new List<Transform>();

    private List<Transform> leftOverTools;
    public float timeLeft = 180.0f;
    public bool gameOver { get { return _gameOver; } }
    private bool _gameOver = false;
    private string currentSceneName;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        UImanager = GetComponentInChildren<UIManager>();
        currentSceneName = SceneManager.GetActiveScene().name;
    }
    private void Start()
    {
        _gameOver = false;

        RandomSpawnOjectives();
        RandomSpawnTools();
        leftOverTools = allToolTransform;
    }

    void RandomSpawnOjectives()
    {
        List<Transform> randomized_objectiveSpawn = ShuffleTransformList(objectiveSpawns);

        foreach(var obj in allObjectiveTransform)
        {
            obj.position = randomized_objectiveSpawn[allObjectiveTransform.IndexOf(obj)].position;
        }
    }
    void RandomSpawnTools()
    {
        List<Transform> randomized_toolSpawn = ShuffleTransformList(toolSpawns);

        foreach (var obj in allToolTransform)
        {
            obj.position = randomized_toolSpawn[allToolTransform.IndexOf(obj)].position;
        }
    }
    void Update()
    {
        if (_gameOver)
            return;

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
    public void ObjectiveComplete(Objective obj, Tool tool = null)
    {
        if (tool != null)
            leftOverTools.Remove(tool.transform);

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

    void RoombaWin()
    {
        Debug.Log("RoombaWin");
        _gameOver = true;
        UImanager.DisplayRoombaWin();
    }
    private void GameOver()
    {
        _gameOver = true;
        ShowLeftOverTools();
        UImanager.DisPlayTimeOut();
    }
    private void ShowLeftOverTools()
    {
        if(leftOverTools.Count>0)
        {
            foreach (var _tool in leftOverTools)
                _tool.GetComponent<Tool>().ShowInteractableAllLayers();
        }
    }
    private List<Transform> ShuffleTransformList(List<Transform> transformList)
    {
        // place them randomly
        // Knuth-Fisher-Yates algorithm
        List<Transform> shuffle_transform_list = transformList;
        int start = 0;
        int end = shuffle_transform_list.Count - 1;
        for (int i = end; i > 0; i--)
        {
            int swapWithPos = Random.Range(start, i + 1);
            // Swap the value at the "current" position (i) with value at swapWithPos
            Transform tmp = shuffle_transform_list[i];
            shuffle_transform_list[i] = shuffle_transform_list[swapWithPos];
            shuffle_transform_list[swapWithPos] = tmp;
        }
        return shuffle_transform_list;
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(currentSceneName);
    }
}
