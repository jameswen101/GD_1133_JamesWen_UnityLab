using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMgr : MonoBehaviour
{
    [SerializeField] private GameObject[] Layouts;
    [SerializeField] private InGameHud GameHud;

    private InGameHud inGameHudInstance;

    private static MenuLayouts currentLayout = MenuLayouts.Main;

    private enum MenuLayouts
    {
        Main = 0,
        InGame = 1,
        Pause = 2,
    }
    // Start is called before the first frame update
    private void Start()
    {
        
        SetLayout(currentLayout);
        if (currentLayout == MenuLayouts.Main)
        {
            GameHud.OnStartGame();
        }
    }
    private void SetLayout(MenuLayouts Layout)
    {
        currentLayout = Layout;
        for (int i = 0; i < Layouts.Length; i++)
        {
            Layouts[i].SetActive((int)Layout == i);
        }
    }
    public void OpenMainMenu()
    {
        SetLayout(MenuLayouts.Main);
    }
    public void ActivateInGameHud()
    {
        SetLayout(MenuLayouts.InGame);
    }
    public void ShowPausegameMenu()
    {
        SetLayout(MenuLayouts.Pause);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
