using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Player playerScript;
        GameObject player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<Player>();
        transform.position = new Vector3(player.transform.position.x,
            player.transform.position.y,
            -3);

        Debug.Log(player.transform.position);
    }
}
