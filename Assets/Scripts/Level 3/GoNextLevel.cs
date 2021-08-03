using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoNextLevel : MonoBehaviour
{
   IEnumerator nextLevel()
   {
      yield return new WaitForSeconds(2f);
      
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
   }

   private void Start()
   {
      StartCoroutine(nextLevel());
   }
}
