using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private UIMgr UiSystem;
    [SerializeField] private InGameHud GameHud;
    // Start is called before the first frame update

    public const string GameSceneName = "GameScene";

    public void ButtonStartGame()
    {
        SceneManager.LoadScene("SampleScene");
        UiSystem.ActivateInGameHud();
        GameHud.OnStartGame();
    }


  
}
