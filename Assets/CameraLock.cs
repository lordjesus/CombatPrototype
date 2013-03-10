using UnityEngine;
using System.Collections;

public class CameraLock : MonoBehaviour {

    public CharacterController Target;

    public float distance_x = 0.0f;
    public float distance_y = 0.0f;
    public float distance_z = 0.0f;

    private float y_bump = 0f;

    public bool zoom;

    private float zoominc = 0.0f;

    public float zoom_rate = 0.07f;

    private float logistic(float t)
    {
        return 1 / (1 + Mathf.Pow((float)System.Math.E, (-8 * t + 4)));
    }
	// Update is called once per frame
	void Update () {
        Vector3 newPos = Target.transform.position;
        newPos.x -= distance_x;
        newPos.y -= distance_y + Mathf.Sin(y_bump) * 0.1f;
        newPos.z -= distance_z;

        if (zoom)
        {
            if (zoominc < 1.0f)
            {
                zoominc += zoom_rate;
            }

        }
        else
        {
            if (zoominc > 0.0f)
            {
                zoominc -= zoom_rate;
            }
        }
        newPos.z += zoominc;

        y_bump += 0.25f;

        gameObject.transform.localPosition = newPos;

        gameObject.transform.LookAt(Target.transform);
	}
}
