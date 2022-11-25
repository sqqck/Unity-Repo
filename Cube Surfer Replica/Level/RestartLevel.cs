using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartLevel : MonoBehaviour
{
    public static int Score;
    public Text scoreText;
    void Start(){
        scoreText.text = "Your Score: " + Score;
    }
    public void LoadLevel(){
        SceneManager.LoadScene(0);
    }
}
