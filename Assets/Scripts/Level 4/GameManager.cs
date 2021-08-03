using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] Lives;
    public Text ScoreText;
    public static int Score;
    public static int RemainingLife = 3;
    private float slowness = 0.4f;

    void Start()
    {
        Score = 0;
        ScoreText.text = "Score : " + Score;
        RemainingLife = 3;
        for (int i = 0; i < 3; i++)
        {
            Lives[i].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
           // Lives[2].GetComponent<Transform>().transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }

    private void Update()
    {
        ScoreText.text = "Score : " + Score;
        if (RemainingLife == 2)
        {
            Lives[2].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 60);
            Lives[2].GetComponent<Transform>().transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }
        else if (RemainingLife == 1)
        {
            Lives[1].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 60);
            Lives[1].GetComponent<Transform>().transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }
        else if (RemainingLife == 0)
        {
            Lives[0].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 60);
            Lives[0].GetComponent<Transform>().transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }

        NextLevel();
    }


    public void EndGame()
    {
        StartCoroutine(Restart());
    }

    public IEnumerator Restart()
    {
        Time.timeScale = 1f / slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;
        yield return new WaitForSeconds(3f / slowness);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    
    void NextLevel()
    {
        if (Score == 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}
