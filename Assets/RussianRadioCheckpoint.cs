using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RussianRadioCheckpoint : MonoBehaviour
{
    public int TopSecretCode;
    void Start()
    {
        TopSecretCode = Random.Range(1000, 9999);
    }
}
