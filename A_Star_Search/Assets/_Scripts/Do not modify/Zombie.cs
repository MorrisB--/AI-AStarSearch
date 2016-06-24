using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

	public AStar astar;
	public Transform AnnoyingGuy;
	public GameObject CongratsText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		MoveAgent ();
		Attack ();
	}

	void MoveAgent()
	{
		if(astar.Path.Count > 0)
		{
			if(Vector3.Distance(transform.position, astar.Path[0].transform.position) > 0.5f)
			{
				transform.LookAt(new Vector3(astar.Path[0].transform.position.x, transform.position.y, astar.Path[0].transform.position.z));
				transform.position += transform.forward * Time.deltaTime * 5f;
			}
			else
			{
				if(astar.Path.Count > 0)
				{
					astar.Path.RemoveAt(0);
				}
			}
		}
	}

	void Attack(){
		if (Vector3.Distance (transform.position, AnnoyingGuy.position) < 2f) {
			AnnoyingGuy.position = new Vector3 (AnnoyingGuy.position.x, -1.5f , AnnoyingGuy.position.z);
			AnnoyingGuy.eulerAngles = new Vector3 (90, 0, 180);
			AnnoyingGuy.GetComponent<Animation> ().enabled = false;
			CongratsText.SetActive (true);
		}
	}
}
