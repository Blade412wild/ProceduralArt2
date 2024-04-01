using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Map
{
    public static float MapFunction2(float _input, float _inMin, float _inMax, float _outMin, float _outMax)
    {
        float firstScaleLenght = _inMax - _inMin;
        float secondScaleLenght = _outMax - _outMin;

        //shift origin
        float offsetValue = _input - _inMin;

        //normalize
        float normalizedValue = offsetValue / firstScaleLenght;

        //Upscale
        float upscaleValue = normalizedValue * secondScaleLenght;

        // shift from origin
        float newValue = upscaleValue + _outMin;

        return newValue;
    }
}
