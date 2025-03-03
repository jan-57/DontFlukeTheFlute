using NUnit.Framework;
using TMPro;
using UnityEngine;
using System.Collections.Generic;



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

    [SerializeField] private GameObject gameplayScreen;
    [SerializeField] private int counter;
    [SerializeField] private bool isBlinking;
    [SerializeField] private int blinkdelay;
    private void OnEnable()
    {
        Reset();
        counter = 0;
    }

    private void FixedUpdate()
    {
        if (menuScript.GetGaming() && scoreText != null)
        {
            scoreText.text = points.ToString();
        }
       
        playerAnimator.SetInteger("Health", currentLife);

        if (isBlinking && gameplayScreen.activeInHierarchy)
        {
            
            
                if (counter > blinkdelay)
                {
                    if (scoreText.gameObject.activeInHierarchy)
                    {
                        scoreText.gameObject.SetActive(false);
                    }
                    else
                    {
                        scoreText.gameObject.SetActive(true);
                    }
                    counter = 0;
                }
                counter++;
         
        }
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
            BlinkScoreSwitch(true);
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

    public void BlinkScoreSwitch(bool value)
    {

        isBlinking = value;

    }

   
}

