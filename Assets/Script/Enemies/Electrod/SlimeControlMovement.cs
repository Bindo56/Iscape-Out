using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeControlMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    float inputX;
   
    [SerializeField] float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveSpeed * inputX, rb.velocity.y);
    }
}
