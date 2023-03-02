using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmsController : MonoBehaviour
{
    /// <summary>
    /// Instances of left and right arm objects of player
    /// </summary>
    public GameObject leftArm, rightArm;
    /// <summary>
    /// Instance of animator that holds information about states of animations
    /// </summary>
    private Animator animator;
    /// <summary>
    /// Instance of audio source attached to player
    /// </summary>
    public AudioSource playerAudioSource;
    /// <summary>
    /// Sound of stabbing used once user stabs with knife
    /// </summary>
    public AudioClip stabSound;
    /// <summary>
    /// Instance of arms controller
    /// </summary>
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

    /// <summary>
    /// Triggering moveLeftArm trigger, so player will move with his left arm
    /// </summary>
    public void MoveLeftArm()
    {
        animator.SetTrigger("moveLeftArm");
        
    }
    /// <summary>
    /// Triggering moveRightArm trigger so player will move with his right arm
    /// </summary>
    public void MoveRightArm()
    {
        animator.SetTrigger("attackKnife");
    }
    /// <summary>
    /// Triggering shotGun animation, so player will shot gun
    /// </summary>
    public void ShotGun()
    {
        animator.SetTrigger("shotGun");
    }
}
