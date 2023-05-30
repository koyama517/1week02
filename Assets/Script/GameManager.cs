using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject playerPrefab;

    private GameObject player;

    public GameObject playerModelPrefab;

    private GameObject playerModel;

    private shake cameraShake;
    // Start is called before the first frame update
    void Start()
    {
        cameraShake = Camera.main.GetComponent<shake>();
        player = Instantiate(playerPrefab);
        playerModel = Instantiate(playerModelPrefab);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cameraShake.Shake(0.05f, 0.3f);//
        }
    }
}
