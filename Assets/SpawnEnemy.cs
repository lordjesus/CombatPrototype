using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    private int timer;
    public int SpawnRate;
    public GameObject Controller;
	
	// Update is called once per frame
	void Update () {
        timer--;
        if (timer <= 0)
        {
            print("Spawning");
            timer = SpawnRate;
            Vector3 pos = transform.localPosition - new Vector3(0, 0, -30);
            pos.y = 4;
            pos.x = 3;
            Instantiate(Controller, pos, transform.localRotation);

           
            print("Pos: " + pos);
        }
	}
}
