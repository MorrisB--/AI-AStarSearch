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

		while(OpenList.Count > 0) {
			Node currentNode = OpenList[0];

			for(int i = 0; i < currentNode.Adjacents.Count; i++) {
				currentNode.Adjacents[i].G = Vector3.Distance(currentNode.transform.position, currentNode.Adjacents[i].transform.position);
				currentNode.Adjacents[i].H = Vector3.Distance(currentNode.Adjacents[i].transform.position, TargetNode.transform.position);

				if (!OpenList.Contains(currentNode.Adjacents[i]) && !ClosedList.Contains(currentNode.Adjacents[i])) {
					OpenList.Add(currentNode.Adjacents[i]);
					currentNode.Adjacents[i].parent = currentNode;
				}
			}

			OpenList.Remove(currentNode);
			ClosedList.Add(currentNode);

			for (int i = 0; i < OpenList.Count; i++)
				if (OpenList [i].F < currentNode.F)
					currentNode = OpenList [i];

			if (currentNode == TargetNode)
				GetPath(StartNode, TargetNode);

		}
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
