using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AStar : MonoBehaviour {

	public List<Node> Path; // Keeps the nodes that form the path

	public void FindPath(Node StartNode, Node TargetNode)	// Finds the shortest path
	{	

		List<Node> OpenList = new List<Node>();	// Open list or Queue to store nodes to be expanded
		List<Node> ClosedList = new List<Node>(); // List of visited nodes. If a node is in this list, do not consider it for expanding

		OpenList.Add (StartNode); // Add the start node to the open list

		// Your code here...
		//
		//
	}

	void GetPath(Node startNode, Node targetNode){
		Node currentNode = targetNode;
		while (currentNode != startNode) {
			Path.Add (currentNode);
			currentNode = currentNode.parent;
		}
		Path.Reverse ();
	}

}
