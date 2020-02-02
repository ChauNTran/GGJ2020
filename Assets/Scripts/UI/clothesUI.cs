using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clothesUI : MonoBehaviour
{
    [SerializeField] private GameObject checkSprite;
    [SerializeField] private UnityEngine.UI.Image clothesImage;


    void Start()
    {
        clothesImage.color = new Color(1, 1, 1, 0.3f);

        checkSprite.SetActive(false);
    }

    public void SetStatusAcquired()
    {
        clothesImage.color = new Color(1, 1, 1, 1f);
    }

    public void SetStatusCompleted()
    {
        checkSprite.SetActive(true);
    }
}