using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public Texture2D cursor;
    public Texture2D cursorClicked;
    private Camera maincamera;
    


    private CursorControlls controls;

    private void Awake()
    {
        controls = new CursorControlls();
        ChangeCursor(cursor);
        Cursor.lockState = CursorLockMode.Confined;
        maincamera = Camera.main; 
        
    }
    private void OnEnable()
    {
        controls.Enable();  
    }

    private void OnDisable()
    {
        controls.Disable();    
    }

    private void Start()
    {
        controls.Mouse.Click.started += _ => StartedClick();    
        controls.Mouse.Click.performed += _ => EndedClick();


    }

    private void StartedClick()
    {
        ChangeCursor(cursorClicked);


    }

    private void EndedClick()
    {
        ChangeCursor(cursor);
        DetectObject();

    }


    private void DetectObject()
    {
        Ray ray = maincamera.ScreenPointToRay(controls.Mouse.Position.ReadValue<Vector2>());
     


        RaycastHit2D hits2D = Physics2D.GetRayIntersection(ray);
        if (hits2D.collider != null)
        {
            Debug.Log("2D Hit: " + hits2D.collider.tag);
            hits2D.collider.gameObject.GetComponent<IClick>().OnClickAction();
        }














    }




    private void ChangeCursor(Texture2D cursorType)
    {
        
        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto); 
        

    }
    
}
