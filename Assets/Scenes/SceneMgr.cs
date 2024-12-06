using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMgr : MonoBehaviour
{

    // Start is called before the first frame update
    /*
    public void LoadScene(GamesScenes sceneToLoad, GameMenus menuToOpen)
    {
        StartCoroutine(PerformLoadSequence(sceneToLoad, menuToOpen));
        
    }
    */
    // Update is called once per frame
    /*
    private IEnumerator PerformLoadSequence(GameScenes sceneToLoad, GameMenus menuToOpen) //anything not told to open in the game scene will be deleted from memory
        
    {
        bool waiting = true;
        UIMgr.Instance.CloseAllMenus();
        waiting = false;
        yield return new WaitWhile(() => waiting);
        var asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad.ToString());
        while (asyncOperation is { isDone: false }) yield return null;
        UIMgr.Instance.ShowMenu(menuToOpen);
    }
        */
}
