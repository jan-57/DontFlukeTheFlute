using UnityEngine;
using UnityEngine.InputSystem;

public class OpenGame : MonoBehaviour 
{
    public Canvas[] canvases;
    [SerializeField] private InputActionReference PressEnter;
    [SerializeField] private InputActionReference ScrollUp;
    [SerializeField] private InputActionReference ScrollDown;

    private int ActiveCanvas = 0;

    void Start()
    {
        canvases[0].enabled = true;
        canvases[1].enabled = false;
        canvases[2].enabled = false;
        canvases[3].enabled = false;
        
        
        PressEnter.action.Enable();
        ScrollUp.action.Enable();
        ScrollDown.action.Enable();
        
    }

    void Update()
    {
        if (ActiveCanvas == 0)
        {
            PressEnter.action.Enable();
            ScrollUp.action.Disable();
            ScrollDown.action.Disable();

            if (PressEnter.action.triggered)
            {
                ActiveCanvas = 1;
                canvases[0].enabled = false;
            }
        }

        else if (ActiveCanvas == 1)
        {
            PressEnter.action.Enable();
            ScrollUp.action.Disable();
            ScrollDown.action.Enable();
            
            if (PressEnter.action.triggered)
            {
                ActiveCanvas = 3;
                canvases[1].enabled = false;
            }
            
            if (ScrollDown.action.triggered)
            {
                ActiveCanvas = 2;
                canvases[1].enabled = false;

            }
        }

        else if (ActiveCanvas == 2)
        {
            PressEnter.action.Enable();
            ScrollUp.action.Enable();
            ScrollDown.action.Disable();
            
            if (PressEnter.action.triggered)
            {
                ActiveCanvas = 3;
                canvases[2].enabled = false;
            }
            
            if (ScrollUp.action.triggered)
            {
                ActiveCanvas = 1;
                canvases[2].enabled = false;
            }
        }
        
        
    }
}