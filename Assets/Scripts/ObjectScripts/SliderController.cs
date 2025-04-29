using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderController : MonoBehaviour
{
    public TextMeshProUGUI valueText;
    public Slider volumeSlider;
    public AudioSource audioSource;
    public Image volumeIcon;
    public Sprite[] volumeIcons;

    void Start()
    {
        volumeSlider.value = audioSource.volume;
        volumeSlider.onValueChanged.AddListener(OnSliderChanged);
        OnSliderChanged(volumeSlider.value);
    }

    public void OnSliderChanged(float value)
    {
        valueText.text = "volume : " + (value * 100).ToString("F0") + "%";
        audioSource.volume = value;
        if (value == 0) // Change Icon if volume is 0
        {
            volumeIcon.sprite = volumeIcons[1];
        }
        else
        {
            volumeIcon.sprite = volumeIcons[0];
        }
    }
}
