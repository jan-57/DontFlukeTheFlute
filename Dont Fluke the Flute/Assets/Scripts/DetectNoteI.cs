using UnityEngine;

public class DetectNoteI : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private string hitType; // fast good late miss
    [SerializeField] private int laneID;
    
    private void OnTriggerEnter(Collider other)
    {
        playerInput.NoteUpdate(laneID,hitType,other.gameObject);
        
    }

    

}
