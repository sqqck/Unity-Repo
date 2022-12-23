using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matchable : MonoBehaviour
{
    [SerializeField] private CardMatchManager matchManager;
    bool isSelected;
    bool isMoveable;
    float timeElapsed;
    public float duration = 3;
    public Vector3 startPos;
    public Quaternion startRot;
    void Start()
    {
        matchManager = GameObject.FindObjectOfType<CardMatchManager>();
        isSelected = false;
        isMoveable = true;
        startPos = transform.position;
        startRot = transform.rotation;
    }

    void OnMouseDown(){
        if(GetPlaced()){
            matchManager.RemoveItem(gameObject);
        }else{
            matchManager.PlaceItem(gameObject);
        }
    }

    public bool GetPlaced(){
        return isSelected;
    }

    public void SetPlaced(){
        isSelected = !isSelected;
    }
    public bool GetMovable(){
        return isMoveable;
    }

    public void SetMovable(){
        isMoveable = !isMoveable;
    }
    
}
