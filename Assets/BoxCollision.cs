using UnityEngine;
using System.Collections;

public class BoxCollision : MonoBehaviour {

    private long startTick;
    private bool isActive = false;

	// Use this for initialization
	void Start () {
        Debug.Log("Start");
	}
	
	// Update is called once per frame
	void Update () {
        if (isActive)
        {

            Bounds bounds = gameObject.GetComponent<BoxCollider>().bounds;
            print("Center: " + bounds.center + ", min: " + bounds.min + ", max: " + bounds.max);
        }
	}

    void Destroy()
    {
        isActive = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            startTick = System.DateTime.Now.Ticks;
            Debug.Log("Trigger Enter ");
            GameObject enemy = gameObject.transform.parent.gameObject;
            enemy.renderer.material.color = Color.red;
            isActive = true;

            other.GetComponent<Attack>().enemy = enemy.GetComponent<EnemyMovement>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Trigger Exit " + ((System.DateTime.Now.Ticks - startTick) / 1000));
            GameObject enemy = gameObject.transform.parent.gameObject;
            if (enemy.GetComponent<EnemyMovement>().isHit)
            {
                enemy.GetComponent<EnemyMovement>().destroy();
            }
            else
            {
                enemy.renderer.material.color = Color.white;
            }
            isActive = false;
            Time.timeScale = 1.0f;
            GameObject.Find("Main Camera").GetComponent<CameraLock>().zoom = false;
        }
    }

    void OnCollisionEnter(Collision col)
    {
       // if (col.collider.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Collision");
        }
    }
}
