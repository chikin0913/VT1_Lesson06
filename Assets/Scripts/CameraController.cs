using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    #region --パラメータ:オブジェクト参照ー--
    public PlayerInput PlayerInput;
    public Camera Camera;
    public Transform CameraJoint;
    public Transform Target;
    public Vector3 Position;
    public Vector3 Angles;
    public Vector3 Distance;
    #endregion
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InputAction();
    }

    // Update is called once per frame
    void Update()
    {
        Position = transform.position;

        Angles.x = Mathf.Clamp(Angles.x, 0, 0);
    }

    void LateUpdate()
    {
        //カメラ位置を更新
        transform.position = Position;
        transform.eulerAngles = Angles;
        //rotation(Quaternion型）に直接代入した場合        
        //transform.rotation = Quaternion.Euler(Amgles);
    }

    private void InputAction()
    {
        if(PlayerInput == null)
        {
            Debug.LogError("PlayerInputが見つかりません。");
            return;
        }

        PlayerInput.actions["Look"].performed += context =>
        {
            var value = context.ReadValue<Vector2>();
            Angles.x += value.y;
            Angles.y += value.x;
        };
        PlayerInput.actions["Look"].Enable();
    }
}
