using UnityEngine;
using System.Collections;
using System;

public class LifeManager : MonoBehaviour
{
    public float life = 100;
    public event EventHandler<EventArgs> DeathEvent;

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
            if (this.DeathEvent != null)
            {
                this.DeathEvent(this, new EventArgs {});
            }
        }
        else
        {
            //Debug.Log("New health of " + this.name + ": " + this.life.ToString());
        }
    }
}
