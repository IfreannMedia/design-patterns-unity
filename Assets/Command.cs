using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public abstract void Execute(Animator animator);

}

public class MoveForward : Command
{
    public override void Execute(Animator animator)
    {
        animator.SetTrigger("isWalking");
    }
}

public class PerformJump : Command
{
    public override void Execute(Animator animator)
    {
        animator.SetTrigger("isJumping");
    }
}

public class PerformPunch : Command
{
    public override void Execute(Animator animator)
    {
        animator.SetTrigger("isPunching");
    }
}

public class PerformKick : Command
{
    public override void Execute(Animator animator)
    {
        animator.SetTrigger("isKicking");
    }
}

public class DoNothing : Command
{
    public override void Execute(Animator animator)
    {

    }
}
