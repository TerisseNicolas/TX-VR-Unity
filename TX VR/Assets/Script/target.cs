using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

    float life;

    void Awake()
    {
        this.life = 100;
    }

    public float getLife()
    {
        return life;
    }

    public void hurt(float damage)
    {
        this.life -= damage;
        if (life <= 0)
        {
            Debug.Log("Killed");
            life = 0;
        }
        else
        {
            Debug.Log("New health : " + this.life.ToString());
        }
    }
}
