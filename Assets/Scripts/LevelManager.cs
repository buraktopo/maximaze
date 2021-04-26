using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name){
        FindObjectOfType<AudioManager>().Play("button");
        SceneManager.LoadScene(name);
	}
	public void QuitRequest(){
        FindObjectOfType<AudioManager>().Play("button");
        Application.Quit();
    }
}
