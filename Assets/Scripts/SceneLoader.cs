using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if( currentSceneIndex == SceneManager.sceneCountInBuildSettings - 1) {
            LoadStartScene();
        }
        else {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }

    private void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        var status = FindObjectOfType<GameStatus>();
        if (status != null)
        {
            status.ResetGame();
        }
    }
}
