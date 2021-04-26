using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _GameManager : MonoBehaviour {

    public GameObject goldWallEnter;
    public GameObject goldWallExit;
    public GameObject smallWallEnter;
    public GameObject smallWallExit;
    public GameObject portalWallEnter;
    public GameObject portalWallExit;
    public GameObject endgameUI;
    public GameObject pauseButton;
    public GameObject Text3D;

    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "ExitPortalWall")
        {
            FindObjectOfType<AudioManager>().Play("doorSlam");
            portalWallExit.GetComponent<MeshRenderer>().enabled = true;
            portalWallExit.GetComponent<BoxCollider>().isTrigger = false;
            goldWallExit.SetActive(true);
            smallWallExit.SetActive(false);
        }

        else if (col.gameObject.tag == "EnterPortalWall")
        {
            FindObjectOfType<AudioManager>().Play("doorSlam");
            portalWallEnter.GetComponent<MeshRenderer>().enabled = true;
            portalWallEnter.GetComponent<BoxCollider>().isTrigger = false;
            goldWallEnter.SetActive(true);
            smallWallEnter.SetActive(false);
            Text3D.SetActive(false);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "FinishArea")
        {
            FindObjectOfType<AudioManager>().Play("mazeVictory");
            GameObject.FindWithTag("Level").GetComponent<Player>().NewLevelPassed();
            Time.timeScale = 0f;
            pauseButton.SetActive(false);
            endgameUI.SetActive(true);
            Text3D.SetActive(true);
        }
    }
}
