using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    
      public GameObject linePrefab;

    private GameObject lineX;
    private GameObject lineY;

    // Start is called before the first frame update
    void Start()
    {
        lineX = Instantiate(linePrefab, new Vector3(transform.position.x,
            transform.position.y, -2),
            Quaternion.identity);

        lineY = Instantiate(linePrefab, new Vector3(transform.position.x,
            transform.position.y, -2),
            Quaternion.Euler(0, 0, 90));
    }

    // Update is called once per frame
    void Update()
    {
        Player playerScript;
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerScript = player.GetComponent<Player>();
            transform.position = new Vector3(player.transform.position.x,
                player.transform.position.y,
                -3);
            lineX.transform.position = transform.position;
            lineY.transform.position = transform.position;
            if (playerScript != null)
            {
                if (playerScript.isDiagonal)
                {

                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    lineX.transform.rotation = Quaternion.Euler(0, 0, -45);
                    lineY.transform.rotation = Quaternion.Euler(0, 0, 45);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 0, 45);

                    lineX.transform.rotation = Quaternion.Euler(0, 0, 0);
                    lineY.transform.rotation = Quaternion.Euler(0, 0, 90);
                }
            }

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
