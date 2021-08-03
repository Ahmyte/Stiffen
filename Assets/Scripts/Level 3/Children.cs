using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Children : MonoBehaviour
{
    private Transform target;
    public Transform[] spawnPoints;
    public GameObject ChildrenPrefab;
    [SerializeField]
    public static float speed = 1f;
   // [HideInInspector]
    public bool toEgg = true;
    public GameObject Egg;

    void Start()
    {
        toEgg = true;
        Egg = GameObject.FindGameObjectWithTag("Egg");
        target = Egg.transform;
    }

    void Update()   
    {
        if (toEgg)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else if (transform.position.y < 12)
        {
            target = spawnPoints[6].transform;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else if (transform.position.y > 12)
        {
            target = spawnPoints[13].transform;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if (transform.position == target.position && !toEgg)
        {
            Player.score++;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Chicken")
        {
            speed *= 1.05f;
            toEgg = false;
        }

        else if (collision.tag == "Egg")
        {
            GameManager1.EggBroken = true;
            StartCoroutine(RestartLevel());
            Egg.SetActive(false);
        }
    }
    
    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
