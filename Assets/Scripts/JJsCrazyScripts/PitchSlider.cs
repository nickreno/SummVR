using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchSlider : SliderPosition
{
    public override void SliderAction()
    {
        Record.GetComponent<DJRecord>().speed = sv * 444;
    }
}
