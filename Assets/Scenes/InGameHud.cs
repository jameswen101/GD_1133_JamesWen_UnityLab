using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameHud : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private Text Timer;

    private bool gamePaused = true;
    private float timer = 0.0f;

    //GM calls this
    public void OnStartGame()
    {
        gamePaused = false;
        healthBar.fillAmount = 1;
    }

    // Start is called before the first frame update
    private void Start()
    {
        Timer.text = "Timer paused";
        Timer.color = Color.yellow;
    }

    public void OnPauseGame() //continue/quit buttons here?
    {
        gamePaused = true;
    }

    // Player or game manager would call this
    public void OnHealthChange(float currentHealth, float maxHealth)
    {
        healthBar.fillAmount = currentHealth / maxHealth; //how can it get the user or enemy's current health?
    }


    // Update is called once per frame
    private void Update()
    {
        if (gamePaused)
        {
            return;
        }
        timer += Time.deltaTime;
        Timer.text = $"{timer,0:0.000}";
    }
}
