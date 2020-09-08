using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePickUp : MonoBehaviour
{
    private bool isholding = false;

    void Update()
    {
        if (isholding)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePos.x, mousePos.y);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            isholding = false;
        }
        
    }
    private void OnMouseOver()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            isholding = true;
        }
    }
}
