using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEmission : MonoBehaviour
{
    [Range(0f, 1f)][SerializeField] private float emission;
    private Material material;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        Color color = new Color(emission, emission, emission);
        material.SetColor("_EmissionColor", color);
    }
}
