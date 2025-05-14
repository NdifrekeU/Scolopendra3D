using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float rotateSpeed = 5f;


    void Start()
    {
    }

    void Update()
    {
        HandleRotation();
    }
    // Vector3 newGlobal1 = Handles.FreeMoveHandle(point.globalHandle1, point.transform.rotation, HandleUtility.GetHandleSize(point.globalHandle1) * 0.075f, Vector3.zero, Handles.CircleHandleCap);

    void HandleRotation()
    {
        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonDown(0))
        {

            prevMousePos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Input.mousePosition;

            Vector3 moveVec = mousePosition - prevMousePos;
            moveVec.y = moveVec.x;
            moveVec.x = moveVec.z = 0;
            transform.Rotate(moveVec);
            // transform.eulerAngles += Vector3.up * moveVec.x;
            prevMousePos = Input.mousePosition;

            // transform.rotation = Quaternion.LookRotation(new Vector3(moveVec.x, 0, moveVec.y));
            // transform.DORotate(transform.eulerAngles + new Vector3(moveVec.x, 0, moveVec.y), 0.5f);
        }
    }
    Vector3 prevMousePos;
    private Vector2 moveInput;

    void HandleMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        moveInput = new Vector2(h, v).normalized;
        Vector3 moveTarget = transform.position + new Vector3(moveInput.x, 0, moveInput.y) * moveSpeed * Time.deltaTime;
        transform.DOMove(moveTarget, Time.deltaTime).SetEase(Ease.Linear);
    }

}