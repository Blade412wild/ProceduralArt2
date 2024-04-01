using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour
{
    public audioCollector collector;
    public int band;
    public float starScale;
    public float scaleMultiplier;
    public bool useBuffer;

    public GameObject child;
    private Material material;
    private void Start()
    {
        collector = FindFirstObjectByType<audioCollector>();
        material = child.GetComponent<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (useBuffer == true)
        {
            transform.localScale = new Vector3(transform.localScale.x, (collector.bandBuffer[band] * scaleMultiplier) + starScale, transform.localScale.z);
            Color color = new Color(audioCollector.audioBandBuffer[band], audioCollector.audioBandBuffer[band], audioCollector.audioBandBuffer[band]);
            material.SetColor("_EmissionColor", color);
        }

        if (useBuffer == false)
        {
            transform.localScale = new Vector3(transform.localScale.x, (collector.freqband[band] * scaleMultiplier) + starScale, transform.localScale.z);
            Color color = new Color(audioCollector.audioBandBuffer[band], audioCollector.audioBandBuffer[band], audioCollector.audioBandBuffer[band]);
            material.SetColor("_EmissionColor", color);
        }
    }
}
