using UnityEngine;
using UnityEngine.UIElements;

public class NoteBehaviour : MonoBehaviour
{
    private float speed;
    private void MoveDown()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        MoveDown();
    }

    public void SetSpeed(float value)
    {
        speed = value;
    }
}
