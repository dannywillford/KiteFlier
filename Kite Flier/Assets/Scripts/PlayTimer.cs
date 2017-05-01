using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTimer : MonoBehaviour {

    public int playTime = 0; // << to manipulate time - be used to store later in playerprefs
    private int currentSeconds = 0;
    private int currentMinutes = 0;
    private int currentHours = 0;
    public string currentTime;
    private int bestTime = 0;
    public string topTime;
    GameObject player;
    private GUIStyle guiStyle = new GUIStyle();

	// Use this for initialization
	void Start () {
        StartCoroutine("Playtimer");
        player = GameObject.FindWithTag("Player");
        bestTime = PlayerPrefs.GetInt("Best Time");
	}

    private IEnumerator Playtimer()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            playTime += 1;
            currentSeconds = (playTime % 60);
            currentMinutes = (playTime / 60) % 60;
            currentHours = (playTime / 3600);
        }
    }

    void OnGUI()
    {
        currentTime = currentHours.ToString("00") + ":" + currentMinutes.ToString("00") + ":" + currentSeconds.ToString("00");
        topTime = (bestTime / 3600).ToString("00") + ":" + ((bestTime / 60) % 60).ToString("00") + ":" + (bestTime % 60).ToString("00");
        GUI.contentColor = Color.black;
        guiStyle.fontSize = 20;
        GUI.Label(new Rect(50, 410, 400, 50), "Current Time: " + currentTime, guiStyle);
        GUI.Label(new Rect(275, 410, 400, 50), "Best Time: " + topTime, guiStyle);

        if(player.GetComponent<PlayerController>().GameOver == true)
        {
            StopCoroutine("Playtimer");

            if(playTime > bestTime)
            {
                bestTime = playTime;
                PlayerPrefs.SetInt("Best Time", bestTime);
            }

            if(GUI.Button(new Rect (Screen.width / 2 - 50, Screen.height / 2 - 40, 100, 50),"Restart"))
            {
                playTime = 0;
                StartCoroutine("Playtimer");
                player.transform.position = new Vector2(-2.36f, 2.2f);
                player.GetComponent<PlayerController>().GameOver = false;
                player.GetComponent<PlayerController>().grassCollisionAudio = 1;
                player.GetComponent<PlayerController>().treeCollisionAudio = 1;
                player.GetComponent<PlayerController>().birdCollisionAudio = 1;
                //Application.LoadLevel(Application.loadedLevel);
            }
        }

    }

}
