using UnityEngine;
using System.Collections;

public class LifeManager : MonoBehaviour {

    public float life = 100;

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
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("New health : " + this.life.ToString());
        }
    }
}
