using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject playerPrefab;

    private GameObject player;

    public GameObject playerModelPrefab;

    private GameObject playerModel;

    public GameObject enemyPrefab;

    private GameObject enemy;

    public bool isClear;
    public bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        
        player = Instantiate(playerPrefab);
        playerModel = Instantiate(playerModelPrefab);
        enemy = Instantiate(
            enemyPrefab,
            new Vector3(transform.position.x,
            3, -3),
            Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            isGameOver = true;
        }

        if (enemy == null) 
        { 
            isClear = true;
        }

    }
}
