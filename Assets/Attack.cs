using UnityEngine;
using System.Collections;
using System;

public class Attack : MonoBehaviour
{

    public EnemyMovement enemy;
    public GameObject enemyObject;

    // Use this for initialization
    void Start()
    {

    }

    private float engagePercent, releasePercent;

    private bool firePressed;

    bool engaged;

    // Update is called once per frame
    void Update()
    {
       
            if (enemy != null)
            {
               


               
                //Bounds bounds = enemy.GetComponentInChildren<BoxCollider>().bounds;
                Bounds bounds = enemyObject.transform.Find("EngageEvent").GetComponent<BoxCollider>().bounds;


                float min = bounds.min.z;
                float max = bounds.max.z;

                float range = max - min;

                float p = gameObject.transform.localPosition.z;
                float dist = p - min;
                print("min: " + min + ", p: " + p + ", max: " + max + ", range: " + range + ", dist: " + dist);


                float percentage = dist / range * 100;
               

                if (percentage > 0 && percentage < 100)
                {
                    engaged = true;

                    if (!firePressed)
                    {
                        GameObject.Find("GUI").GetComponent<GUIScript>().engagePercent = percentage;
                        engagePercent = percentage;
                    }
                    if (!firePressed && Input.GetButtonDown("Fire1"))
                    {
                        firePressed = true;
                        GameObject.Find("GUI").GetComponent<GUIScript>().engageFixed = true;


                    }
                }

                
            }

        

        
           
            if (engaged)
            {
                Bounds bounds = enemyObject.transform.Find("ReleaseEvent").GetComponent<BoxCollider>().bounds;


                float min = bounds.min.z;
                float max = bounds.max.z;

                float range = max - min;

                float p = gameObject.transform.localPosition.z;
                float dist = p - min;
                print("min: " + min + ", p: " + p + ", max: " + max + ", range: " + range + ", dist: " + dist);


                float percentage = dist / range * 100;

                releasePercent = percentage;

                if (firePressed)
                {
                    GameObject.Find("GUI").GetComponent<GUIScript>().releasePercent = percentage;
                }

                if (firePressed && Input.GetButtonUp("Fire1"))
                {
                    firePressed = false;
                    if (percentage > 0 & percentage < 100)
                    {
                        //enemy.destroy();
                        enemy.isHit = true;
                        Time.timeScale = 0.3f;
                        GameObject.Find("Main Camera").GetComponent<CameraLock>().zoom = true;
                        enemy = null;
                        engaged = false;
                        CalculateHit();
                    }
                }


            }

    }

    private void CalculateHit()
    {
        float engageAccuracy = Math.Abs(engagePercent - 50);
        float releaseAccuracy = Math.Abs(releasePercent - 50);

        int engageRate = (int)engageAccuracy / 10;
        int releaseRate = (int)releaseAccuracy / 10;

        int hitRate = engageRate + releaseRate;

        GameObject.Find("GUI").GetComponent<GUIScript>().SetHitRate(hitRate);

        print("Engage rate: " + engageRate + "EngagePercent: " + engagePercent + ", releaseRate: " + releaseRate);
    }
}
