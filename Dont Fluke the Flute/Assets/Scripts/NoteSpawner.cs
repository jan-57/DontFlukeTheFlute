using UnityEngine;
using UnityEngine.Rendering.Universal;

public class NoteSpawner : MonoBehaviour
{
    [SerializeField] private float noteSpeed;
    [SerializeField] private GameObject[] notePrefabs;
    [SerializeField] private GameObject[] noteSpawnPoints;
    [SerializeField] private PlayerInput playerInput;
    private GameObject temp;

    //noteID is just the indexNumber for the note in the noteprefabs array
    // I could add pooling here, but this game is gonna be very small, so no.
    public void SpawnNote(int noteID)
    {
        temp = Instantiate(notePrefabs[noteID], noteSpawnPoints[noteID].transform.position, notePrefabs[noteID].transform.rotation);
        temp.GetComponent<NoteBehaviour>().SetSpeed(noteSpeed);

        playerInput.NoteUpdate(noteID + 1,"bruh",temp);
    }

}
