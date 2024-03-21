using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeverL2 : MonoBehaviour , IPointerEnterHandler
{
   // public GrapplingRope grapplingRope;
    public Rigidbody2D rb;
   // [SerializeField] Animator anim;

    private void Start()
    {
       // anim.SetBool("Lever", false);
        
    }
    private void Update()
    {
       
    }

    public void Attak()
    {
       transform.Rotate(180,0,0);
        Debug.Log("GOT0");
        rb.gravityScale = 5f;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("GOT121");
       
    }
}
