using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUiScript : MonoBehaviour
{
    public void Play(){
        SceneManager.LoadScene("OverworldScene");
    }
    public void Quit(){
		Application.Quit();
    }
}
