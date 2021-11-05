using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthAndDeath : MonoBehaviour
{
    int hp = 5;
    bool canTakeDamage = true;
    public State states;
    private PlayerMovement move;

    void Awake()
    {
        move = GetComponent<PlayerMovement>();
        states = State.Alive;
    }

    void Update()
    {
        Dead();
        Alive();
        Prepare();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && canTakeDamage)
        {
            hp--;
            canTakeDamage = false;
            StartCoroutine(DamageBuffer(2));
        }
    }

    void Dead()
    {
        if (hp <= 0)
        {
            states = State.Dead;
        }

        if (states == State.Dead)
        {
            SceneManager.LoadScene(2);
        }
    }

    void Alive()
    {
        if (states == State.Alive)
        {
            move.enabled = true;
        }
    }
    void Prepare()
    {
        if(states == State.PrepareFase)
        move.enabled = false;
    }

    IEnumerator DamageBuffer(int secs)
    {
        yield return new WaitForSeconds(secs);
        canTakeDamage = true;
    }
}
