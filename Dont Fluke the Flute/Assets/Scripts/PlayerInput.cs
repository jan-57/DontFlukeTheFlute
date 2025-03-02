using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private InputActionReference hit; 
    [SerializeField] private InputActionReference left;
    [SerializeField] private InputActionReference up;
    [SerializeField] private InputActionReference down;
    [SerializeField] private InputActionReference right;

    [SerializeField] private PointSystem pointSystem;

   
    [SerializeField] private List<NoteBehaviour>[] lanes = new List<NoteBehaviour>[4];

    private void Awake()
    {
        for (int i = 0; i < 4; i++)
        {
            lanes[i] = new List<NoteBehaviour>();
        }
    }

    private void OnEnable()
    {
        hit.action.Enable();
        left.action.Enable();
        up.action.Enable();
        down.action.Enable();
        right.action.Enable();

        hit.action.performed += OnHit;
        left.action.performed += OnLeft;
        up.action.performed += OnUp;
        down.action.performed += OnDown;
        right.action.performed += OnRight;
    }

    private void OnDisable()
    {
        hit.action.Disable();
        left.action.Disable();
        up.action.Disable();
        down.action.Disable();
        right.action.Disable();

        hit.action.performed -= OnHit;
        left.action.performed -= OnLeft;
        up.action.performed -= OnUp;
        down.action.performed -= OnDown;
        right.action.performed -= OnRight;
    }

    
    public void RegisterNote(int lane, NoteBehaviour note)
    {
        int index = lane - 1;
        
            lanes[index].Add(note);
        
    }

    
    public void NoteMissed(int lane, NoteBehaviour note)
    {

        Debug.Log("miss");
        int index = lane - 1;
        
        lanes[index].Remove(note);
            
        pointSystem.HandlePress("miss");
        Destroy(note.gameObject);
      
    }


    
    private void HandleLaneHit(int lane)
    {
        int index = lane - 1;
       
       
        if (lanes[index].Count > 0)
        {
            Debug.Log("hits something");
            NoteBehaviour note = lanes[index][0];
            string hitState = note.gameObject.tag;
            
            pointSystem.HandlePress(hitState);
            lanes[index].RemoveAt(0);
            Destroy(note.gameObject);
           
        }
        else
        {
            
            pointSystem.HandlePress("miss");
        }
    }

    
    private void OnLeft(InputAction.CallbackContext context)
    {
        Debug.Log("lefthit");
        HandleLaneHit(1);
    }

    private void OnUp(InputAction.CallbackContext context)
    {
        HandleLaneHit(2);
    }

    private void OnDown(InputAction.CallbackContext context)
    {
        HandleLaneHit(3);
    }

    private void OnRight(InputAction.CallbackContext context)
    {
        HandleLaneHit(4);
    }

    
    private void OnHit(InputAction.CallbackContext context)
    {
    }
}

