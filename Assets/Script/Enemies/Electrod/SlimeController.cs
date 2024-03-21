using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SlimeController : MonoBehaviour
{
    [SerializeField] BoxCollider2D bc;
    [SerializeField] GameObject player;
    [SerializeField] GameObject electrod;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Player playerScript;
    [SerializeField] ElectrodEnemy electrodScript;
    [SerializeField] SlimeControlMovement slimeControlMovement;
  //  [SerializeField] CircleCollider2D cc;
    [SerializeField] SpriteShapeRenderer playerSpriteShapeRenderer;
    [SerializeField] SpriteRenderer[] playerSr;
    [SerializeField] float backToNormal = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        slimeControlMovement.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        BackToNormal();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("PlayerDetected");

            playerswitch();


        }
    }

    private void playerswitch() //switcihing the player to enemy
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
          //  timer -= Time.deltaTime;
            Debug.Log("Switch");
            playerScript.enabled = false;
            slimeControlMovement.enabled = true;
            electrodScript.enabled = false;

            sr.color = Color.green;
          //  cc.enabled = false;
          //  Attack.enabled = false;
            playerSpriteShapeRenderer.enabled = false;

            for(int i = 0; i < playerSr.Length; i++)
            {
                playerSr[i].color = Color.clear;

            }


            StartCoroutine(switchback());

        }

    }
    private void BackToNormal()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            playerScript.enabled = true;
            slimeControlMovement.enabled = false;

            playerSpriteShapeRenderer.enabled= true;
            player.transform.position = electrod.transform.position;
            for (int i = 0; i < playerSr.Length; i++)
            {
               
              playerSr[i].color = Color.white;

            }

            Destroy(electrod, 1F);

        }

    }
    private void switchbackNor()
    {
        playerScript.enabled = true;
        slimeControlMovement.enabled = false;

        
            playerSpriteShapeRenderer.enabled= true;
            player.transform.position = electrod.transform.position;
        for (int i = 0; i < playerSr.Length; i++)
        {

            playerSr[i].color = Color.white;

        }



        Destroy(electrod, 1F);
    }

    IEnumerator switchback()
    {
        yield return new WaitForSeconds(backToNormal);
        switchbackNor();

    }

}
