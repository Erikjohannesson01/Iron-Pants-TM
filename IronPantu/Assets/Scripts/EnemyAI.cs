using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{

    public Transform target;

    public float speed = 200f;
    public float nextwpd = 3;

    public LayerMask obstaclelayer;

    bool chase = false;

    public float detectionradius;
    float _radius;

    float angle;

    Path path;
    int currentwp = 0;
    bool reachedeop = false;


    Seeker seeker;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        _radius = detectionradius;
        target = GameObject.FindGameObjectsWithTag("Player")[0].transform;

        seeker = GetComponent<Seeker>();

        rb2d = GetComponent<Rigidbody2D>();


        InvokeRepeating("Updatepath", 0f, .25f);

    }



    void Update()
    {
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb2d.rotation = angle + 90;
    }
    void Updatepath()
    {

        if (Mathf.Pow(target.position.x - transform.position.x, 2) + Mathf.Pow(target.position.y - transform.position.y, 2) < Mathf.Pow(_radius, 2))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, target.position - transform.position, 1f, obstaclelayer);

            if(hit.collider == null)
            {
                chase = true;
                _radius = detectionradius * 2;
            }
        }
        else
        {
            chase = false;
            _radius = detectionradius;
        }
        if (seeker.IsDone() && chase)
            seeker.StartPath(rb2d.position, target.position, Onpath);
    }



    void Onpath(Path p)
    {

        if (!p.error)
        {
            path = p;

            currentwp = 0;
        }

    }

        // Update is called once per frame
    void FixedUpdate()
    {
        if ( path == null)
        {
            return;
        }

        if (currentwp >= path.vectorPath.Count)
        {
            reachedeop = true;
            return;
        }
        else
        {
            reachedeop = false;
        }


        Vector2 dir = ((Vector2)path.vectorPath[currentwp] - rb2d.position).normalized;
        Vector2 force = dir * speed * Time.deltaTime;

        rb2d.velocity = force;
        //rb2d.AddForce(force);

        float distance = Vector2.Distance(rb2d.position, path.vectorPath[currentwp]);

        if (distance < nextwpd)
        {
            currentwp++;
        }

        
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y, 0), _radius);
    }



}
