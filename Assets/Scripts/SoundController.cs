using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundController : MonoBehaviour {
    public static SoundController Instance { get; private set; }

    public AudioMixer audioMixer;
    public string masterVolumeParameter = "MasterVolume";
    public string musicVolumeParameter = "MusicVolume";
    public string sfxVolumeParameter = "SFXVolume";
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        masterVolumeSlider.onValueChanged.AddListener(volume => SetVolume(volume, masterVolumeParameter));
        musicVolumeSlider.onValueChanged.AddListener(volume => SetVolume(volume, musicVolumeParameter));
        sfxVolumeSlider.onValueChanged.AddListener(volume => SetVolume(volume, sfxVolumeParameter));
    }

    public void SetVolume(float volume, string volumeParameter) {
        audioMixer.SetFloat(volumeParameter, Mathf.Log10(volume) * 20);
    }
}