using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayerInputManager : MonoBehaviour
{
    
    [SerializeField] private InputActionReference left;
    [SerializeField] private InputActionReference up;
    [SerializeField] private InputActionReference down;
    [SerializeField] private InputActionReference right;

    [SerializeField] private PointSystem pointSystem;
    [SerializeField] private MenuScript menuScript;

    [SerializeField] private GameObject hitFeedback;
    [SerializeField] private GameObject leftOver;
   
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
      
        left.action.Enable();
        up.action.Enable();
        down.action.Enable();
        right.action.Enable();

       
        left.action.performed += OnLeft;
        up.action.performed += OnUp;
        down.action.performed += OnDown;
        right.action.performed += OnRight;
    }

    private void OnDisable()
    {
      
        left.action.Disable();
        up.action.Disable();
        down.action.Disable();
        right.action.Disable();

        
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
        LeftOver(note.gameObject.transform.position);
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
            LeftOver(note.gameObject.transform.position);
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
        if (menuScript.GetGaming())
        {
            HandleLaneHit(1);
            PressFeedback();
        }
        
    }

    private void OnUp(InputAction.CallbackContext context)
    {
        if (menuScript.GetGaming())
        {
            HandleLaneHit(2);
            PressFeedback();
        }
    }

    private void OnDown(InputAction.CallbackContext context)
    {
        if (menuScript.GetGaming())
        {
            HandleLaneHit(3);
            PressFeedback();
        }
    }

    private void OnRight(InputAction.CallbackContext context)
    {
        if (menuScript.GetGaming())
        {
            HandleLaneHit(4);
            PressFeedback();
        }
    }

    private void PressFeedback()
    {
        hitFeedback.SetActive(false);
        Invoke("EndFeedback", 0.1f);
    }

    private void EndFeedback()
    {
        hitFeedback.SetActive(true);
    }
  
    private void LeftOver(Vector2 position)
    {
        Instantiate(leftOver, new Vector3(position.x,position.y,99.5f), Quaternion.identity);
    }
}

