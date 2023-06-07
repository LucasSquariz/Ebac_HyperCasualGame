using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public Animator animator;
    public List<AnimatorSetup> animatorSetups;
    public enum AnimationType
    {
        IDLE,
        RUN,
        DEAD
    }

    public void PlayAnimation(AnimationType type, float currentSpeedFactor = 1f)
    {
        foreach(var anim in animatorSetups)
        {
            if(anim.type == type)
            {
                animator.SetTrigger(anim.trigger);
                animator.speed = anim.speed * currentSpeedFactor;
                break;
            }
        }
    }    
}

[System.Serializable]
public class AnimatorSetup
{
    public AnimatorManager.AnimationType type;
    public string trigger;
    public float speed = 1f;
}
