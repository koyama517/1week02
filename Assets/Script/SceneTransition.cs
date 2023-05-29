using System.Collections;
using System.Collections.Generic;
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
        if(Input.GetKeyDown(KeyCode.UpArrow)) {
            SceneManager.LoadScene("Scenes/Title");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SceneManager.LoadScene("Scenes/PlayGame");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SceneManager.LoadScene("Scenes/GameOver");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SceneManager.LoadScene("Scenes/GameClear");
        }
    }
}
