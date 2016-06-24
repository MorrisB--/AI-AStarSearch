using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour {

	public float F = 0f;
	public float G = 0f;
	public float H = 0f;

	public List<Node> Adjacents;
	public Node parent;
	public LayerMask NodeLayerMask;
	// Use this for initialization
	void Start () {
		Collider[] nodeColliders = Physics.OverlapSphere (transform.position, 5.25f, NodeLayerMask);
		for (int i = 0; i < nodeColliders.Length; i++) {
			if (nodeColliders [i].transform != transform) {
				RaycastHit hit;
				if (Physics.Raycast (transform.position, nodeColliders [i].transform.position - transform.position, out hit)) {
					if(hit.transform == nodeColliders [i].transform) 
						Adjacents.Add (nodeColliders [i].GetComponent<Node> ());
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		Cost ();
		DrawLine ();
	}

	void Cost(){
		F = H + G;		
	}

	void DrawLine(){	// Draws a red line from this node to its adjacents
		for (int i = 0; i < Adjacents.Count; i++) {
			Vector3 direction = Adjacents [i].transform.position - transform.position;
			Debug.DrawRay (transform.position, direction, Color.green);
		}
	}
}
