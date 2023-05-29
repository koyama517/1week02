using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject playerPrefab;

    private GameObject player;

    public GameObject playerModelPrefab;

    private GameObject playerModel;


    // Start is called before the first frame update
    void Start()
    {
        
        player = Instantiate(playerPrefab);
        playerModel = Instantiate(playerModelPrefab);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
