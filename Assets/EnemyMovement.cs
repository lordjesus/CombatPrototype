using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public GameObject fire;
    public GameObject enemy;
    public float speed = 5;

    public bool isHit;

	// Update is called once per frame
	void Update () {
        Vector3 newPos = gameObject.transform.localPosition;

        newPos.z -= 0.05f;

        CharacterController controller = gameObject.GetComponent<CharacterController>() as CharacterController;

        Vector3 moveDirection = new Vector3(0, 0, -1);
        
        moveDirection *= speed;

       // gameObject.transform.localPosition = newPos;
        controller.Move(moveDirection * Time.deltaTime);

        
	}

    

    public void destroy()
    {
        gameObject.renderer.material.color = Color.white;
       
        
   //     Instantiate(enemy, transform.localPosition - new Vector3(Random.Range(0, 3), 0, -30), transform.localRotation);
        Destroy(gameObject);
        Instantiate(fire, transform.localPosition, transform.localRotation);

        GameObject.Find("GUI").GetComponent<GUIScript>().kills++;
       
    }
}
