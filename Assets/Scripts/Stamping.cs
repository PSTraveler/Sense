using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stamping : MonoBehaviour
{
    Ray r;
    RaycastHit rhit;
    float strength;
    float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckRay();        
    }

    void CheckRay()
    {
        r = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(r, out rhit, 1.1f)) {
            Vector4 pos3 = new Vector4(rhit.point.x, rhit.point.y, rhit.point.z, 0);
            strength = 3.0f;
            Shader.SetGlobalVector("FLOORmask_pos3", pos3);
        }

        strength = Mathf.Lerp(strength, 0.0f, speed * Time.deltaTime);
        Shader.SetGlobalFloat("FLOORmask_strength3", strength);
    }
}
