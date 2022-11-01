using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmsController : MonoBehaviour
{
    public GameObject leftArm, rightArm;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            AttackKnife();
    }

    void MoveLeftArm()
    {
        animator.SetTrigger("moveLeftArm");
        Debug.Log("Left arm moved");
    }

    void AttackKnife()
    {
        animator.SetTrigger("attackKnife");
        Debug.Log("attacked");
    }
}
