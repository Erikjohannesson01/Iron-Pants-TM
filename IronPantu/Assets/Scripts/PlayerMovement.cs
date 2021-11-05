using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Vector2 mousePos;
    Vector2 objectPos;
    float angle;
    [SerializeField] private FieldOfView fieldOfView;

    public SpriteRenderer spriterenderer;
    public Animator animator;

    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        Move();
        //Look();
    }

    void Move()
    {
        float speed;

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
            speed = 0.5f;
        else
            speed = 1;


        Vector3 movement = new Vector3(x, y).normalized * speed;

        rigid2D.velocity = movement;
        if (movement.x < 0 || movement.x > 0)
        {
            animator.SetBool("Walking", true);
        }
        else if (movement.y < 0 || movement.y > 0)
        {
            animator.SetBool("Walking", true);
        }

        else
        {
            animator.SetBool("Walking", false);
        }
        
    }

    void Look()
    {
        mousePos = Input.mousePosition;
        Camera.main.ScreenToWorldPoint(mousePos);
        objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));




        fieldOfView.SetAimDir(Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position));
        fieldOfView.SetOrigin(transform.position);
    }
}