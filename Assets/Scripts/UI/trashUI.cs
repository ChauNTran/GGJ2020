using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashUI : MonoBehaviour
{
    [SerializeField] private GameObject checkSprite;
    [SerializeField] private UnityEngine.UI.Image trashImage;


    void Start()
    {
        //load sprites
        //trashImage = GetComponent<UnityEngine.UI.Image>();
        trashImage.color = new Color(1, 1, 1, 0.3f);

        checkSprite.SetActive(false);
    }

    public void SetStatusAcquired()
    {
        trashImage.color = new Color(1, 1, 1, 1f);
    }

    public void SetStatusCompleted()
    {
        checkSprite.SetActive(true);
    }
}
