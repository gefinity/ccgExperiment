using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardLayout : MonoBehaviour
{

	private const float padding = 0.01f;
	//private List<Vector3> nextChildPositions = new List<Vector3> ();
	private int numLayedOutChildren = 0;

	void Start ()
	{
	}

	void Update ()
	{

		int numChildren = transform.childCount;

		// layout children, centered and non-overlapping with padding
		// in the XZ plane
		// FIXME maybe should only do these when children are added/removed?
		if (numLayedOutChildren != numChildren) {
			for (int i = 0; i < numChildren; ++i) {
				Transform child = transform.GetChild (i);
				Collider childCollider = child.GetComponentInChildren<Collider> ();
				Vector3 size = childCollider.bounds.size;
				float width = size.x + Mathf.Max (padding, 0);

				float x = width * i;
				x -= (transform.childCount * width) / 2;
				x += width / 2;

				var nextPosition = new Vector3 (x, transform.position.y, transform.position.z);

				//nextChildPositions.Insert (i, nextPosition);

				iTween.MoveTo (child.gameObject, iTween.Hash ("position", nextPosition, "speed", 1));
			}
		}

		numLayedOutChildren = numChildren;

//		// animate children toward nextChildPositions
//		for (int i = 0; i < numChildren; ++i) {
//			Transform child = transform.GetChild (i);
//
//			//child.position = Vector3.Lerp (child.position, nextChildPositions [i], Time.deltaTime);	
//
//			//iTween.MoveTo(gameObject, nextChildPositions[i], iTween.Hash(easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
//			//iTween.MoveTo (child.gameObject, iTween.Hash ("position", nextChildPositions [i], "speed", 1));
//
//
//		}

	}

}