using UnityEngine;
using System.Collections;
using System;

public class LifeManager : MonoBehaviour
{
    public float life = 100;
    public event EventHandler<EventArgs> DeathEvent;
    bool killed = false;

    public float getLife()
    {
        return life;
    }

    public void hurt(float damage)
    {
        this.life -= damage;
        if (life <= 0)
        {
            life = 0;
            if ((this.DeathEvent != null) && !killed)
            {
                killed = true;
                this.DeathEvent(this, new EventArgs {});
                Debug.Log("Killed");
            }
        }
        else
        {
            //Debug.Log("New health of " + this.name + ": " + this.life.ToString());
        }
    }
}
