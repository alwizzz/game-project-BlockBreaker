using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LevelLogic : MonoBehaviour
{
    [SerializeField] private int remainingBlocks;

    private SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    
    // Update is called once per frame
    

    public void DecrementRemainingBlock()
    {
        remainingBlocks--;
        if (remainingBlocks == 0)
        {
            sceneLoader.LoadNextScene();
        }
    }

    public void IncrementRemainingBlock()
    {
        remainingBlocks++;

    }


}
