using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{

    public GameObject actor;
    private Animator animator;
    private Command keyQ, keyW, keyE, upArrow;
    private List<Command> oldCommands = new List<Command>();

    private Coroutine replayCoroutine;
    private bool shouldStartReplay;
    private bool isReplaying;

    void Start()
    {
        keyQ = new PerformJump();
        keyW = new PerformKick();
        keyE = new PerformPunch();
        upArrow = new MoveForward();
        animator = actor.GetComponent<Animator>();
        Camera.main.GetComponent<CameraFollow360>().player = actor.transform;
    }


    void Update()
    {
        if (!isReplaying)
            HandleInput();
        if (Input.GetKeyDown(KeyCode.Space))
            shouldStartReplay = true;
        StartReplay();
    }

    private void StartReplay()
    {
        if( shouldStartReplay && oldCommands.Count > 0)
        {
            shouldStartReplay = false;
            if(replayCoroutine != null)
            {
                StopCoroutine(replayCoroutine);
            }
            replayCoroutine = StartCoroutine(ReplayCommands());
        }
    }

    private IEnumerator ReplayCommands()
    {
        isReplaying = true;
        for (int i = 0; i < oldCommands.Count; i++)
        {
            oldCommands[i].Execute(animator);
            yield return new WaitForSeconds(1.0f);
        }
        isReplaying = false;
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            keyQ.Execute(animator);
            oldCommands.Add(keyQ);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            keyW.Execute(animator);
            oldCommands.Add(keyW);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            keyE.Execute(animator);
            oldCommands.Add(keyE);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            upArrow.Execute(animator);
            oldCommands.Add(upArrow);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            UndoLastCommand();
        }
    }

    private void UndoLastCommand()
    {
        if(oldCommands.Count > 0)
        {
            Command c = oldCommands[oldCommands.Count - 1];
            c.Execute(animator, false);
            oldCommands.RemoveAt(oldCommands.Count - 1);
        }
    }
}
