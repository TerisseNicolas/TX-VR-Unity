using UnityEngine;
using System.Collections;

public class EnemyDetector : MonoBehaviour
{
    public bool targetDetected = false;

    void OnTriggerEnter(Collider col)
    {
        if ((col.gameObject.transform.root.name == "target") && (targetDetected == false))
        {
            this.targetDetected = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if ((col.gameObject.transform.root.name == "target") && (targetDetected == true))
        {
            this.targetDetected = false;
        }
    }
}
