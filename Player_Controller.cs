using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    //Movement
    Rigidbody2D playerRB;
    Vector2 movement;
    public float moveSpeed;

    //In case of emergency (for rotation)
    [SerializeField] int angleOffset = 0;

    private void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        //User input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Mathf.Abs(movement.x) == 1 && Mathf.Abs(movement.y) == 1) //Makes diagonal speed equal to normal speed
        {
            movement.x *= Mathf.Sqrt(2f) / 2f;
            movement.y *= Mathf.Sqrt(2f) / 2f;
        }

        //Rotation
        var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + angleOffset;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void FixedUpdate() //Used for physics related processing like movement and such
    {
        playerRB.MovePosition(playerRB.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
