using UnityEngine;

public class BaseballController : MonoBehaviour {

    public float Speed;

	void Start () {
        Destroy(gameObject, 3f);
	}
	
	void Update () {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
	}
}
