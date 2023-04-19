using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RussianRadioCheckpoint : MonoBehaviour
{
    /// <summary>
    /// Top secret code from RussianBase
    /// </summary>
    public int TopSecretCode;
    /// <summary>
    /// Generating top secret code at Start
    /// </summary>
    void Start()
    {
        TopSecretCode = Random.Range(1000, 9999);
    }
}
