using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmsController : MonoBehaviour
{
    public GameObject leftArm, rightArm;
    private Animator animator;
    private AudioSource playerAudioSource;
    public AudioClip stabSound;
    // Start is called before the first frame update
    void Start()
    {
        //Assigning animator object
        animator = GetComponent<Animator>();
        //Assigning audio source
        playerAudioSource = GetComponentInParent<PlayerScript>().gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Checking if menu is not opened
        if (!GameManager.isMenuOpened)
        {
            //Attack with knife if player clicks left mouse button
            if (Input.GetMouseButtonDown(0))
                AttackKnife();
            //Move left arm if player clicks right mouse button
            else if (Input.GetMouseButtonDown(1))
                MoveLeftArm();
        }
    }

    void MoveLeftArm()
    {
        animator.SetTrigger("moveLeftArm");
        
    }

    void AttackKnife()
    {
        animator.SetTrigger("attackKnife");
        playerAudioSource.clip = stabSound;
        playerAudioSource.Play();
    }
}
