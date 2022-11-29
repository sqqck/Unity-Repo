using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreator : MonoBehaviour
{
    public List <GameObject> ItemList = new List<GameObject>();
    void Start()
    {
        for (int n = 0; n<(ItemList.Count);n++){
            for(int m = 0; m<2;m++){
                ItemCreation(ItemList[n].gameObject);
            }
        }
    }
    public void ItemCreation(GameObject _obj){
        GameObject item = Instantiate(_obj,new Vector3(Random.Range(-3,3),Random.Range(1,2),Random.Range(-4,5)),new Quaternion(Random.Range(1,5),Random.Range(1,5),Random.Range(1,5),Random.Range(1,5)));
        item.transform.parent = this.transform;
        item.name = _obj.name;
    }
}
