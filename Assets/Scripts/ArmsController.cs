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
        animator = GetComponent<Animator>();
        playerAudioSource = GetComponentInParent<PlayerScript>().gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.isMenuOpened)
        {
            if (Input.GetMouseButtonDown(0))
                AttackKnife();
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
