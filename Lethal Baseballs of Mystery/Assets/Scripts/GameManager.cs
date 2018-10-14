using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject[] Fielders = new GameObject[7];

	void Start () {
        Fielders = GameObject.FindGameObjectsWithTag("Fielder");
    }

    void Update () {
		
	}
}
