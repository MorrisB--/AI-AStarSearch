using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {

	public AStar astar;
	public Node StartNode;

	void Update () {
		SearchPathToNode ();
	}

	void SearchPathToNode()
	{
		Ray ray = Camera.main.ScreenPointToRay (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
			if (Input.GetMouseButtonDown (0) && hit.collider.tag == "Node") {
				Node endNode = hit.collider.GetComponent<Node> ();
				Debug.Log ("startNode: " + StartNode.name + " , endNode: " + endNode.name);
				astar.FindPath (StartNode, endNode);
			}
		}
	}
}
