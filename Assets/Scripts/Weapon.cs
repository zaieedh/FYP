using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    /// <summary>
    /// Damage of weapon it's gonna deal
    /// </summary>
    public int Damage = 5;
    /// <summary>
    /// Attack range of weapon
    /// </summary>
    public float Range = 5;
    /// <summary>
    /// Name of weapon
    /// </summary>
    public string Name = "Weapon";
    /// <summary>
    /// Checking if weapon is equipped
    /// </summary>
    public bool IsEquipped = false;
    /// <summary>
    /// Checking if weapon is Melee
    /// </summary>
    public bool IsMelee = false;
    /// <summary>
    /// Sound of weapon once player attacks with it
    /// No ammo sound that will be heard once player has no more ammo on range weapon
    /// </summary>
    public AudioClip sound, noAmmoSound;
    /// <summary>
    /// Current ammo
    /// </summary>
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
    /// <summary>
    /// Max ammo
    /// </summary>
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
    /// <summary>
    /// Check if player is currently attacking
    /// </summary>
    private bool attacking = false;
    /// <summary>
    /// Attack with weapon based on type of weapon
    /// </summary>
    public void Attack()
    {
        if (!attacking)
        {
			attacking = true;
			if (IsMelee || Ammo > 0)
            {
                if (IsMelee)
                {
                    //Do melee attack
                    ArmsController.Instance.MoveRightArm();
					attacking = false;
				}
                else
                {
                    //Do ranged attack
                    ArmsController.Instance.ShotGun();
                    Ammo -= 1;
                    StartCoroutine(WaitTillAnimationEnds());

                }
                ArmsController.Instance.playerAudioSource.clip = sound;
                ArmsController.Instance.playerAudioSource.Play();
            }
            else
            {
                StartCoroutine(InfoTextUI.Instance.ShowInfo("No ammo! Click [R] to reload", 2));
                attacking = false;
            }
        }
    }
    /// <summary>
    /// Waiting till animation of attacking ends
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitTillAnimationEnds()
    {
        yield return new WaitForSeconds(0.4f);
        attacking = false;
    }

	private void Update()
	{
        //Realoading weapon once player clicks R button
		if(Input.GetKeyDown(KeyCode.R) && Ammo == 0)
        {
            StartCoroutine(ReloadAmmo());
        }
	}
    /// <summary>
    /// Reloading ammo
    /// </summary>
    /// <returns></returns>
	IEnumerator ReloadAmmo()
    {
        MaxAmmo -= 1;
        if (MaxAmmo > 0)
        {
            yield return new WaitForSeconds(0f);
            Ammo = 10;
        }
	}
}
