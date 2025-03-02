using TMPro;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    [SerializeField] private TextMeshPro scoreText;
    [SerializeField] private int points;
    [SerializeField] private int maxLifePoints;
    [SerializeField] private int currentLife;
    private int combo;
    [SerializeField] SoundTrackManager soundTrackManager;
    [SerializeField] MenuScript menuScript;

    private void OnEnable()
    {
        Reset();
    }

    private void FixedUpdate()
    {
        if (menuScript.GetGaming())
        {
            scoreText.text = points.ToString();
        }
       
        
    }

    public void Reset()
    {
        
        points = 0;
        currentLife = maxLifePoints;
        combo = 1;
        
    }

    
    public bool HandlePress(string accuracy)
    {
        
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
                
                return false;
        }
    }

    private void TakeDamage() // janek, you can call the animation for taking damage here! and the hearts and stuff
    {                           // dont forget that you can chnage the max health amount in the unity inspector under the object NoteDetection

        currentLife--;
       
        if(currentLife < 1)
        {

            soundTrackManager.StopSoundTracks();
            
        }
        
    }
}

