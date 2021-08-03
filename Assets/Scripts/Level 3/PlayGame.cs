using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayGame : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform != null)
            {
                if (hit.collider.CompareTag("Play"))
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

                else if (hit.collider.CompareTag("Exit"))
                { 
                    Application.Quit();
                }

                else if (hit.collider.CompareTag("Credits"))
                {

                }
            }
        }
    }
}
