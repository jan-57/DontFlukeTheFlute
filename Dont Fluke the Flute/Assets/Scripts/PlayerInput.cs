using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private InputActionReference hit; // Für eventuelle globale Logik
    [SerializeField] private InputActionReference left;
    [SerializeField] private InputActionReference up;
    [SerializeField] private InputActionReference down;
    [SerializeField] private InputActionReference right;

    [SerializeField] private PointSystem pointSystem;

    // 4 Lanes, jeweils als Liste der aktiven Noten (NoteBehaviour)
    private List<NoteBehaviour>[] lanes = new List<NoteBehaviour>[4];

    private void Awake()
    {
        for (int i = 0; i < 4; i++)
        {
            lanes[i] = new List<NoteBehaviour>();
        }
    }

    private void OnEnable()
    {
        hit.action.performed += OnHit;
        left.action.performed += OnLeft;
        up.action.performed += OnUp;
        down.action.performed += OnDown;
        right.action.performed += OnRight;
    }

    private void OnDisable()
    {
        hit.action.performed -= OnHit;
        left.action.performed -= OnLeft;
        up.action.performed -= OnUp;
        down.action.performed -= OnDown;
        right.action.performed -= OnRight;
    }

    // Registriert eine neu gespawnte Note in der entsprechenden Lane (lane: 1 bis 4)
    public void RegisterNote(int lane, NoteBehaviour note)
    {
        int index = lane - 1;
        if (index >= 0 && index < lanes.Length)
        {
            lanes[index].Add(note);
            Debug.Log($"Note '{note.gameObject.name}' registriert in Lane {lane}. Gesamtanzahl: {lanes[index].Count}");
        }
        else
        {
            Debug.LogError("Ungültige Lane in RegisterNote: " + lane);
        }
    }

    // Wird von einer Note aufgerufen, wenn sie den Miss-Collider berührt.
    public void NoteMissed(int lane, NoteBehaviour note)
    {
        int index = lane - 1;
        Debug.Log($"NoteMissed: Note '{note.gameObject.name}' in Lane {lane} hat den Miss-Collider erreicht. (Berechneter Index: {index})");

        // Falls der berechnete Index ungültig ist, loggen wir einen Fehler
        if (!(index >= 0 && index < lanes.Length))
        {
            Debug.LogError($"Ungültiger Lane-Index: {index}. Möglicherweise wurde die Lane-Nummer der Note nicht korrekt gesetzt (Lane: {lane}).");
            return;
        }

        if (lanes[index].Contains(note))
        {
            lanes[index].Remove(note);
            Debug.Log($"Note '{note.gameObject.name}' aus Lane {lane} entfernt (Miss).");
            pointSystem.HandlePress("miss");
            Destroy(note.gameObject);
            Debug.Log($"Note '{note.gameObject.name}' zerstört (Miss).");
        }
        else
        {
            Debug.LogWarning($"Note '{note.gameObject.name}' nicht in Lane {lane} gefunden bei NoteMissed.");
        }
    }


    // Wird beim Tastendruck in einer Lane aufgerufen.
    // Verarbeitet den untersten (ältesten) Noteneintrag in der jeweiligen Lane.
    private void HandleLaneHit(int lane)
    {
        int index = lane - 1;
        Debug.Log($"HandleLaneHit: Taste für Lane {lane} gedrückt.");
        if (index < 0 || index >= lanes.Length)
        {
            Debug.LogError("Ungültige Lane in HandleLaneHit: " + lane);
            return;
        }
        if (lanes[index].Count > 0)
        {
            NoteBehaviour note = lanes[index][0];
            string hitState = note.gameObject.tag;
            Debug.Log($"Verarbeite Treffer in Lane {lane} für Note '{note.gameObject.name}' mit Zustand '{hitState}'.");
            pointSystem.HandlePress(hitState);
            lanes[index].RemoveAt(0);
            Destroy(note.gameObject);
            Debug.Log($"Note '{note.gameObject.name}' zerstört nach Treffer in Lane {lane}.");
        }
        else
        {
            Debug.Log($"Keine Note in Lane {lane} zum Treffen gefunden. Registriere Miss.");
            pointSystem.HandlePress("miss");
        }
    }

    // Input-Callbacks – hier wird die jeweilige Lane abgearbeitet.
    private void OnLeft(InputAction.CallbackContext context)
    {
        HandleLaneHit(1);
    }

    private void OnUp(InputAction.CallbackContext context)
    {
        HandleLaneHit(2);
    }

    private void OnDown(InputAction.CallbackContext context)
    {
        HandleLaneHit(3);
    }

    private void OnRight(InputAction.CallbackContext context)
    {
        HandleLaneHit(4);
    }

    // Diese Methode bleibt aktuell ungenutzt – kann aber für globale Hit-Logik dienen.
    private void OnHit(InputAction.CallbackContext context)
    {
    }
}

