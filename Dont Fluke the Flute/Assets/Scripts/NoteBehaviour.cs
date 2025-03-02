using UnityEngine;

public class NoteBehaviour : MonoBehaviour
{
    private float speed;
    
    [SerializeField] private int laneNumber;
    [SerializeField] private PlayerInputManager playerInput;

    private void Start()
    {
        
        gameObject.tag = "bruh";
        
    }

    private void FixedUpdate()
    {
        MoveDown();
    }

    private void MoveDown()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    public void SetSpeed(float value)
    {
        speed = value;
    }

  
    public void SetLaneNumber(int lane)
    {
        laneNumber = lane;
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("fast") || collision.CompareTag("good") || collision.CompareTag("late"))
        {
            gameObject.tag = collision.tag;
            
        }
        else if (collision.CompareTag("miss"))
        {
           
            if (playerInput != null)
            {
                playerInput.NoteMissed(laneNumber, this);
            }
        }
    }
}
