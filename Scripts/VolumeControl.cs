using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

/*Volume control slider script*/
public class VolumeControl : MonoBehaviour
{
    //public Slider volumeSlider;
    public string volumeName;
    public AudioMixer volumeMixer;
    public Text volumePercentText;
    
    //volume control function
    public void UpdateVolumeOnSlider(float value)
    {
        //set volume mixer object
        //control the master volume of all sound effects and music
        volumeMixer.SetFloat(volumeName, Mathf.Log(value) * 20f);
        //set percentage text value
        volumePercentText.text = Mathf.Round(value * 100.0f).ToString() + "%";
    }
}
