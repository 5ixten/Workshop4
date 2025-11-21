using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = slider.value;
    }
}
