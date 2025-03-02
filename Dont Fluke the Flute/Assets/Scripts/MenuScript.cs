using UnityEngine;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject level1Canvas;
    [SerializeField] private GameObject level2Canvas;
    [SerializeField] private GameObject gameCanvas;
    [SerializeField] private GameObject level3Canvas;
    [SerializeField] private bool isGaming;
    [SerializeField] private SoundTrackManager soundTrackManager;
    


    [SerializeField] private int currentScreen = 0;

    void Start()
    {
        mainMenuCanvas.SetActive(true);
        level1Canvas.SetActive(false);
        level2Canvas.SetActive(false);
        gameCanvas.SetActive(false);
        level3Canvas.SetActive(false);
        isGaming = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGaming)
        {

        
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (currentScreen == 0)
                {
                    level1Canvas.SetActive(true);
                    SwitchScreen(1);
                    mainMenuCanvas.SetActive(false);

                    Debug.Log("Screen 0, Enter Pressed");
                }
                else if (currentScreen == 1)
                {
                    SetGaming(true);
                    gameCanvas.SetActive(true);
                    SwitchScreen(3);
                    level1Canvas.SetActive(false);

                    soundTrackManager.StartSoundTrack1();

                    Debug.Log("Screen 1, Enter Pressed");
                }
                else if (currentScreen == 2)
                {
                    SetGaming(true);
                    level2Canvas.SetActive(false);
                    gameCanvas.SetActive(true);
                    SwitchScreen(3);

                    soundTrackManager.StartSoundTrack2();

                    Debug.Log("Screen 2, Enter Pressed");
                }
                
                else if (currentScreen == 4)
                {
                    SetGaming(true);
                    level3Canvas.SetActive(false);
                    gameCanvas.SetActive(true);
                    SwitchScreen(3);

                   // soundTrackManager.StartSoundTrack3();

                    Debug.Log("Screen 4, Enter Pressed");
                }
                
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Keypad2))
            {
                if (currentScreen == 1)
                {
                    level2Canvas.SetActive(true);
                    level1Canvas.SetActive(false);
                    SwitchScreen(2);
                    Debug.Log("Screen 1, Down, S, or Numpad 2 Pressed");
                }
                
                if (currentScreen == 2)
                {
                    level2Canvas.SetActive(false);
                    level3Canvas.SetActive(true);
                    SwitchScreen(3);
                    Debug.Log("Screen 2, Down, S, or Numpad 2 Pressed");
                }
                
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Keypad8))
            {
                if (currentScreen == 2)
                {
                    level1Canvas.SetActive(true);
                    level2Canvas.SetActive(false);
                    SwitchScreen(1);
                    Debug.Log("Screen 2, Up Pressed");
                }
                
                if (currentScreen == 4)
                {
                    level2Canvas.SetActive(true);
                    level3Canvas.SetActive(false);
                    SwitchScreen(3);
                    Debug.Log("Screen 4, Down, S, or Numpad 2 Pressed");
                }
            }
            
        }
        
    }

    public void SwitchScreen(int newScreen)
    {
        mainMenuCanvas.SetActive(newScreen == 0);
        level1Canvas.SetActive(newScreen == 1);
        level2Canvas.SetActive(newScreen == 2);
        gameCanvas.SetActive(newScreen == 3);
        level3Canvas.SetActive(newScreen == 4);
        currentScreen = newScreen;
    }

    public void SetGaming(bool value)
    {
        isGaming = value;
        soundTrackManager.SwitchActionMap(value);
    }
}
