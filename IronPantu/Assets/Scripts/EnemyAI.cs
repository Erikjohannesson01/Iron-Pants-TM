using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{

    public Transform target;

    public float speed = 200f;
    public float nextwpd = 3;


    Path path;
    int currentwp = 0;
    bool reachedeop = false;


    Seeker seeker;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {

        seeker = GetComponent<Seeker>();

        rb2d = GetComponent<Rigidbody2D>();


        InvokeRepeating("Updatepath", 0f, .5f);

    }


    void Updatepath()
    {
        if (seeker.IsDone())
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

        rb2d.AddForce(force);

        float distance = Vector2.Distance(rb2d.position, path.vectorPath[currentwp]);

        if (distance < nextwpd)
        {
            currentwp++;
        }
    }
}
