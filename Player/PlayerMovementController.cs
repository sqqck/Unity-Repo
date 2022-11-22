using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float forwardMovementSpeed;
    [SerializeField] private float horizontalMovementSpeed;
    [SerializeField] private float horizontalLimitValue;
    private float horizontalValue;
    private float newPositionX;
    void FixedUpdate()
    {
        SetPlayerForwardMovement();
        SetPlayerHorizontalMovement();
    }

    private void SetPlayerForwardMovement(){
        transform.Translate(Vector3.forward*forwardMovementSpeed*Time.fixedDeltaTime);
    }
    private void SetPlayerHorizontalMovement(){
        if (Input.GetMouseButton(0)){
            horizontalValue = Input.GetAxis("Mouse X");
            newPositionX = transform.position.x + horizontalValue * horizontalMovementSpeed * Time.fixedDeltaTime;
            newPositionX = Mathf.Clamp(newPositionX,-horizontalLimitValue,horizontalLimitValue);
            transform.position = new Vector3(newPositionX,transform.position.y,transform.position.z);
        }else{
            horizontalValue = 0;
        }
    }
}
