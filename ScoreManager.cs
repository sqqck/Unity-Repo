using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text Score;
    public int _score = 0;
    void Start()
    {
        UpdateScore();
    }
    public void AddScore(){
        _score += 1;
        UpdateScore();
    }
    public void RemoveScore(){
        _score -= 1;
        UpdateScore();
    }

    public void UpdateScore(){
        Score.text = "Score : " + _score.ToString();
    }
    public int GetScore(){
        return _score;
    }
}
