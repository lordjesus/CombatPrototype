using UnityEngine;
using System.Collections;

public class DestroyBoulder : MonoBehaviour {

    private int destroyTimer;
    private bool timerStarted = false;

	// Update is called once per frame
	void Update () {
        //if (GetComponent<Rigidbody>().velocity.magnitude <= 1)
        //{
        //    Destroy(gameObject);
        //}

        if (timerStarted)
        {
            destroyTimer -= 1;

            if (destroyTimer <= 0)
            {
                Destroy(gameObject);
            }
        }
	}

    void OnCollisionEnter(Collision col)
    {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().Sleep();
        Vector3 pos = gameObject.transform.position;
        pos.y = 3.0f;
        gameObject.transform.position = pos;

        timerStarted = true;
        destroyTimer = 30;
    }
}
