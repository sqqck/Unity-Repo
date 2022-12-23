using System.Collections;
using UnityEngine;

public class CardMatchManager : MonoBehaviour
{
    public Transform leftSideObject,rightSideObject;

    public void PlaceItem(GameObject _obj){
        if (!_obj.GetComponent<Matchable>().GetPlaced()){
            SetItemSide(_obj);
        }
    }

    public void RemoveItem(GameObject _obj){
        if (_obj.GetComponent<Matchable>().GetPlaced()){
            _obj.transform.SetParent(null);
            Vector3 startPos = _obj.GetComponent<Matchable>().startPos;
            Quaternion startRot = _obj.GetComponent<Matchable>().startRot;
            StartCoroutine(MoveObject(_obj,_obj.transform.position,startPos,_obj.transform.rotation,startRot,1));
            _obj.GetComponent<Matchable>().SetPlaced();
        }
    }

    private void SetItemSide(GameObject _obj){
        if(_obj.transform.parent == null){
            return;
        }
        if (leftSideObject.childCount == 0){
            _obj.transform.SetParent(leftSideObject);
            StartCoroutine(MoveObject(_obj,_obj.transform.position,leftSideObject.position,_obj.transform.rotation,leftSideObject.rotation,1));
            return;
        }
        if (rightSideObject.childCount == 0){
            _obj.transform.SetParent(rightSideObject);
            StartCoroutine(MoveObject(_obj,_obj.transform.position,rightSideObject.position,_obj.transform.rotation,rightSideObject.rotation,1));
            return;
        }
    }
    
    private void CheckMatch(){
        if (leftSideObject.childCount == 0 || rightSideObject.childCount == 0){
            return;
        }
        if (leftSideObject.GetChild(0).name == rightSideObject.GetChild(0).name){
            StopCoroutine("MoveBack");
            Destroy(leftSideObject.GetChild(0).gameObject);
            Destroy(rightSideObject.GetChild(0).gameObject);
        }else{
            StopCoroutine("MoveBack");
            RemoveItem(leftSideObject.GetChild(0).gameObject);
            RemoveItem(rightSideObject.GetChild(0).gameObject);
        }
    }
    IEnumerator MoveObject(GameObject _obj,Vector3 source, Vector3 target, Quaternion sourceRot, Quaternion targetRot, float overTime)
    {
        if (!_obj.GetComponent<Matchable>().GetMovable()){
            yield return null;
        }
        float startTime = Time.time;
        _obj.GetComponent<Matchable>().SetMovable();
        while(Time.time < startTime + overTime)
        {
            _obj.transform.position = Vector3.Lerp(source, target, (Time.time - startTime)/overTime);
            _obj.transform.rotation = Quaternion.Lerp(sourceRot, targetRot, (Time.time - startTime)/overTime);
            yield return null;
        }
        _obj.GetComponent<Matchable>().SetPlaced();
        _obj.GetComponent<Matchable>().SetMovable();
        _obj.transform.position = target;
        yield return new WaitForSeconds(1);
        CheckMatch();
    }
}
