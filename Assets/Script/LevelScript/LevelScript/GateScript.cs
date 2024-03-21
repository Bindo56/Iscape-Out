using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    public Transform gateTransform;
    public Rigidbody2D rb;
    public float openHeight = 5f; 
    public float animationDuration = 1f;
    public BoxCollider2D cd;

    private bool isOpening = false;

    private void Start()
    {
        rb.gravityScale = 0f;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !isOpening)
        {
            Debug.LogWarning("open");
            isOpening = true;
            OpenGate();
        }
    }
   


    private void OpenGate()
    {

        gateTransform.DOMoveY(gateTransform.position.y + openHeight, animationDuration)
                    .SetEase(Ease.OutQuad)
                    .OnComplete(() => isOpening = false);
        return;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            rb.gravityScale = 5f;
            Debug.Log("close");
            //cd.isTrigger = false;
            
        }
    }
   
}
