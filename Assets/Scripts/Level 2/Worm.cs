using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class Worm : MonoBehaviour
{
    public Camera mainCamera;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }

    private void Update()
    {
        mainCamera.transform.position =new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,-10);
    }
}