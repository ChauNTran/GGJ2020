using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plungerUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject checkSprite;
    [SerializeField] private UnityEngine.UI.Image plungerImage;


    void Start()
    {
        //load sprites
        //plungerImage = GetComponent<UnityEngine.UI.Image>();
        plungerImage.color = new Color(1, 1, 1, 0.3f);

        checkSprite.SetActive(false);
    }

    public void SetStatusAcquired()
    {
        plungerImage.color = new Color(1, 1, 1, 1f);
    }

    public void SetStatusCompleted()
    {
        checkSprite.SetActive(true);
    }
}
