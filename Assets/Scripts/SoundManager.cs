using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

   
    void Start()
    {
        
        if(!PlayerPrefs.HasKey("soundVolume"))
        {
           PlayerPrefs.SetFloat("soundVolume",1);
           Load();
        }
        else
        {
            Load();
        }
        
    }
    
    public void changeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
        
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("soundVolume");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("soundVolume",volumeSlider.value);
    }
}
