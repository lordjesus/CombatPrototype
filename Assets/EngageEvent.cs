using UnityEngine;
using System.Collections;

public class EngageEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            
            GameObject enemy = gameObject.transform.parent.gameObject;
            enemy.renderer.material.color = Color.green;           

            other.GetComponent<Attack>().enemy = enemy.GetComponent<EnemyMovement>();
            other.GetComponent<Attack>().enemyObject = enemy;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
           
            
           
        }
    }
}
