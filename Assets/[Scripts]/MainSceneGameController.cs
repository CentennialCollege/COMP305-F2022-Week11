using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneGameController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            GameConfig.Instance().PreviousScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene("Options");
        }
    }
}
