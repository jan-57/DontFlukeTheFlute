using UnityEngine;
using UnityEngine.Rendering.Universal;

public class NoteSpawner : MonoBehaviour
{
    [SerializeField] private float noteSpeed;
    [SerializeField] private GameObject[] notePrefabs;
    [SerializeField] private GameObject[] noteSpawnPoints;
    private GameObject temp;

    //noteID is just the indexNumber for the note in the noteprefabs array
    // I could add pooling here, but this game is gonna be very small, so no.
    public void SpawnNote(int noteID)
    {
        Instantiate(notePrefabs[noteID], noteSpawnPoints[noteID].transform.position, notePrefabs[noteID].transform.rotation).GetComponent<NoteBehaviour>().SetSpeed(noteSpeed);  
    }

}
