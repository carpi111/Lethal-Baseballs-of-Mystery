using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text StrikesCounter;

    GameManager GM;

	void Start() {
        GM = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
	}

    void Update() {
        UpdateStrikesCounter();
    }

    void UpdateStrikesCounter() {
        StrikesCounter.text = "Strikes: " + GM.GetStrikesCount().ToString();
    }
}
