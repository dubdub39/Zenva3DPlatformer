using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int score;

    //instance
    public static GameManager instance;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
       
    }

    public void AddScore(int scoreToGive)
    {
        score += scoreToGive;
    }

    public void LevelEnd()
    {
        // is this the last level?
        //sceneCountInBuildSettings will give the actual number of scenes that you've added to your build index.
        //if you have 3 scenes, the sceneCount will be 3.  However, the build index for the scenes starts with 0.  
        //so if there are 3 scenes, the first scene will be zero in the build index, the second scene will be '1',
        //and so on.  this is why we've added a '+1' to the build index to compare if it's the last scene in our game

        if (SceneManager.sceneCountInBuildSettings == SceneManager.GetActiveScene().buildIndex + 1)
        {
            WinGame();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void WinGame()
    {

    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
