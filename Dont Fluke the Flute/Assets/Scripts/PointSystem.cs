using UnityEngine;

public class PointSystem : MonoBehaviour
{
    [SerializeField] private int points;
    [SerializeField] private int maxLifePoints;
    [SerializeField] private int currentLife;
    private int combo;

    private void OnEnable()
    {
        Reset();
    }

    public void Reset()
    {
        points = 0;
        currentLife = maxLifePoints;
        combo = 1;
        Debug.Log("PointSystem reset: Punkte, Leben und Combo zurückgesetzt.");
    }

    // Verarbeitet einen Treffer basierend auf dem Noten-Zustand.
    // "fast", "good" und "late" erhöhen die Combo und geben Punkte.
    // "bruh" und "miss" setzen die Combo zurück und kosten ein Leben.
    public bool HandlePress(string accuracy)
    {
        Debug.Log($"HandlePress: Verarbeite Zustand '{accuracy}'.");
        switch (accuracy)
        {
            case "fast":
                points += 5 * combo;
                combo++;
                return true;
            case "good":
                points += 15 * combo;
                combo++;
                return true;
            case "late":
                points += 5 * combo;
                combo++;
                return true;
            case "bruh":
            case "miss":
                combo = 1;
                TakeDamage();
                return false;
            default:
                Debug.LogWarning("Unbekannter Noten-Zustand: " + accuracy);
                return false;
        }
    }

    private bool TakeDamage()
    {
        currentLife--;
        Debug.Log($"TakeDamage: Leben verringert. Aktuelles Leben: {currentLife}");
        return currentLife > 0;
    }
}

