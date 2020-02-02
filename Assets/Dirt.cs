using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : MonoBehaviour
{
    public DirtPot dirtPot;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Roomba>())
        {
            dirtPot.Fix();
            gameObject.SetActive(false);
        }
    }

}
