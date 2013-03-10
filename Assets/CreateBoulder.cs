using UnityEngine;
using System.Collections;

public class CreateBoulder : MonoBehaviour {

    public float BoulderRate;
    public float BoulderSpeed;
    public Rigidbody Boulder;

    private float timer;
    private bool timerStarted = false;

    // Update is called once per frame
	void Update () {
        if (!timerStarted)
        {
            timer = BoulderRate + Random.value * 50;
            timerStarted = true;
        }

        timer -= 1;
        if (timer <= 0.0)
        {
            Rigidbody b = Instantiate(Boulder, transform.position, transform.rotation) as Rigidbody;

            b.AddForce(Vector3.back * (BoulderSpeed + Random.value * 200));
            b.AddForce(Vector3.up * (200 + Random.value * 40));

            Vector3 v = new Vector3(0, 1, 0);

            timer = BoulderRate;
        }
	}
}
