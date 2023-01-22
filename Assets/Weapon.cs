using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int Damage = 5;
    public float Range = 5;
    public string Name = "Weapon";
    public bool IsEquipped = false;
    public bool IsMelee = false;
    public AudioClip sound;

    public void Attack()
    {
        if (IsMelee)
        {
            //Do melee attack
            ArmsController.Instance.MoveRightArm();
        }
        else
        {
            //Do ranged attack
            ArmsController.Instance.ShotGun();
        }
        ArmsController.Instance.playerAudioSource.clip = sound;
        ArmsController.Instance.playerAudioSource.Play();
    }
}
