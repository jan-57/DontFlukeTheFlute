using UnityEngine;

public class leftover : MonoBehaviour
{
    
    private void OnEnable()
    {
        Invoke("SelfDestruct", 1f);
    }

    private void SelfDestruct()
    {
        Destroy(this.gameObject);
    }

}
