using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FollowMouse : MonoBehaviour, IPointerDownHandler
{
    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;
    private Rigidbody2D rb;
    private Vector2 position = new Vector2(-0.98f, 8.3f);
    private bool canMove;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canMove = false;
    }

    private void Update()
    {

        Vector2 pointOnScreen = Camera.main.WorldToScreenPoint(GetComponentInChildren<Renderer>().bounds.center);
        // GameObject.FindGameObjectWithTag("Your_Tag_Here").transform.position;
        if ((pointOnScreen.x > 0) && (pointOnScreen.x < Screen.width) &&
                        (pointOnScreen.y > 0) && (pointOnScreen.y < Screen.height))
        {
            if (Input.GetMouseButton(0) && canMove)
            {
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
                rb.MovePosition(position);
            }
        }

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
        canMove = !canMove;
    }

}