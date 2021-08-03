using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [HideInInspector] public static int score = 0;
    [HideInInspector] public static float speed = 5f;
    public Rigidbody2D rb;
    public Text scoreText;
    public SpriteRenderer chickenSprite;
    private float moveHorizontal;
    private float moveVertical;

    private void Start()
    {
        chickenSprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
         moveHorizontal = Input.GetAxis("Horizontal");
         moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);
    }

    void Update()
    {
        scoreText.text = "Score : " + Player.score;

        chickenSprite.flipX = moveHorizontal < 0;
    }
    
}