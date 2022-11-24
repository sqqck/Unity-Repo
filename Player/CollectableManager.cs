using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectableManager : MonoBehaviour
{
    public List<GameObject> blockList = new List<GameObject>();
    [SerializeField] private ScoreManager scoreManager;
    private GameObject lastBlockObject;
    void Start()
    {
        UpdateBlockList();
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }
    public void IncreaseBlockStack(GameObject go){
        scoreManager.AddScore();
        transform.position = new Vector3(transform.position.x,transform.position.y+1f,transform.position.z);
        go.transform.parent = (transform);
        go.transform.position = new Vector3(lastBlockObject.transform.position.x,lastBlockObject.transform.position.y-1f,lastBlockObject.transform.position.z);
        go.GetComponent<BoxCollider>().isTrigger = false;
        blockList.Add(go);
        UpdateBlockList();
    }
    public void DecreaseBlockStack(GameObject go){
        if(blockList.Count == 1){
            Finished();
            return;
        }
        go.transform.parent = null;
        scoreManager.RemoveScore();
        blockList.Remove(go);
        UpdateBlockList();
    }
    private void UpdateBlockList(){
        lastBlockObject = blockList[blockList.Count -1];
    }
    public void Finished(){
        RestartLevel.Score = scoreManager.GetScore();
        SceneManager.LoadScene(1);
    }
}
