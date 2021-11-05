using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Vector2 mousePos;
    Vector2 objectPos;
    float angle;
    int ammo;
    bool canShoot = true;
    HealthAndDeath had;

    AudioSource gunshot;
    public GameObject bullet;
    public SpriteRenderer spriterenderer;
    public Animator animator;

    void Start()
    {
        gunshot = GetComponent<AudioSource>();
        had = GetComponent<HealthAndDeath>();
        rigid2D = GetComponent<Rigidbody2D>();
        ammo = 6;
    }

    void Update()
    {
        Move();
        Look();
        Shoot();

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
    }

    void Shoot()
    {
        if (had.states == State.Alive && Input.GetMouseButtonDown(0) && canShoot && ammo > 0)
        {
            gunshot.Play();
            GameObject tempBullet = Instantiate(bullet, transform.position, transform.rotation);
            Rigidbody2D rbBullet = tempBullet.GetComponent<Rigidbody2D>();
            rbBullet.velocity = mousePos.normalized * 3f;
            ammo--;
            canShoot = false;
            StartCoroutine(ShootBuffer(2));
        }
    }

    IEnumerator ShootBuffer(int sec)
    {
        yield return new WaitForSeconds(sec);
        canShoot = true;
    }
}