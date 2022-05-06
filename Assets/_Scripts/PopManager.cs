using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;
public class PopManager : MonoBehaviour
{
    private float maxPosPopY = 1;
    private float minPosPopY = 0.5f;
    private float maxPosPopX = 3.5f;
    private float minPosPopX = -3.5f;
    private float durationScale = 0.3f;
    private float durationMove = 0.5f;
    private float durationFade = 0.3f;
    private GameObject popActual;
    [SerializeField] private Image backgroundPop;
    [SerializeField] private GameObject[] pops;

    private void Start()
    {
        HidePops();
        AnimationsManager.DoFade(backgroundPop,Constans.ZERO,Constans.ZERO);
    }

    private void HidePops()
    {
        foreach (var pop in pops)
        {
            Transform target = pop.transform;
            AnimationsManager.DoScale(target,Vector3.zero,Constans.ZERO);
            AnimationsManager.DoMoveX(target,maxPosPopX,Constans.ZERO);
            AnimationsManager.DoMoveY(target,minPosPopY,Constans.ZERO);
            StatesGameObjects.IsActiveGameObject(pop,false);
        }
    }

    public void ShowPop(GameObject popShow)
    {
        StatesGameObjects.IsActiveGameObject(popShow,true);
        AnimationsManager.DoFade(backgroundPop,Constans.ONE,durationFade);
        popShow.transform.DOMoveY(maxPosPopY, durationMove);
        popShow.transform.DOMoveX(Constans.ZERO, durationMove);
        popShow.transform.DOScale(Vector3.one, durationScale);
    }

    public void DisablePop(GameObject popDisable)
    {
        popActual = popDisable;
        AnimationsManager.DoFade(backgroundPop,Constans.ZERO,durationFade);
        popDisable.transform.DOMoveX(minPosPopX, durationMove);
        popDisable.transform.DOMoveY(minPosPopY, durationMove);
        popDisable.transform.DOScale(Vector3.zero, durationScale).OnComplete(DesactivePop);
    }

    private void DesactivePop()
    {
        Transform target = popActual.transform;
        AnimationsManager.DoMoveX(target,maxPosPopX,durationMove);
        StatesGameObjects.IsActiveGameObject(popActual,false);
        
    }
}
