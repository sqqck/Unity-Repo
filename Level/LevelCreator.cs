using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{

    //todo: add collectable block much than barrier blocks
    //todo: add new chance system
    public Transform player;

    public List<GameObject> createdObjects = new List<GameObject>();
    public GameObject floorPrefab;
    public GameObject collectableCubePrefab;
    public GameObject barrierPrefab;
    public GameObject finishLinePrefab;
    private float floorLength;
    private float floorWidth;
    private Vector3 finishLinePosition;

    void Start()
    {
        FloorCreation();
        FinishLineCreation();
        BlockCreation();
    }

    
    private void FloorCreation(){
        floorLength = Random.Range(150f, 200.0f);
        floorWidth = 10f;
        var floorPosition = new Vector3(0, 0, floorLength*.5f-10);
        GameObject floor = Instantiate (floorPrefab, floorPosition, Quaternion.identity);
        SetParentGenerator(floor);
        floor.transform.localScale = new Vector3(floorWidth, 1, floorLength);
    }

    private void BlockCreation(){
        if (createdObjects[createdObjects.Count-1].transform.position.z > finishLinePosition.z-20f){
            return;
        }
        if(Random.value<0.75f){
            Collectables();
        }else{
            Barriers();
        }
    }
    private void Collectables(){
        GameObject objects = Instantiate (collectableCubePrefab, new Vector3(Random.Range(-4.5f, 4.5f),1,Random.Range(5f, 10f)+createdObjects[createdObjects.Count-1].transform.position.z+5f), Quaternion.identity);
        SetParentGenerator(objects);
        createdObjects.Add(objects);
        BlockCreation();
    }
    private void Barriers(){
        if (createdObjects[createdObjects.Count-1].tag == "Barrier"){
            return;
        }
        GameObject objects = Instantiate (barrierPrefab, new Vector3(0,1,Random.Range(5f, 10f)+createdObjects[createdObjects.Count-1].transform.position.z+5f), Quaternion.identity);
        SetParentGenerator(objects);
        createdObjects.Add(objects);
        BlockCreation();
    }
    
    private void FinishLineCreation(){
        finishLinePosition = new Vector3(0, 0, (floorLength)*.75f);
        GameObject finishLine = Instantiate (finishLinePrefab, finishLinePosition, Quaternion.identity);
        SetParentGenerator(finishLine);
        finishLine.transform.localScale = new Vector3(floorWidth-.5f, 1.1f, 1);
    }

    private void SetParentGenerator(GameObject _go){
        _go.transform.SetParent(transform);
    }
}
