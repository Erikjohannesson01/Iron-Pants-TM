using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthAndDeath : MonoBehaviour
{
    int hp = 5;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) //TODO: ändra till fiendens attack
            hp--;

        if(hp <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
