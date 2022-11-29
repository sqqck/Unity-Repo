using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField] private ItemMatchManager matchManager;
    [SerializeField] private ItemCreator itemCreator;
    private float clampPosX = 5f;
    private float clampPosZ = 7f;
    public bool isPlaced = false;
    public bool isMovable = true;
    float CameraZDistance;
    Vector3 screenPos;
    Vector3 newWorldPos;
    void Start()
    {
        matchManager = GameObject.FindObjectOfType<ItemMatchManager>();
        itemCreator = GameObject.FindObjectOfType<ItemCreator>();
        CameraZDistance = Camera.main.WorldToScreenPoint(transform.position).z;
    }
    void FixedUpdate(){
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-clampPosX,clampPosX),transform.position.y,Mathf.Clamp(transform.position.z,-clampPosZ,clampPosZ));
    }
    public void RemoveItem(GameObject _obj){
        itemCreator.ItemCreation(_obj);
        Destroy(this.gameObject);
    }

    private void OnMouseDown(){
        if (!GetPlaced()){
            transform.GetComponent<Rigidbody>().useGravity = false;
            transform.GetComponent<Rigidbody>().isKinematic = true;
        }else{
            SetMovable(true);
            SetPlaced(false);
            RemoveItem(this.gameObject);
        }
    }

    private void OnMouseDrag(){
        if (isMovable && !isPlaced){
            screenPos = new Vector3(Input.mousePosition.x,Input.mousePosition.y,CameraZDistance);
            newWorldPos = Camera.main.ScreenToWorldPoint(screenPos);
            transform.position = newWorldPos;
        }
        
    }
    private void OnMouseUp(){
        if (!GetPlaced()){
            transform.GetComponent<Rigidbody>().isKinematic = false;
            transform.GetComponent<Rigidbody>().useGravity = true;
        }
        
    }
    public void SetPlaced(bool placed){
        isPlaced = placed;
    }
    public void SetMovable(bool move){
        isMovable = move;
    }
    public bool GetPlaced(){
        return isPlaced;
    }
    public bool GetMovable(){
        return isMovable;
    }
}
