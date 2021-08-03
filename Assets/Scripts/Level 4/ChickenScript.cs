using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChickenScript : MonoBehaviour
{
    public GameObject ChickenPuffEffect;
    public static float speed = 10f;
    private bool position;

    void Start()
    {
        if (transform.position.x < 0)
            position = false;

        else if (transform.position.x > 0)
            position = true;
    }

    void Update()
    {
        if (position)
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        else
            transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (Mathf.Abs(transform.position.x) > 10)
        {
            Destroy(gameObject);
            GameManager.RemainingLife -= 1;
            if (GameManager.RemainingLife == 0)
                GameManager.FindObjectOfType<GameManager>().EndGame();
        }
    }
    private void OnMouseDown()
    {
        GameManager.Score++;
        GameObject puff = Instantiate(ChickenPuffEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        StartCoroutine(wait());
        Destroy(puff);
    }
    
     IEnumerator wait()
    {
        yield return  new WaitForSeconds(2f);
    }

     void NextLevel()
     {
         if (GameManager.Score == 10)
         {
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
         }
     }
}
