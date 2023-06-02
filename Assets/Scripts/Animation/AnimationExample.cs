using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationExample : MonoBehaviour
{
    public Animation animation;

    public AnimationClip run;
    public AnimationClip idle;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayAnimation(run);
        }
        
        else if (Input.GetKeyDown(KeyCode.S))
        {
            PlayAnimation(idle);            
        }
    }
    public void PlayAnimation(AnimationClip clip)
    {        
        animation.CrossFade(clip.name);
    }
}
