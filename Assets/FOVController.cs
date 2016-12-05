using UnityEngine;
using System.Collections;

public class FOVController : MonoBehaviour {

    private Camera camera;
    
    public Vector3 target;

    private float initialFov;
    private float l;
    private float L;
    private float fov;
    

    void Start() {
        camera = GetComponent<Camera>();
        initialFov = camera.fieldOfView;

        l = (transform.position - target).magnitude;
    }

	// Update is called once per frame
	void Update () {
        L = (transform.position-target).magnitude;
        if(Mathf.Abs(L - l)> 5e-4f) {
            fov = Mathf.Rad2Deg*2*Mathf.Atan(l*Mathf.Tan(Mathf.Deg2Rad*initialFov/2)/L);
            camera.fieldOfView = fov;

        }
        
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(target, 1);
    }
}
