using UnityEngine;
using System.Collections;

public class FinalSphere : MonoBehaviour
{
    public bool collided = false;
    private bool collisionHistory = false;

    void Update()
    {
        //For tests
        //Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime / 2);
        //transform.position = newPos;
    }

    void OnTriggerEnter(Collider col)
    {
        if ((col.gameObject.transform.root.name == "target") && (collisionHistory == false))
        {
            this.collisionHistory = true;
            this.collided = true;
        }
    }
}
