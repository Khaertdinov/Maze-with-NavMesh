using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class wlkwlkl : MonoBehaviour {
	
	 private GameObject player;

	private NavMeshAgent navmeshagent;

	private NavMeshHit nameshHit;

	private bool blocked = false;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		navmeshagent = player.GetComponent<UnityEngine.AI.NavMeshAgent> ();

	}

	public void OnPointerDown ()
	{
		RaycastHit hit;

		if (Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, out hit, 100f)) {
			blocked = UnityEngine.AI.NavMesh.Raycast (navmeshagent.gameObject.transform.position, hit.point, out nameshHit, UnityEngine.AI.NavMesh.AllAreas);

			Debug.DrawLine (navmeshagent.gameObject.transform.position, hit.point, blocked ? Color.red : Color.green, 10f);

			if (blocked) {
				Debug.DrawRay (nameshHit.position, Vector3.up, Color.red, 10f);
				navmeshagent.SetDestination (nameshHit.position);
			} else {
				navmeshagent.SetDestination (hit.point);
			}
		}
	}
}
