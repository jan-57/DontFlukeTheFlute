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

        PressEnter.action.Disable();
        ScrollUp.action.Disable();
        ScrollDown.action.Disable();
    }

    void Update()
    {
        if (canvases[0].enabled == true)
        {
            PressEnter.action.Enable();
            ScrollUp.action.Disable();
            ScrollDown.action.Disable();

            if (PressEnter.action.triggered)
            {
                canvases[0].enabled = false;
                canvases[1].enabled = true;
                canvases[2].enabled = false;
                canvases[3].enabled = false;
            }
        }

        if (canvases[1].enabled == true)
        {
            PressEnter.action.Enable();
            ScrollUp.action.Disable();
            ScrollDown.action.Enable();
            
            if (PressEnter.action.triggered)
            {
                canvases[0].enabled = false;
                canvases[1].enabled = false;
                canvases[2].enabled = false;
                canvases[3].enabled = true;
            }
            
            if (ScrollDown.action.triggered)
            {
                canvases[0].enabled = false;
                canvases[1].enabled = false;
                canvases[2].enabled = true;
                canvases[3].enabled = false;
            }
        }

        if (canvases[2].enabled == true)
        {
            PressEnter.action.Enable();
            ScrollUp.action.Enable();
            ScrollDown.action.Disable();
            
            if (PressEnter.action.triggered)
            {
                canvases[0].enabled = false;
                canvases[1].enabled = false;
                canvases[2].enabled = false;
                canvases[3].enabled = true;
            }
            
            if (ScrollUp.action.triggered)
            {
                canvases[0].enabled = false;
                canvases[1].enabled = true;
                canvases[2].enabled = false;
                canvases[3].enabled = false;
            }
        }

        if (canvases[3].enabled == true)
        {
            PressEnter.action.Disable();
            ScrollUp.action.Disable();
            ScrollDown.action.Disable();
        }
    }
}