using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public Spawner spawner;
    public Player player;
    public static bool EggBroken;


    private void Start()
    {
        EggBroken = false;
        Children.speed = 1f;
        Player.score = 0;

    }
    private void Update()
    {
        WinLevel();
    }

    public void EndGame()
    {

        player.enabled = false;
        spawner.enabled = false;

    }

    public void WinLevel()
    {
        if (Player.score == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


}
