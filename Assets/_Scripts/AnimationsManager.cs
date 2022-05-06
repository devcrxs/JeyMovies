using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class AnimationsManager : MonoBehaviour
{
    public static void DoScale(Transform target, Vector3 endValue, float duration)
    {
        target.DOScale(endValue, duration);
    }

    public static void DoMoveY(Transform target, float endValue, float duration)
    {
        target.DOMoveY(endValue, duration);
    }
    
    public static void DoMoveX(Transform target, float endValue, float duration)
    {
        target.DOMoveX(endValue, duration);
    }
    
    public static void DoFade(Image target,float valueFade, float duration)
    {
        target.DOFade(valueFade, duration);
    }
    
    public static void FadeChildrens(GameObject[] target,float valueFade, float duration)
    {
        for (int i = 0; i < target.Length; i++)
        {
            for (int j = 0; j < target[i].transform.childCount; j++)
            {
                if (target[i].transform.GetChild(j).TryGetComponent(out Image image))
                {
                    image.DOFade(valueFade, duration);
                }
            }
        }
    }
}
