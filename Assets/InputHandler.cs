using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{

    public GameObject actor;
    private Animator animator;
    private Command keyQ, keyW, keyE;

    void Start()
    {
        keyQ = new PerformJump();
        keyW = new PerformKick();
        keyE = new PerformPunch();
        animator = actor.GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            keyQ.Execute(animator);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            keyW.Execute(animator);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            keyE.Execute(animator);
        }
    }
}
