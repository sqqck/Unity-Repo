using UnityEngine;

public class ItemMatchManager : MonoBehaviour
{

    public GameObject leftSide,rightSide;
    public Transform leftSideObject,rightSideObject;

    void FixedUpdate(){
        CheckMatch();
    }
    private void OnTriggerEnter(Collider other){
        if (other.gameObject.GetComponent<Items>().GetMovable()){
            PlaceItem(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other){
        if (leftSide == null || rightSide == null){
            return;
        }
        if(other.gameObject == leftSide.gameObject){
            leftSide = null;
            other.gameObject.GetComponent<Items>().SetPlaced(false);
        }
        if(other.gameObject == rightSide.gameObject){
            rightSide = null;
            other.gameObject.GetComponent<Items>().SetPlaced(false);
        }
    }
    private void PlaceItem(GameObject _obj){
        if (!_obj.GetComponent<Items>().GetPlaced()){
            _obj.GetComponent<Items>().SetPlaced(true);
            _obj.GetComponent<Items>().SetMovable(false);
            SetItemSide(_obj);
        }
    }

    private void SetItemSide(GameObject _obj){
        if (leftSide == null){
            leftSide = _obj;
            _obj.transform.position = leftSideObject.transform.position;
            _obj.transform.rotation = leftSideObject.transform.rotation;
            return;
        }
        if (rightSide == null){
            rightSide = _obj;
            _obj.transform.position = rightSideObject.transform.position;
            _obj.transform.rotation = rightSideObject.transform.rotation;
            return;
        }
    }
    private void CheckMatch(){
        if (leftSide == null || rightSide == null){
            return;
        }
        if (leftSide.name == rightSide.name){
            Debug.Log("Ayni");
            Destroy(leftSide);
            Destroy(rightSide);
            leftSide = null;
            rightSide = null;
        }else{
            leftSide.GetComponent<Items>().RemoveItem(leftSide);
            rightSide.GetComponent<Items>().RemoveItem(rightSide);
            leftSide = null;
            rightSide = null;
        }
    }
}
