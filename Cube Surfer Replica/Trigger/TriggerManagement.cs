using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManagement : MonoBehaviour
{
    [SerializeField] private CollectableManager collectableManager;
    
    private bool isStack = false;
    void Start()
    {
        collectableManager = GameObject.FindObjectOfType<CollectableManager>();
    }
    private void OnTriggerEnter(Collider other){
        if (!isStack && this.gameObject.tag == "Collectable"){
            isStack = true;
            this.gameObject.tag = ("Collected");
            collectableManager.IncreaseBlockStack(this.gameObject);
        }
        if (this.gameObject.tag == "Barrier"){
            collectableManager.DecreaseBlockStack(other.gameObject);
            
        }
        if (this.gameObject.tag == "Finish"){
            collectableManager.Finished();
        }
    }

    
    
}
