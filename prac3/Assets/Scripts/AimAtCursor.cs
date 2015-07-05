using UnityEngine;
using System.Collections;

public class AimAtCursor : MonoBehaviour {
	public GameObject bulletObject;
//	public GameObject aimCursor;
	public Transform fireFrom;
	public float shotSpeed = 20.0f;
	
	void Update () {
		RaycastHit rhInfo;
		Vector3 shootToward;

		//Dont really need this line
		Vector3 mousePos = Input.mousePosition;
		//Debug.Log (mousePos + " " + Screen.height);

		Ray mouseRay = Camera.main.ScreenPointToRay(mousePos);
		
		if(Physics.Raycast(mouseRay, out rhInfo, 30.0f)) {
			shootToward = rhInfo.point;
		} else {
			shootToward = mouseRay.origin + mouseRay.direction * 30.0f;
		}
//		if(aimCursor != null) {
//			aimCursor.transform.position = shootToward;
//		}
		transform.LookAt(shootToward);
		
		if( Input.GetMouseButtonDown(0) )
		{
			GameObject shotGO = (GameObject)Instantiate(bulletObject, fireFrom.position, fireFrom.rotation);
			Vector3 deltaPos = shootToward - shotGO.transform.position;
			shotGO.rigidbody.velocity = deltaPos.normalized * shotSpeed;
		}
	}
}
