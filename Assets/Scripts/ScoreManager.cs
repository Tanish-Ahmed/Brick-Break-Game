using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public TextMeshProUGUI scoreText; //ref to TMP
    private int score = 0;

    void Awake()
    {
        Instance = this;
    }

    public void AddScore(int points)
    {
        Debug.Log("Add Score:");
        score += points; // increase Score
        scoreText.text = "Score:" + score; //Current Score when brick Destroy
    }


}
