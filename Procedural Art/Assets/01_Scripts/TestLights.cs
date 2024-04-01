using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class TestLights : MonoBehaviour
{
    [SerializeField] int band;
    [SerializeField] float min;
    [SerializeField] float max;
    private Light light;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();   
    }

    // Update is called once per frame
    void Update()
    {
        light.intensity = (audioCollector.audioBandBuffer[band] * (max - min) + min);
    }
}
