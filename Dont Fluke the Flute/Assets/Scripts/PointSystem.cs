using NUnit.Framework;
using TMPro;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class PointSystem : MonoBehaviour
{
    [SerializeField] private TextMeshPro scoreText;
    [SerializeField] private int points;
    [SerializeField] private int maxLifePoints;
    [SerializeField] private int currentLife;
    private int combo;
    [SerializeField] SoundTrackManager soundTrackManager;
    [SerializeField] MenuScript menuScript;

    [SerializeField] private List<GameObject> hearts = new List<GameObject>();
    
    [SerializeField] private Animator playerAnimator; 
    [SerializeField] private Animator snakeAnimator;
    
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
       
        playerAnimator.SetInteger("Health", currentLife);
    }

    public void Reset()
    {
        
        points = 0;
        currentLife = maxLifePoints;
        playerAnimator.SetInteger("Health", maxLifePoints);
        snakeAnimator.SetBool("PlayerDeath", false);
        combo = 1;
        for (int i = 0; i < hearts.Count; i++)
        {
            hearts[i].SetActive(true);
        }

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
        playerAnimator.SetTrigger("Hurt");
        snakeAnimator.SetTrigger("SnakeAttack");
        RemoveHeart();

        if (currentLife < 1)
        {
            snakeAnimator.SetBool("PlayerDeath", true);
            soundTrackManager.StopSoundTracks();
        }

        



    }

    private void RemoveHeart()
    {
        if(currentLife > -1)
        {

            hearts[currentLife].SetActive(false);

        }
       
    }

   
}

