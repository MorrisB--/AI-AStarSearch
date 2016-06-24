using UnityEngine;
using System.Collections;

public class HumanRandomPosition : MonoBehaviour {

	public LayerMask NodeLayerMask;
	// Use this for initialization
	void Start () {
		Collider[] nodeColliders = Physics.OverlapSphere (transform.position, 15f, NodeLayerMask);
		transform.position = nodeColliders[Random.Range(0, nodeColliders.Length)].transform.position;
	}
}
