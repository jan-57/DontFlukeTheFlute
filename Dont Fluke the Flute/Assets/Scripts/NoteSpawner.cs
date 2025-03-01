using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [SerializeField] private float noteSpeed;
    [SerializeField] private GameObject[] notePrefabs;
    [SerializeField] private Transform[] noteSpawnPoints;
    [SerializeField] private PlayerInput playerInput;

    
    // noteID entspricht gleichzeitig der Lane (0 = Lane1, 1 = Lane2, usw.)
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
        noteBehaviour.SetLaneNumber(noteID + 1); // Lanes sind 1-basiert
        Debug.Log($"Spawned note '{noteObj.name}' in Lane {noteID + 1}.");
        // Registriere die Note in der entsprechenden Lane
        playerInput.RegisterNote(noteID + 1, noteBehaviour);
    }
}
