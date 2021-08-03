using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppleRoller : MonoBehaviour
{   
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float liftingForce;
    [SerializeField] private AudioSource bop;
    private Rigidbody2D appleRb;
    private float timeCount;
    private bool isLeftPressed;
    private bool isRightPressed;
    private bool isLeftTriggered;
    private bool isRightTriggered;
    private bool willGameBeOver;
    

    private void Start()
    {
        appleRb = GetComponent<Rigidbody2D>(); 
    }

    private void Update()
    {
        HandleInput(); //Handles input.
        IsGameOver();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void HandleInput()
    {   /**Horizontal inputa çevirilecek**/
        if (Input.GetKey(KeyCode.A))    isLeftPressed = true;

        if (Input.GetKey(KeyCode.D))    isRightPressed = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("LeftTr"))             isLeftTriggered = true;
        if(collision.CompareTag("RightTr"))            isRightTriggered = true;

        if(collision.CompareTag("Dirt"))
        {
            willGameBeOver = true;
            timeCount = Time.time;
        }

        if(collision.CompareTag("Bop"))
        {
            bop.Play();
        }

        if(collision.CompareTag("Respawn"))             StartCoroutine(RestartLevel());

        if(collision.CompareTag("Worm"))                NextLevel();
        

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Tree") && isLeftTriggered && isRightTriggered)        
                collision.collider.isTrigger = true;
        
        if (collision.collider.CompareTag("Water"))
        {
            appleRb.AddForce(Vector2.up * liftingForce * Time.deltaTime, ForceMode2D.Impulse);
            willGameBeOver = false;
        }
    }
    private void Movement()
    {
        if (isLeftPressed)
        {
            appleRb.AddForce(Vector2.left * speed * Time.deltaTime, ForceMode2D.Impulse);
            isLeftPressed = false;
            CheckSpeed();
        }

        if (isRightPressed)
        {
            appleRb.AddForce(Vector2.right * speed * Time.deltaTime, ForceMode2D.Impulse);
            isRightPressed = false;
            CheckSpeed();
        }
    }

    private void CheckSpeed() //Doesn't let the velocity of the object be above max.
    {
        if (appleRb.velocity.magnitude > maxSpeed)
            appleRb.velocity = appleRb.velocity.normalized * maxSpeed;       
    }
    private void IsGameOver()
    {
        if (Time.time - timeCount > 3 && willGameBeOver)
            StartCoroutine(RestartLevel());
    }

    void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
