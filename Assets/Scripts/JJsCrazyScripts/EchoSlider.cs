using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoSlider : SliderPositionUp
{
    public override void SliderAction()
    {
        Record.GetComponent<AudioEchoFilter>().wetMix = (sv + 0.0045f) * 2000/9;
    }
}
