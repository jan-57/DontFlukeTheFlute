using System;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour // yes, this code is cursed, i know
{
    [SerializeField] private InputActionReference hit;
    [SerializeField] private InputActionReference left;
    [SerializeField] private InputActionReference right;
    [SerializeField] private InputActionReference up;
    [SerializeField] private InputActionReference down;
    [SerializeField] private string[] lane1 = { "null", "null", "null", "null", "null", "null", "null", "null", "null", "null" }; //didn't use an array array in order to be able to see the current state in the unity inspector in runtime
    [SerializeField] private string[] lane2 = { "null", "null", "null", "null", "null", "null", "null", "null", "null", "null" };
    [SerializeField] private string[] lane3 = { "null", "null", "null", "null", "null", "null", "null", "null", "null", "null" };
    [SerializeField] private string[] lane4 = { "null", "null", "null", "null", "null", "null", "null", "null", "null", "null" };
    [SerializeField] private int[] currentActiveNotesPerLane = {0,0,0,0};
    [SerializeField] private GameObject[] lane1Objects;
    [SerializeField] private GameObject[] lane2Objects;
    [SerializeField] private GameObject[] lane3Objects;
    [SerializeField] private GameObject[] lane4Objects;

    private void OnEnable()
    {
        hit.action.performed += PerformHit;
        left.action.performed += Left;
        right.action.performed += Right;
        up.action.performed += Up;
        down.action.performed += Down;

        for (int i = 0; i < 4; i++)
        {
            currentActiveNotesPerLane[i] = 0;
        }
    }

    private void OnDisable()
    {
        hit.action.performed -= PerformHit;
        left.action.performed -= Left;
        right.action.performed -= Right;
        up.action.performed -= Up;
        down.action.performed -= Down;
    }



    private void PerformHit(InputAction.CallbackContext context) 
    {



    }

    private void Left(InputAction.CallbackContext context)
    {

    }

    private void Right(InputAction.CallbackContext context)
    {

    }

    private void Up(InputAction.CallbackContext context)
    {

    }

    private void Down(InputAction.CallbackContext context)
    {

    }

    public void NoteUpdate(int lane, string newHitType, GameObject note)
    {
        if(newHitType == "fast") //register new hittable note
        {
            ChangeHitType(lane, newHitType, currentActiveNotesPerLane[lane - 1]);
            currentActiveNotesPerLane[lane - 1]++;
            note.GetComponent<NoteBehaviour>().SetPositionIndex(currentActiveNotesPerLane[lane - 1] - 1);
        }
        else if(newHitType == "good" || newHitType == "late")
        {
            ChangeHitType(lane, newHitType, note.GetComponent<NoteBehaviour>().GetPositionIndex());
        }
        else // miss
        {
            DestroyNote(lane - 1, 0); // destroys oldest object in lane

            for (int i = 0; i < currentActiveNotesPerLane[lane - 1] - 1; i++)
            {
              //  string temp = 
            }
        }
    }

    private void ChangeHitType(int lane, string newHitType, int noteIndex)
    {
        switch (lane)
        {
            case 1:
                lane1[noteIndex] = newHitType;
                break;

            case 2:
                lane2[noteIndex] = newHitType;
                break;

            case 3:
                lane3[noteIndex] = newHitType;
                break;

            case 4:
                lane4[noteIndex] = newHitType;
                break;
        }
    }

    public void NoteReset()
    {
        for (int lane = 0; lane < 4; lane++)
        {
            for (int index = 0; index < currentActiveNotesPerLane[lane]; index++)
            {
                DestroyNote(lane, index);
            }

            currentActiveNotesPerLane[lane] = 0;
        }
    }

    private void DestroyNote(int lane, int index)
    {
        switch (lane)
        {
            case 0:
                Destroy(lane1Objects[index]);
                break;

            case 1:
                Destroy(lane2Objects[index]);
                break;

            case 2:
                Destroy(lane3Objects[index]);
                break;

            case 3:
                Destroy(lane4Objects[index]);
                break;
        }
    }

   
}
