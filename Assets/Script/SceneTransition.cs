using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (SceneManager.GetActiveScene().name == "Title")
            {
                SceneManager.LoadScene("Scenes/SampleScene");
            }
            else if (SceneManager.GetActiveScene().name == "SampleScene")
            {
                GameManager gameManagerScript;
                GameObject gameManager = GameObject.Find("GameManager");
                if (gameManager != null)
                {
                    gameManagerScript = gameManager.GetComponent<GameManager>();
                    if (gameManagerScript != null)
                    {
                        if (gameManagerScript.isClear)
                        {
                            SceneManager.LoadScene("Scenes/GameClear");
                        }
                        else if (gameManagerScript.isGameOver)
                        {
                            SceneManager.LoadScene("Scenes/GameOver");
                        }
                    }
                }
            }
            else
            {
                SceneManager.LoadScene("Scenes/Title");
            }
        }
    }
}