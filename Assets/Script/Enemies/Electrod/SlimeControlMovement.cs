using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeControlMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb1;
    [SerializeField] SlimeController controller;
    float inputX;
   

    [SerializeField] float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb1 = GetComponent<Rigidbody2D>();
       
       controller = GetComponent<SlimeController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        inputX = Input.GetAxisRaw("Horizontal");
        rb1.velocity = new Vector2(moveSpeed * inputX , rb1.velocity.y);

        controller.flipController(inputX);
        
    }

  
}
