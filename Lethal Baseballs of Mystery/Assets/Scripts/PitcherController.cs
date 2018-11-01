using UnityEngine;

public class PitcherController : MonoBehaviour {

    public BaseballController Baseball;
    public Transform PitchPoint;
    public Material GoodBallMaterial;
    public Material BadBallMaterial;
    public Transform PitchTarget;

    public int RandomizeScale;

    bool CanPitch = true;
    bool HasPitched;
    Material CurrentBallMaterial;

	void Update() {
        if (CanPitch && Input.GetMouseButtonDown(0)) {
            Pitch();
        }
	}

    void Pitch() {
        var newBaseball = Instantiate(Baseball,
                                      PitchPoint.position,
                                      PitchPoint.rotation);
        SetCurrentBallMaterial();
        CanPitch = false;
        HasPitched = true;
    }

    void SetCurrentBallMaterial() {
        int random = Random.Range(0, 100);
        CurrentBallMaterial = random % RandomizeScale == 0
            ? BadBallMaterial : GoodBallMaterial;
    }

    public Material GetCurrentBallMaterial() {
        return CurrentBallMaterial;
    }

    public bool CanPitchAgain() {
        return CanPitch;
    }

    public void ResetCanPitch() {
        CanPitch = true;
    }

    public bool GetHasPitched() {
        return HasPitched;
    }

    public void ResetHasPitched() {
        HasPitched = false;
    }
}
