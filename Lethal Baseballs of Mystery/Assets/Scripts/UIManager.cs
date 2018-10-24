using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    GameManager GM;
    Text StrikesCounter;

	void Start () {
        GM = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
	}
	
	void Update () {
		
	}

    void UpdateStrikesCounter() {
        StrikesCounter.text = "Strikes: " + GM.GetStrikesCount().ToString();
    }
}
