using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControl_3F : MonoBehaviour, Character_Input.IMoveControlActions, Character_Input.IActionControlActions
{
    private Character_Input _input;
    private Vector2 inputVector;
    private bool isRunning = false;
    private bool isTouch = false;
    private bool isUse = false;
    private bool isJump = false;
    private bool isGround = false;
    private bool isLadder = false;
    private bool isEquip = false;
    public bool isVib = false;
    private GameObject _Camera;
    private GameObject _EquipPoint;

    public float moveSpeed = 1.0f;
    public float rotSpeed = 10.0f;
    float rotx, rot_h, rot_v;
    Vector3 rot;
    Rigidbody rb;

    RaycastHit rhit;
    Ray r, r_f;
    Camera cm;
    Vector3 characterPos, smoothPoint, dir, centerPos;
    float strength, strength2, strength_f, str_outline, slopeAngle;
    public float rad, rad2, soft, speed, smooth, rad_f, maxd;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _Camera = transform.GetChild(0).gameObject;
        _EquipPoint = _Camera.transform.GetChild(0).gameObject;
        cm = _Camera.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            moveSpeed = 5.0f;
        }
        else moveSpeed = 3.0f;
        
        if (isJump && isGround) {
            isGround = false;
            rb.AddForce(Vector3.up * 10.0f, ForceMode.Impulse);
        }

        CheckRay();

        Rotate();
    }

    void FixedUpdate()
    {
        if (!isLadder) {
            dir = Vector3.right * inputVector.x + Vector3.forward * inputVector.y;

            dir = Camera.main.transform.TransformDirection(dir);

            dir.Normalize();
            dir.y = 0.0f;
        }

        else {
            dir = Vector3.up * inputVector.y;
            dir.Normalize();
        }

        rb.MovePosition(rb.position + (dir * moveSpeed * Time.fixedDeltaTime));

    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.CompareTag("Ladder")) {
            rb.useGravity = false;
            isLadder = true;
        }
    }

    void OnCollisionExit(Collision c)
    {
        if (c.gameObject.CompareTag("Ladder")) {
            rb.useGravity = true;
            isLadder = false;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        inputVector = context.ReadValue<Vector2>();
    }

    public void OnRotate_Horizontal(InputAction.CallbackContext context)
    {
        rot_h = context.ReadValue<float>();
    }

    public void OnRotate_Vertical(InputAction.CallbackContext context)
    {
        rot_v = context.ReadValue<float>();
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() != 0) isRunning = true;
        else isRunning = false;
    }

    public void OnTouch(InputAction.CallbackContext context)
    {
        if (context.performed) isTouch = true;
        else isTouch = false;
    }

    public void OnStep(InputAction.CallbackContext context)
    {
        if (context.performed) {
            isJump = true;
        }
        else isJump = false;
    }

    public void OnUse(InputAction.CallbackContext context)
    {
        if (context.performed) isUse = true;
        else isUse = false;
    }

    private void OnEnable()
    {
        if (_input == null) {
            _input = new Character_Input();
        }

        _input.MoveControl.SetCallbacks(instance: this);
        _input.ActionControl.SetCallbacks(instance: this);
        _input.MoveControl.Enable();
        _input.ActionControl.Enable();
    }

    private void OnDisable()
    {
        _input.MoveControl.Disable();
        _input.ActionControl.Disable();
    }

    private void OnApplicationQuit()
    {
        if (Gamepad.current != null) {
            Gamepad.current.SetMotorSpeeds(0.0f, 0.0f);
            InputSystem.PauseHaptics();
            InputSystem.ResetHaptics();
        }
    }

    private void Rotate()
    {
        rotx = _Camera.transform.rotation.eulerAngles.x;
        rot = _Camera.transform.rotation.eulerAngles;
        rot.x -= rot_v * rotSpeed;
        rot.y += rot_h * rotSpeed;

        if (rot.x > 60.0f && rot.x < 300.0f) {
            if (rot.x - 60.0f < 10.0f) rot.x = 60.0f;
            else rot.x = 300.0f;
        }

        Quaternion q = Quaternion.Euler(rot);
        _Camera.transform.rotation = Quaternion.Slerp(_Camera.transform.rotation, q, 1.0f);
    }

    void CheckRay() 
    {
        r = new Ray(transform.position, Vector3.down);

        centerPos = new Vector3(cm.pixelWidth / 2.0f, cm.pixelHeight / 2.0f, 0);
        r_f = cm.ScreenPointToRay(centerPos);

        if (Physics.Raycast(r, out rhit, 1.1f)) {
            if (rhit.collider.tag == "Ground") {
                isGround = true;
            }
        }

        if (isTouch) {
            if (isEquip) {
                _EquipPoint.transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
                _EquipPoint.transform.DetachChildren();
                isEquip = false;
                isTouch = false;
            }
            else if (Physics.Raycast(r_f, out rhit, maxd)) {
                if (rhit.collider.tag == "Equip") {
                    isEquip = true;
                    isTouch = false;
                    rhit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    rhit.collider.gameObject.transform.SetParent(_EquipPoint.transform);
                    rhit.collider.gameObject.transform.localPosition = Vector3.zero;
                    rhit.collider.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                }
            }
        }

        if (isUse) {
            if (Physics.Raycast(r_f, out rhit, maxd)) {
                if (rhit.collider.tag == "Button") {
                    str_outline = 2.0f;
                    var obj = rhit.collider.gameObject;
                    obj.GetComponent<Button_3F>().isActive = true;
                }
            }
        }

        str_outline = Mathf.Lerp(str_outline, 0.0f, speed * Time.deltaTime);
        Shader.SetGlobalFloat("GLOBmask_outline", str_outline);
    }
}
