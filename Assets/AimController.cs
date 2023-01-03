using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AimController : MonoBehaviour
{
    public static AimController Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public Sprite aimSpriteBlack;
    public Sprite aimSpriteRed;

    public void ChangeAimSprite(bool isBlack)
    {
        if (isBlack)
        {
            GetComponentInChildren<Image>().sprite = aimSpriteBlack;
        }
        else
        {
            GetComponentInChildren<Image>().sprite = aimSpriteRed;
        }
    }

}
