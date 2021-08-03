using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour
{
    [SerializeField] Transform playerTransform;

    [SerializeField] private float verticalInput;

    [SerializeField] private float horizontalInput;

    [SerializeField] private SpriteRenderer playerSprite;
   
    [SerializeField] private float climbSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        
        playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        playerTransform.position += new Vector3(0, verticalInput, 0) * climbSpeed;
        
        horizontalInput = Input.GetAxis("Horizontal");
        playerTransform.position += new Vector3(horizontalInput, 0, 0) * climbSpeed;

        playerSprite.flipX = horizontalInput < 0;

    }
}