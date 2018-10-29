using UnityEngine;

public class PitcherController : MonoBehaviour {

    public BaseballController Baseball;
    public Transform PitchPoint;
    public Material GoodBallMaterial;
    public Material BadBallMaterial;
    public Transform PitchTarget;

    public int RandomizeScale;

    Material CurrentBallMaterial;

	void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Pitch();
        }
	}

    void Pitch() {
        var newBaseball = Instantiate(Baseball,
                                      PitchPoint.position,
                                      PitchPoint.rotation);
        SetCurrentBallMaterial();
    }

    void SetCurrentBallMaterial() {
        int random = Random.Range(0, 100);
        CurrentBallMaterial = random % RandomizeScale == 0
            ? BadBallMaterial : GoodBallMaterial;
    }

    public Material GetCurrentBallMaterial() {
        return CurrentBallMaterial;
    }
}
