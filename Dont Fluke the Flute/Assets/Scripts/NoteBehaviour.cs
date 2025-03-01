using UnityEngine;

public class NoteBehaviour : MonoBehaviour
{
    private float speed;
    // Die Lane, in der diese Note ist (1 bis 4); wird beim Spawnen gesetzt.
    [SerializeField] private int laneNumber;
    [SerializeField] private PlayerInput playerInput;

    private void Start()
    {
        // Start-Zustand auf "bruh"
        gameObject.tag = "bruh";
        Debug.Log($"Note '{gameObject.name}' gestartet in Lane {laneNumber} mit Zustand 'bruh'.");
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

    // Setzt die Lane-Nummer (1 bis 4)
    public void SetLaneNumber(int lane)
    {
        laneNumber = lane;
    }

    // Wird aufgerufen, wenn die Note in einen Trigger-Bereich kommt.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Note '{gameObject.name}' kollidiert mit '{collision.tag}'.");
        if (collision.CompareTag("fast") || collision.CompareTag("good") || collision.CompareTag("late"))
        {
            gameObject.tag = collision.tag;
            Debug.Log($"Note '{gameObject.name}' Zustand aktualisiert zu '{collision.tag}'.");
        }
        else if (collision.CompareTag("miss"))
        {
            Debug.Log($"Note '{gameObject.name}' hat den Miss-Collider erreicht.");
            if (playerInput != null)
            {
                playerInput.NoteMissed(laneNumber, this);
            }
        }
    }
}
