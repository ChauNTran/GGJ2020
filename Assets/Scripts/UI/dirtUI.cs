using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dirtUI : MonoBehaviour
{
    [SerializeField] private GameObject dirtUIgo;

    [SerializeField] private GameObject checkSprite;
    [SerializeField] private UnityEngine.UI.Image potImage;


    private void Start()
    {
        dirtUIgo.SetActive(false);
    }
    public void setUIActive()
    {
        dirtUIgo.SetActive(true);

        potImage.color = new Color(1, 1, 1, 0.3f);

        checkSprite.SetActive(false);
    }

    public void SetStatusAcquired()
    {
        potImage.color = new Color(1, 1, 1, 1f);
    }

    public void SetStatusCompleted()
    {
        checkSprite.SetActive(true);
    }
}
