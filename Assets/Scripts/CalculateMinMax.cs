using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateMinMax
{
    public float Min { get; private set; }
    public float Max { get; private set; }

    public CalculateMinMax() {
        Min = float.MaxValue;
        Max = float.MinValue;
    }

    public void AdjustMinMax(float v) {
        if (v > Max) {
            Max = v;
        }
        if (v < Min) {
            Min = v;
        }
    }
}
