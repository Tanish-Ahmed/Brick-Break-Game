
using UnityEngine;

public class RandomLevelGenerator : MonoBehaviour
{
    public GameObject brickPrefab; // assign the brick in Inspector

    public int rows = 5;//no of rows
    public int columns = 8;//no of columns

    public float brickwidth = 1f;//add brickwidth
    public float brickheight = 0.5f;//add brickheight

    public float spacing = 0.2f; // space between bricks

    public float brickProbability = 0.7f; // probability of a brick appearing (0 to 1)

    public int numberofbricks = 0;

    public Color[] randomBrickColor;//An Array of color to assign an Brick

    void Start()
    {

    }

    public void GenerateRandomLevel()
    {
        float startx = -(columns / 2f) * (brickwidth + spacing) + (brickwidth / 2f);
        float starty = 4f; //start y position bricks

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                //Random Decide Wether to Create a Brick
                if (Random.value <= brickProbability) //gen random no between (0,1)
                {
                    Vector2 position = new Vector2(
                          startx + col * (brickwidth + spacing),
                          starty - row * (brickheight + spacing)
                          );

                    //To Create Bricks using Instantiate Function
                    GameObject _brick = Instantiate(brickPrefab, position, Quaternion.identity, transform);

                    //applying random colors to bricks using SpriteRenderer
                    _brick.GetComponent<SpriteRenderer>().color = randomBrickColor[Random.Range(0, randomBrickColor.Length)];
                    numberofbricks++;//increment the numberofbricks
                }
            }
        }
    } 
}
