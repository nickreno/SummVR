using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSlider : SliderPosition
{
    public override void SliderAction()
    {
        Record.GetComponent<AudioSource>().volume = sv * 2000/9;
    }
}
