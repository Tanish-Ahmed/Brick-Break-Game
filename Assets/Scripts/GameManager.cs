using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //static Instance of Game Manager Class

    public GameObject ballPrefab; //To Assign ballprefab in Inspector

    public Transform paddle; //ensure the ball spawn above the paddle

    public RandomLevelGenerator levelGenerator; //reference To the LevelGenerator Script

    private int remainingBricks; //To track RemainingBricks

    public GameObject gameOverUI; //To Display Game Over Panel

    private void Awake()
    {
        Instance = this; // Globally Accessible During GamePlay
    }

    //When Scene Loads
    void Start()
    {
        ResetBall();//First its call the ResetBall Above Paddle
        levelGenerator.GenerateRandomLevel();//To Generate random Level
        CountBricks();//count the bricks
    }

    void ResetBall()
    {
        Instantiate(ballPrefab, paddle.position + new Vector3(0, 0.5f, 0), Quaternion.identity);//Calls the ball at Calculated Position
    }

    void CountBricks()
    {   //Count the Number of Bricks
        remainingBricks = levelGenerator.numberofbricks;
    }

    public void BrickDestroyed()
    {
        remainingBricks--;

        if (remainingBricks <= 0)
        {
            LevelFinished();
        }
    }

    void LevelFinished()
    {
        Debug.Log("Level Finished");
        //Example: regenerate a new random Level
        levelGenerator.GenerateRandomLevel();

        //Reset the brick count
        CountBricks();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Reload Current Scene
    }

    public void GameOver()
    {
        Debug.Log("Game Over");

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true); //Show The Game Over UI
        }
    }
}
