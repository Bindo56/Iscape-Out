using System.Collections;
using TMPro;
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
    [SerializeField] float backToNormal = 0f;

    [SerializeField] TextMeshProUGUI timerUI;
    Enemies enemy;
    float timer;

    public int facingDir { get; private set; } = 1;
    public bool facingRight = false;

    public System.Action OnFlipped;

    // Start is called before the first frame update
    void Start()
    {
        slimeControlMovement.enabled = false;
        timerUI.enabled = false;
        enemy = GetComponent<Enemies>();
        facingRight = false;


    }

    // Update is called once per frame
    void Update()
    {
        BackToNormal();

        if (backToNormal > 0)
        {
            backToNormal -= Time.deltaTime;
            DisplayTimer(backToNormal);
        }
    }

    void DisplayTimer(float _timer)
    {
        if (_timer > 0)
        {
            _timer = 0;
        }

        float min = Mathf.FloorToInt(backToNormal / 60);
        float sec = Mathf.FloorToInt(backToNormal % 60);

        timerUI.text = string.Format("{0:00} : {1:00}", min, sec);

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

            facingRight = true;
           // transform.Rotate(0, 0, 0);

            timerUI.enabled = true;
            backToNormal = 10f;
            //  timer -= Time.deltaTime;
            Debug.Log("Switch");
            playerScript.enabled = false;
            slimeControlMovement.enabled = true;
            electrodScript.enabled = false;

            sr.color = Color.green;
            //  cc.enabled = false;
            //  Attack.enabled = false;
            playerSpriteShapeRenderer.enabled = false;

            for (int i = 0; i < playerSr.Length; i++)
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
            timerUI.enabled = false;

            playerSpriteShapeRenderer.enabled = true;
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
        timerUI.enabled = false;


        playerSpriteShapeRenderer.enabled = true;
        player.transform.position = electrod.transform.position;
        for (int i = 0; i < playerSr.Length; i++)
        {

            playerSr[i].color = Color.white;

        }



        Destroy(electrod, 1F);
    }

    IEnumerator switchback()
    {
        yield return new WaitForSeconds(10);
        switchbackNor();

    }
    public virtual void flip()
    {
        Debug.Log("flip");
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);


        if (OnFlipped != null)
            OnFlipped();
    }

    public virtual void flipController(float _x)
    {
        if (_x > 0 && !facingRight)
            flip();

        else if (_x < 0 && facingRight)
            flip();

    }

}
