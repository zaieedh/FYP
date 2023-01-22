using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmsController : MonoBehaviour
{
    public GameObject leftArm, rightArm;
    private Animator animator;
    public AudioSource playerAudioSource;
    public AudioClip stabSound;

    public static ArmsController Instance { get; private set; }
    
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
    // Start is called before the first frame update
    void Start()
    {
        //Assigning animator object
        animator = GetComponent<Animator>();
        //Assigning audio source
        playerAudioSource = GetComponentInParent<PlayerScript>().gameObject.GetComponent<AudioSource>();
    }

    public void MoveLeftArm()
    {
        animator.SetTrigger("moveLeftArm");
        
    }

    public void MoveRightArm()
    {
        animator.SetTrigger("attackKnife");
    }

    public void ShotGun()
    {
        animator.SetTrigger("shotGun");
    }
}
