using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CircleCubes : MonoBehaviour
{
    public audioCollector collector;
    public int band;
    public float starScale;
    public float scaleMultiplier;

    private void Start()
    {
        collector = FindFirstObjectByType<audioCollector>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.localScale = new Vector3(1, (collector.bandBuffer[band] * scaleMultiplier) + starScale, 1);

    }
}
