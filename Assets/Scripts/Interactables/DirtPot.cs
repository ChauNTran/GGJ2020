using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtPot : MonoBehaviour,
                       IBreakable,
                       IFixable
{
    [SerializeField] private bool _canMess = true;
    public bool canMess
    {
        get { return _canMess; }
        set { _canMess = value; }
    }
    [SerializeField] private GameObject dirtPrefabGO;
    [SerializeField] private List<Transform> dirtSpawnPositions;
    [SerializeField] private List<GameObject> dirtGOs;

    private int activeDirtCount = 0;
    private void Start()
    {
        foreach (var pos in dirtSpawnPositions)
        {
            GameObject go = Instantiate(dirtPrefabGO, pos.position, Quaternion.identity);
            go.GetComponent<Dirt>().dirtPot = this;
            dirtGOs.Add(go);
            go.SetActive(false);
        }
    }
    public void Fix()
    {
        activeDirtCount --;
        if (activeDirtCount == 0)
            _canMess = true;
    }
    public void MessUp()
    {
        _canMess = false;

        foreach(var dirt in dirtGOs)
        {
            dirt.gameObject.SetActive(true);
            dirt.transform.position = dirtSpawnPositions[dirtGOs.IndexOf(dirt)].position;
            activeDirtCount++;
        }
    }
    public void ResetObject()
    {
        _canMess = true;
    }
}
