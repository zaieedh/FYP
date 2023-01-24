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
    public AudioClip sound, noAmmoSound;
    [SerializeField]
    private int ammo = 0;
    public int Ammo
    {
        get
        {
            return IsMelee ? 0 : ammo;
        }
        set
        {
            ammo = value;
            WeaponRelatedUI.Instance.ammoText.text = ammo.ToString();
        }
    }
    [SerializeField]
    private int maxAmmo = 0;
    public int MaxAmmo
    {
        get
        {
            return IsMelee ? 0 : maxAmmo;
        }
        set
        {
            maxAmmo = value;
            WeaponRelatedUI.Instance.maxAmmoText.text = maxAmmo.ToString();
        }
    }

    public void Attack()
    {
        if (IsMelee || Ammo > 0)
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
                Ammo-=1;
            }
            ArmsController.Instance.playerAudioSource.clip = sound;
            ArmsController.Instance.playerAudioSource.Play();
        }
        else
        {
            StartCoroutine(InfoTextUI.Instance.ShowInfo("No ammo", 2));
        }
    }
}
