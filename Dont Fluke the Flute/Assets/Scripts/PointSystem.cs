using UnityEngine;
using UnityEngine.Rendering;

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
    }



    public bool TakeDamage()
    {
        currentLife--;
        return currentLife > 0;
    }

    public bool HandlePress(string accuracy)
    {
        switch (accuracy)
        {
            case "bruh":

                combo = 1;
                TakeDamage();
                return false;
               

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
               

            case "miss":

                combo = 1;
                TakeDamage();
                return false;

            default: return false;
        }
    }

}
