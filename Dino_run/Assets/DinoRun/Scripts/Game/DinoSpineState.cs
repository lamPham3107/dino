using Spine.Unity;
using UnityEngine;

public class DinoSpineState : StateMachineBehaviour
{
    public string spineAnimation;
    public bool loop;

    private SkeletonAnimation skeleton;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (skeleton == null)
            skeleton = animator.GetComponent<SkeletonAnimation>();

        skeleton.AnimationState.SetAnimation(0, spineAnimation, loop);
    }
}
