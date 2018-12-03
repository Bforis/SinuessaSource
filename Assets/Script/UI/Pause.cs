using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

[SerializeField] private GameObject pausePanel;
public AudioSource AudioSource;
public AudioClip song;
    void Start()
    {
        pausePanel.SetActive(false);
    }
    void Update()
    {
        if(Input.GetButtonDown("pause")) 
        {
			Debug.Log("PAUSED");
            if (!pausePanel.activeInHierarchy) 
            {
                PauseGame();
                AudioSource.Pause();
            }
            else if (pausePanel.activeInHierarchy)
            {
                 ContinueGame();   
                 AudioSource.Play(0);
            }
        } 
     }
    private void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    } 
    private void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}
 