using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelRestart : MonoBehaviour
{
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
                Debug.Log("Change");

                RestartGame();

            }
        }
    }

    public void RestartGame()
    {
        LevelManager.Instance.LoadScene("Level1", "CrossFade");
    }

    public void CloseApp()
    {
        Application.Quit();
    }
}
