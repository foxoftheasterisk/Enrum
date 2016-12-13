using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KickItem : MonoBehaviour {

	public static int numKicked = 0;
	Text text;
	bool won=false;

	void Start() {
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		

		// Play a sound if the colliding objects had a big impact.		
		Debug.Log("Kick");
		string objectName; 
		GameObject kickedObject = collision.gameObject;

		//recognize furniture objects
		if (kickedObject.tag == "Furniture") {
			if (ImportNameFile.inverseProductCatalog.TryGetValue (kickedObject, out objectName)) {
				//print name of item
				Debug.Log (objectName);

				GameObject FoundItem = GameObject.Find("FoundItem");

				if (!won) {
					text = FoundItem.GetComponent <Text> ();
					text.text = "Found a " + objectName;
				}
				//check if on shopping list
				if(ShoppingList.myList.ContainsKey(objectName)){
					ShoppingList.myList[objectName] = true;
					Debug.Log("item found");
					Destroy (kickedObject);
					if (!ShoppingList.myList.ContainsValue(false)){
						won = true;
						Debug.Log("Game Completed!");
						text.text = "You've completed your shopping list!";
					}
				}

			} 
		}

	}
}