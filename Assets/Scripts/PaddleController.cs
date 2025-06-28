using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        float input = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(input, 0, 0) * speed * Time.deltaTime;
        transform.Translate(movement); //To Apply Movement

        //Clamp The Paddle Within Screen Bounds
        Vector3 clampedPosition = transform.position; //storing the current position in ClampedPosition
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -7.5f, 7.5f);//Using Clamp Function to Restrict the paddle
        transform.position = clampedPosition;//assigning the clamp position to the final Transform.position      
    }
}
