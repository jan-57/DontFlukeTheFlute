using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject level1Canvas;
    public GameObject level2Canvas;
    public GameObject gameCanvas;
    

    private int currentScreen = 0;

    void Start()
    {
        mainMenuCanvas.SetActive(true);
        level1Canvas.SetActive(false);
        level2Canvas.SetActive(false);
        gameCanvas.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
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
                gameCanvas.SetActive(true);
                SwitchScreen(3);
                level1Canvas.SetActive(false);
                
                Debug.Log("Screen 1, Enter Pressed");
            }
            else if (currentScreen == 2)
            {
                level2Canvas.SetActive(false);
                gameCanvas.SetActive(true);
                SwitchScreen(3);
                Debug.Log("Screen 2, Enter Pressed");
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
        }
    }

    void SwitchScreen(int newScreen)
    {
        mainMenuCanvas.SetActive(newScreen == 0);
        level1Canvas.SetActive(newScreen == 1);
        level2Canvas.SetActive(newScreen == 2);
        gameCanvas.SetActive(newScreen == 3);
        currentScreen = newScreen;
    }
}
