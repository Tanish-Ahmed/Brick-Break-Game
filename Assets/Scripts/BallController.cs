using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody2D rb; //direct Controll for Ball Physics

    private bool isLaunched = false; //is Ball Launched or not

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isLaunched && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(Random.Range(-1f, 1f), 1).normalized * speed;
            isLaunched = true;
        }
    }


    //Collision Logic

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Brick")
        {
            GameManager.Instance.BrickDestroyed();
            ScoreManager.Instance.AddScore(10);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "GameOverZone")
        {
            GameManager.Instance.GameOver();
            Destroy(gameObject);
        }
    }
}
