using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBed : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Cat>() != null)
        {
            collision.gameObject.GetComponent<Cat>().setTookNap();
        }
    }

}
