using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderController : MonoBehaviour
{
    public TextMeshProUGUI valueText;
    public Slider volumeSlider;
    public AudioSource audioSource;
    public Image VolumeIcon;
    public Sprite[] VolumeIcons;

    void Start()
    {
        volumeSlider.value = audioSource.volume;
        volumeSlider.onValueChanged.AddListener(OnSliderChanged);
        OnSliderChanged(volumeSlider.value);
    }

    public void OnSliderChanged(float value) {
        valueText.text = "volume : " + (value * 100).ToString("F0") + "%";
        audioSource.volume = value;
        if (value == 0)
        {
            VolumeIcon.sprite = VolumeIcons[1];
        }
        else
        {
            VolumeIcon.sprite = VolumeIcons[0];
        }
    }
}
