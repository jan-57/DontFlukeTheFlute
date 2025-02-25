using UnityEngine;
using UnityEngine.UIElements;

public class NoteBehaviour : MonoBehaviour
{
    private float speed;
    [SerializeField] private int lanePositionIndex;

    private void OnEnable()
    {
        //starts off as missable note before touching triggers
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

    public void SetPositionIndex(int value)
    {
        lanePositionIndex = value;
    }

    public int GetPositionIndex()
    {
        return lanePositionIndex;
    }
}
