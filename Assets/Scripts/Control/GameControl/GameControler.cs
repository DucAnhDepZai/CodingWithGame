using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControler : MonoBehaviour
{
    public GameObject PauseMenue;
    public GameObject Things;
    public GameObject Teacher;
    public GameObject MusicON;
    public GameObject MusicOFF;
    public TMP_InputField console;
    private AudioSource Music;

    private void Awake()
    {
        Time.timeScale = 1;
        Music = GetComponent<AudioSource>();
    }
    private void Start()
    {
        
    }

    // Start is called before the first frame update
    public void pause()
    {
       
       Time.timeScale = 0;
       PauseMenue.SetActive(true);
       Things.SetActive(false);
        
    }
    public void Resume()
    {
        Time.timeScale = 1;
        PauseMenue.SetActive(false);
        Things.SetActive(true);
    }
    public void ToMenu()
    {
        PauseMenue.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuGame");
        
    }
    public void Restart()
    {
        PauseMenue.SetActive(false);
        Time.timeScale = 1;
        int thisScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(thisScene);

    }
    public void NextLV()
    {
        PauseMenue.SetActive(false);
        Time.timeScale = 1;
        int thisScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(thisScene);
    }
     public void TeacherBt()
    {
        if (Teacher.activeSelf == true) { 
            
            Teacher.SetActive(false);
        }
        else { Teacher.SetActive(true); }
    }
    public void OnMusic()
    {
        MusicON.SetActive(false);
        MusicOFF.SetActive(true);
        Music.Pause();
    }
    public void OffMusic()
    {
        MusicON.SetActive(true);
        MusicOFF.SetActive(false);
        Music.Play();
    }
}
