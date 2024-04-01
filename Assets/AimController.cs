using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    [SerializeField] private Transform aim;
    [SerializeField] private float aimDistance = 1.5f;
    [SerializeField] Player player;
    [SerializeField] SpriteRenderer aimSprit;





    // Start is called before the first frame update
    void Start()
    {
        aimSprit.enabled = false;
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            aimSprit.enabled = true;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            aimSprit.enabled = false;

        }

        if(aimSprit.enabled == false)
        {
            return;
           

          
        }
        else
        {
            Vector3 mousePos = Camera.main.WorldToScreenPoint(Input.mousePosition);
            Vector3 dir = mousePos - transform.position;

            aim.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg));


            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            aim.position = transform.position + Quaternion.Euler(0, 0, angle) * new Vector3(aimDistance, 0, 0);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                player.FireJelly();
            }
        }




    }
}
