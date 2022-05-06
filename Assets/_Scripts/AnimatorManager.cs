using UnityEngine;
public class AnimatorManager : MonoBehaviour
{
    public static void AnimatorTrigger(Animator anim, string param)
    {
        anim.SetTrigger(param);
    }

    public static void AnimatorPlay(Animator anim, string param)
    {
        anim.Play(param,Constans.ZERO);
    }
}
