using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private float timer = 300;
    private int visualTimer;

    [SerializeField] TextMeshProUGUI timerVisual;
    [SerializeField] Shop player1;
    [SerializeField] Shop player2;

    private void Update()
    {
        GameTimer();

        visualTimer = Mathf.RoundToInt(timer);

        timerVisual.text = visualTimer.ToString();
    }

    private void GameTimer()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Winner();
        }
    }

    private void Winner()
    {
        if (player1.money > player2.money)
        {
            SceneManager.LoadScene(1);
        }
        else if (player1.money < player2.money)
        {
            SceneManager.LoadScene(2);
        }
        else SceneManager.LoadScene(3);
    }
}
