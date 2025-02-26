using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpenGame : MonoBehaviour 
{
    public Canvas[] canvases;
    [SerializeField] private InputActionReference PressEnter;
    [SerializeField] private InputActionReference ScrollUp;
    [SerializeField] private InputActionReference ScrollDown;

    private int activeCanvas = 0;

    void Start()
    {
        canvases[0].enabled = true;
        canvases[1].enabled = false;
        canvases[2].enabled = false;
        canvases[3].enabled = false;
        
    }

    private void OnEnable()
    {
        PressEnter.action.performed += EnterPressed;
        ScrollUp.action.performed += ScrollUpPressed;
        ScrollDown.action.performed += ScrollDownPressed;
        
    }
    
    private void OnDisable()
    {
        PressEnter.action.performed -= EnterPressed;
        ScrollUp.action.performed -= ScrollUpPressed;
        ScrollDown.action.performed -= ScrollDownPressed;
        
    }

   private void EnterPressed(InputAction.CallbackContext context)
    {
        switch (activeCanvas)
        {
            case 0:
                ChangeCanvas(1);
                break;
            
            case 1:
                ChangeCanvas(3);
                break;
            
            case 2:
                ChangeCanvas(3);
                break;
            
        }
    }

    private void ScrollUpPressed(InputAction.CallbackContext context)
    {
        switch (activeCanvas)
        {
            case 2:
                ChangeCanvas(1);
                break;
        }
    }

    private void ScrollDownPressed(InputAction.CallbackContext context)
    {
        switch (activeCanvas)
        {
            case 1:
                ChangeCanvas(2);
                break;
        }
    }

    void ChangeCanvas(int newCanvasIndex)
    {
        canvases[activeCanvas].enabled = false;
        canvases[newCanvasIndex].enabled = true;
    }


    void Update()
    {
        
    }
}