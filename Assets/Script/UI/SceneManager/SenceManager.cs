using UnityEngine;

public class SenceManager : MonoBehaviour
{
    [SerializeField] int sceneNO;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<Player>() != null)
            {
                LevelManager.Instance.LoadScene("Level2", "CrossFade");


            }
        }
    }


}
