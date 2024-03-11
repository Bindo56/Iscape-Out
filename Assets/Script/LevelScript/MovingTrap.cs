using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTrap : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform[] movePoint;

    private int i;



    protected  void Start()
    {
       // base.Start();
        transform.position = movePoint[0].position;
    }




    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint[i].position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movePoint[i].position) < .25f) //if position of movepoin is less then .25f
        {
            i++;

            if (i >= movePoint.Length)
                i = 0;
        }

        if (transform.position.x > movePoint[i].position.x)
            transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));

        else
            transform.Rotate(new Vector3(0, 0, -rotationSpeed * Time.deltaTime)); //for left rotation
    }



    protected  void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<Player>() != null) if (collision.GetComponent<Player>() != null)
                collision.gameObject.SetActive(false);
               // collision.GetComponent<Player>().Damage();
    }
}
