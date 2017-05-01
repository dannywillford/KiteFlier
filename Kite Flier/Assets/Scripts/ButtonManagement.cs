using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagement : MonoBehaviour {
    public void PlayGameBtn(string playGame)
    {
        SceneManager.LoadScene(playGame);
    }
}
