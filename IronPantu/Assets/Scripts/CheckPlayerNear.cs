using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerNear : MonoBehaviour
{
    public bool PlayerInRange = false;
    public GameObject eButton;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInRange = true;
            eButton.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInRange = false;
            eButton.SetActive(false);
        }
    }
}
