using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{

    private bool DraggingItem = false;
    private GameObject draggingObject;
    public List<Transform> targetLocs;

    void Update()
    {
        if (HasInput)
        {
            DragOrDrop();
        }else
        {
            if (DraggingItem)
            {
                DropItem();
            }
        }
    }

    private void DragOrDrop() { 
    
        var inputPosition = CurrentTouchPosition;

        if (DraggingItem)
        {
            draggingObject.transform.position = inputPosition;
        }

        else
        {
            //Layer Mask for draggable which only lets draggabke iteams be draggable
            LayerMask mask = LayerMask.GetMask("Draggable");

            //Raycast straight down from mouse and see what we hit
            RaycastHit2D[] touches = Physics2D.RaycastAll(inputPosition, inputPosition, 0.5f, mask);
            //Raycast returns an array of objects below

            if (touches.Length > 0)
            {
                var hit = touches[0];

                if (hit.transform != null)
                {
                    DraggingItem = true;
                    draggingObject = hit.transform.gameObject;
                }
            }
        }
    }

    Vector2 CurrentTouchPosition
    {
        get
        {
            Vector2 inputPos;
            inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return inputPos;
        }
    }

    private bool HasInput
    {
        get
        {
            return Input.GetMouseButton(0);
        }
    }

    private void DropItem()
    {
        DraggingItem = false;


        var distance = Vector2.Distance(draggingObject.transform.position, targetLocs[0].position);
        var target = targetLocs[0];

        foreach(Transform t in targetLocs) //shortcut for arrays
        {
            if(Vector2.Distance(draggingObject.transform.position, t.position) < distance)
            {
                target = t;
                distance = Vector2.Distance(draggingObject.transform.position, t.position);
            }
            if (distance < 1)
            {
                Vector2 matchedPosition = target.position;
                draggingObject.transform.position = matchedPosition;
            }
        }

    }

    //Below is different way to do it

    //private void OnCollision2DStay (Collision2D other)
    //{
    //    if (!DraggingItem)
    //    {
            
    //    }
    //}

}
