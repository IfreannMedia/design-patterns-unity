using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public abstract void Execute(Animator animator, bool forward = true);

}

public class MoveForward : Command
{
    public override void Execute(Animator animator, bool forward)
    {
        animator.SetTrigger("isWalking" + (forward ? "" : "R"));
    }
}

public class PerformJump : Command
{
    public override void Execute(Animator animator, bool forward)
    {
        animator.SetTrigger("isJumping" + (forward ? "" : "R"));
    }
}

public class PerformPunch : Command
{
    public override void Execute(Animator animator, bool forward)
    {
        animator.SetTrigger("isPunching" + (forward ? "" : "R"));
    }
}

public class PerformKick : Command
{
    public override void Execute(Animator animator, bool forward)
    {
        animator.SetTrigger("isKicking" + (forward ? "" : "R"));
    }
}

public class DoNothing : Command
{
    public override void Execute(Animator animator, bool forward)
    {

    }
}
