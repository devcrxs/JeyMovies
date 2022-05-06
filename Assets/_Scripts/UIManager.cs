using UnityEngine;
public class UIManager : MonoBehaviour
{
    private float durationScale = 0.3f;
    private float durationMove = 0.5f;
    private float durationFade = 0.2f;
    private float positionSocialMenu = 4f;
    private float solidFade = 1;
    [SerializeField] private GameObject[] menusEpisodes;
    [SerializeField] private Transform scroll;
    private void Start()
    {
        EpisodesManager.instance.OnShowMenuEpisodes += ShowMenuEpisodes;
        EpisodesManager.instance.OnHideMenusEpisodes += HideMenuEpisodes;
    }
    private void ShowMenuEpisodes()
    {
        int actualIndex = EpisodesManager.instance.IndexMenuEpisodes;
        Transform actualMenu = menusEpisodes[actualIndex].transform;
        AnimationsManager.FadeChildrens(menusEpisodes,solidFade,durationFade);
        AnimationsManager.DoScale(actualMenu, Vector3.one,durationScale);
        AnimationsManager.DoMoveY(actualMenu,Constans.ZERO,durationMove);
        StatesGameObjects.IsActiveGameObject(menusEpisodes[actualIndex], true);
    }
    
    private void HideMenuEpisodes()
    {
        foreach (var menu in menusEpisodes)
        {
            Transform actualMenu = menu.transform;
            AnimationsManager.FadeChildrens(menusEpisodes,Constans.ZERO,durationFade);
            AnimationsManager.DoScale(actualMenu,Vector3.zero,durationScale);
            AnimationsManager.DoMoveY(actualMenu,EpisodesManager.instance.MinPosMenu,durationMove);
        }
    }
    
    public void GoNetworksSocial()
    {
        Transform target = scroll.transform;
        AnimationsManager.DoMoveY(target,positionSocialMenu,durationMove);
    }
    
    public void GoToPage(string url)
    {
        Application.OpenURL(url);
    }
}
