using System;
using UnityEngine;
public class EpisodesManager : MonoBehaviour
{
    private float minPosMenu = -5f;
    private int indexMenuEpisodes;
    public event Action OnShowMenuEpisodes;
    public event Action OnHideMenusEpisodes;
    public static EpisodesManager instance;
    public int IndexMenuEpisodes => indexMenuEpisodes;
    public float MinPosMenu => minPosMenu;

    private void Awake()
    {
        if (!instance) instance = this;
    }

    private void Start()
    {
        HideMenus();
    }

    public void HideMenus()
    {
        OnHideMenusEpisodes?.Invoke();
    }

    public void ShowMenu(int keyMenu)
    {
        indexMenuEpisodes = keyMenu;
        OnShowMenuEpisodes?.Invoke();
    }
}
