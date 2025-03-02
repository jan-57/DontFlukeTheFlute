using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [SerializeField] private float noteSpeed;
    [SerializeField] private GameObject[] notePrefabs;
    [SerializeField] private Transform[] noteSpawnPoints;
    [SerializeField] private PlayerInputManager playerInput;

    
   
    public void SpawnNote(int noteID)
    {
        if (noteID < 0 || noteID >= notePrefabs.Length || noteID >= noteSpawnPoints.Length)
        {
            Debug.LogError("Ungültige NoteID: " + noteID);
            return;
        }
        GameObject noteObj = Instantiate(notePrefabs[noteID], noteSpawnPoints[noteID].position, notePrefabs[noteID].transform.rotation);
        NoteBehaviour noteBehaviour = noteObj.GetComponent<NoteBehaviour>();
        noteBehaviour.SetSpeed(noteSpeed);
        noteBehaviour.SetLaneNumber(noteID + 1);          
        playerInput.RegisterNote(noteID + 1, noteBehaviour);
    }
}
