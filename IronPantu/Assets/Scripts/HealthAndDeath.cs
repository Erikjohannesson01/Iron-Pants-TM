using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthAndDeath : MonoBehaviour
{
    int hp = 5;
    public State states;
    private PlayerMovement move;

    void Awake()
    {
        move = GetComponent<PlayerMovement>();
        states = State.Alive;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) //TODO: ändra till fiendens attack
            hp--;

        if(hp <= 0)
        {
            states = State.Dead;
        }

        if(states == State.Alive)
        {
            move.enabled = true;
        }

        if(states == State.Dead)
        {
            SceneManager.LoadScene(2);
        }
    }
}
