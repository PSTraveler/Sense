using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControl : MonoBehaviour, Character_Input.IMoveControlActions, Character_Input.IActionControlActions
{
    private Character_Input _input;
    private Vector2 inputVector;
    private bool isRunning = false;
    private bool isMove = false;
    private bool isStep = false;
    private bool isTouch = false;
    private bool isUse = false;
    public bool isVib = false;
    private GameObject _Camera;
    private List<GameObject> Waves;
    private GameObject closest;
    float shortDis, currentDis;

    public float moveSpeed = 1.0f;
    public float rotSpeed = 10.0f;
    float rotx, rot_h, rot_v;
    Vector3 rot;
    Rigidbody rb;

    RaycastHit rhit;
    Ray r, r_f;
    Camera cm;
    Vector3 characterPos, smoothPoint, dir, centerPos;
    float strength, strength2, strength_f, str_outline;
    public float rad, rad2, soft, speed, smooth, rad_f, maxd;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _Camera = transform.GetChild(0).gameObject;
        cm = _Camera.GetComponent<Camera>();

        Waves = new List<GameObject>(GameObject.FindGameObjectsWithTag("Wave"));
        closest = Waves[0];
        shortDis = Vector3.Distance(transform.position, Waves[0].transform.position);
        
        if (Gamepad.current != null) StartCoroutine(Vibrate());
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            moveSpeed = 5.0f;
        }
        else moveSpeed = 3.0f;

        Rotate();

        CheckRay();

        CheckWave();
    }

    void FixedUpdate()
    {
        dir = Vector3.right * inputVector.x + Vector3.forward * inputVector.y;

        dir = Camera.main.transform.TransformDirection(dir);

        dir.Normalize();
        dir.y = 0.0f;

        //transform.position += dir * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + (dir * moveSpeed * Time.deltaTime));
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        inputVector = context.ReadValue<Vector2>();
        if (inputVector != Vector2.zero) isMove = true;
        else isMove = false;

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
        if (context.performed) isStep = true;
        else isStep = false;
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

        if (isMove) {
            rad = 0.7f;
            if (Physics.Raycast(r, out rhit, 1.25f)) {
                smoothPoint = Vector3.MoveTowards(smoothPoint, rhit.point, smooth * Time.deltaTime);
                Vector4 pos = new Vector4(smoothPoint.x, smoothPoint.y, smoothPoint.z, 0);
                strength = 1.0f;
                Shader.SetGlobalVector("FLOORmask_pos", pos);
            }
        }

        if (isStep) {
            rad2 = 1.5f;
            if (Physics.Raycast(r, out rhit, 1.25f)) {
                smoothPoint = Vector3.MoveTowards(smoothPoint, rhit.point, smooth * Time.deltaTime);
                Vector4 pos2 = new Vector4(smoothPoint.x, smoothPoint.y, smoothPoint.z, 0);
                strength2 = 1.0f;
                Shader.SetGlobalVector("FLOORmask_pos2", pos2);
            }
        }

        if (isTouch) {
            if (Physics.Raycast(r_f, out rhit, maxd)) {
                Vector4 pos_f = new Vector4(rhit.point.x, rhit.point.y, rhit.point.z, 0);
                strength_f = 2.0f;
                Shader.SetGlobalVector("GLOBmask_pos", pos_f);
            }
        }

        if (isUse) {
            if (Physics.Raycast(r_f, out rhit, maxd)) {
                if (rhit.collider.tag == "Button") {
                    str_outline = 2.0f;
                    var obj = rhit.collider.gameObject;
                    obj.GetComponent<Button>().isActive = true;
                }
            }
        }

        strength = Mathf.Lerp(strength, 0.0f, speed * Time.deltaTime);
        strength2 = Mathf.Lerp(strength2, 0.0f, speed * Time.deltaTime);
        strength_f = Mathf.Lerp(strength_f, 0.0f, speed * Time.deltaTime);
        str_outline = Mathf.Lerp(str_outline, 0.0f, speed * Time.deltaTime);
        Shader.SetGlobalFloat("GLOBmask_rad", rad_f);
        Shader.SetGlobalFloat("GLOBmask_soft", soft);
        Shader.SetGlobalFloat("GLOBmask_strength", strength_f);
        Shader.SetGlobalFloat("GLOBmask_outline", str_outline);
        Shader.SetGlobalFloat("FLOORmask_rad", rad);
        Shader.SetGlobalFloat("FLOORmask_rad2", rad2);
        Shader.SetGlobalFloat("FLOORmask_soft", soft);
        Shader.SetGlobalFloat("FLOORmask_strength", strength);
        Shader.SetGlobalFloat("FLOORmask_strength2", strength2);
    }

    void CheckWave() {
        if (Gamepad.current == null) return;
        foreach (GameObject wave in Waves) {
            float dis = Vector3.Distance(transform.position, wave.transform.position);
            if (dis < shortDis) {
                closest = wave;
                Debug.Log(closest);
                shortDis = Vector3.Distance(transform.position, closest.transform.position);
            }
        }
        currentDis = Vector3.Distance(transform.position, closest.transform.position);
        
    }

    IEnumerator Vibrate() {
        currentDis = 0;
        while(true) {
            while (isVib && (Gamepad.current != null)) {
                float minv = Mathf.Clamp(1 / Mathf.Pow(currentDis, 3), 0.0f, 0.25f);
                Gamepad.current.SetMotorSpeeds(minv, minv);
                yield return new WaitForSeconds(0.5f);
                InputSystem.PauseHaptics();
                yield return new WaitForSeconds(1.0f);
                InputSystem.ResumeHaptics();
            }
            Gamepad.current.SetMotorSpeeds(0.0f, 0.0f);
            yield return null;
        }
    }
}
