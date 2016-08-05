using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider slider;

    void Start()
    {
        this.slider = gameObject.GetComponent<Slider>();
    }

    public void updateValue(float newLife)
    {
        this.slider.value = newLife / 100;
    }
}