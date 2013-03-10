using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {

    public int kills;
    public float engagePercent, releasePercent;
    public bool engageFixed, releaseFixed;

    GUIStyle style = new GUIStyle();
    GUIStyle bar = new GUIStyle();
    public Texture2D texture = new Texture2D(128, 128);

    int hitRate= -1;

    // Use this for initialization
    void Start()
    {
        hitRate = -1;
    }

    public void SetHitRate(int hitRate)
    {
        this.hitRate = hitRate;
    }

    void OnGUI()
    {
        GUILayout.Box("Kills: " + kills);
        GUILayout.Box("Engage: " + engagePercent);
        GUILayout.Box("Release: " + releasePercent);

        if (GUI.Button(new Rect(10, 500, 80, 30), "Restart"))
        {

            Application.LoadLevel(Application.loadedLevel);

        }

        handleEngagement(120, 30, 100, 20);
        handleRelease(120, 55, 100, 20);
        printHitRate();
    }

    private void printHitRate()
    {
        string hits = "Hit";
        switch (hitRate)
        {
            case 0:
                hits = "Perfect!";
                break;
            case 1:
                hits = "Almost perfect!";
                break;
            case 2:
                hits = "Good";
                break;
            case 3:
                hits = "Pretty good";
                break;
            case 4:
                hits = "Almost good";
                break;
            case 5:
                hits = "OK!";
                break;
            case 6:
                hits = "Average";
                break;
            case 7:
                hits = "Not good";
                break;
            case 8:
                hits = "Pretty bad";
                break;
            case 9:
                hits = "Even worse";
                break;
            case 10:
                hits = "Disaster!";
                break;
            default:
                hits = "Hit";
                break;
        }
        GUI.Box(new Rect(230, 40, 100, 30), new GUIContent(hits));
    }

    private void handleEngagement(float left, float top, float width, float height)
    {
       
            texture.Apply();

            style.normal.background = texture;
            GUI.Box(new Rect(left, top, width, height), new GUIContent(""), style);


            GUI.Box(new Rect(left + engagePercent, top, 2, height), new GUIContent(""));
        
    }

    private void handleRelease(float left, float top, float width, float height)
    {
        texture.Apply();

        style.normal.background = texture;
        GUI.Box(new Rect(left, top, width, height), new GUIContent(""), style);


        GUI.Box(new Rect(left + releasePercent, top, 2, height), new GUIContent(""));
    }

    void UpdateKills()
    {
     
        kills++;
    }
}
