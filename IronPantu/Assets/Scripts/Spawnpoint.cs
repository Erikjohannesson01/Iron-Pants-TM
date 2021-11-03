using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour
{

    public int openingdir;
    // 1 == bottom door
    // 2 == top door
    // 3 == left door
    // 4 == right door


    private Roomtemplates templates;
    private int randomroom;
    private bool spawns = false;

    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<Roomtemplates>();

        

        Invoke("Spawn", 1f);
    }



    private void Spawn()
    {

        if (spawns == false)
        {
            if (openingdir == 1)
            {
                randomroom = Random.Range(0, templates.bottomRooms.Length);

                Instantiate(templates.bottomRooms[randomroom], transform.position, templates.bottomRooms[randomroom].transform.rotation, transform.parent.parent);
            }
            //Need BottomDoor
            else if (openingdir == 2)
            {
                randomroom = Random.Range(0, templates.topRooms.Length);

                Instantiate(templates.topRooms[randomroom], transform.position, templates.topRooms[randomroom].transform.rotation, transform.parent.parent);
            }
            //Need TopDoor
            else if (openingdir == 3)
            {
                randomroom = Random.Range(0, templates.leftRooms.Length);

                Instantiate(templates.leftRooms[randomroom], transform.position, templates.leftRooms[randomroom].transform.rotation, transform.parent.parent);
            }
            //Need LeftDoor
            else if (openingdir == 4)
            {
                randomroom = Random.Range(0, templates.rightRooms.Length);

                Instantiate(templates.rightRooms[randomroom], transform.position, templates.rightRooms[randomroom].transform.rotation, transform.parent.parent);
            }
            //Need RightDoor

            spawns = true;
        }
   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spawnpoint") || other.GetComponent<Spawnpoint>().spawns == true)
        {
            Destroy(gameObject);
        }
    }
}
