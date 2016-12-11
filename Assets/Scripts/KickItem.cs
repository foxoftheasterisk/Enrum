using UnityEngine;
using System.Collections;

public class KickItem : MonoBehaviour {

	public static int numKicked = 0;

	void Start() {
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		

		// Play a sound if the colliding objects had a big impact.		
		Debug.Log("Kick");
		string kickedObject; 


		if (ImportNameFile.inverseProductCatalog.TryGetValue(collision.gameObject, out kickedObject)) {
					
		} else {

			//assign a new name to object that is kicked
			kickedObject = ImportNameFile.productNames [numKicked];

			//add product name & id to product catalog
			ImportNameFile.productCatalog.Add (kickedObject, collision.gameObject);
			ImportNameFile.inverseProductCatalog.Add (collision.gameObject, kickedObject);

			numKicked++;
		}
		Debug.Log (kickedObject);
	}
}