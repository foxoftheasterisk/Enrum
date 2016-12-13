using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KickItem : MonoBehaviour {

	public static int numKicked = 0;
	Text text;		
	Text savings;

	static bool won;

	void Start() {
		won = false;
		GameObject TextDisplayField = GameObject.Find("FoundItem");
		text = TextDisplayField.GetComponent <Text> ();

		GameObject MoneyDisplayField = GameObject.Find("Savings");
		savings = MoneyDisplayField.GetComponent <Text> ();
	}

	void BuyObject(GameObject kickedObject, string objectName){
		double price = 10*Mathf.Ceil(Random.Range (1, 100))-.01;
		text.text = "Bought a " + objectName +"\nfor only $" + price.ToString();
		ShoppingList.bankAccount -= price;
		savings.text = "Life Savings: $" + ShoppingList.bankAccount.ToString ();
		if (ShoppingList.bankAccount<0){
			savings.color = Color.red;
		}
		Destroy (kickedObject);
	}


	//check to see if item is on shopping list and purchase as appropriate
	void checkShoppingList(GameObject kickedObject, string objectName){
		if (ShoppingList.myList.ContainsKey (objectName)) {
			ShoppingList.myList [objectName] = true;
			Debug.Log ("item found");
			//buy item
			BuyObject (kickedObject, objectName);

			//check for Win Condition
			if (!ShoppingList.myList.ContainsValue (false)) {
				won = true;
				Debug.Log ("Game Completed!");
				text.text = "You've completed your shopping list!";
			}
		
			//if your friend finds the item, buy anyways
		} else if (gameObject.tag == "Friend") {
			BuyObject (kickedObject, objectName);
		} else {
			text.text = "Found a " + objectName;
		}

	}

	//triggers automatically on impact with object
	void OnCollisionEnter2D(Collision2D collision)
	{				
		//Debug.Log("Kick");
		string objectName; 
		GameObject kickedObject = collision.gameObject;

		//recognize furniture objects
		if (kickedObject.tag == "Furniture") {
			if (ImportNameFile.inverseProductCatalog.TryGetValue (kickedObject, out objectName)) {
				//print name of item
				//Debug.Log (objectName);
				if (!won) {					
					//check if on shopping list
					checkShoppingList (kickedObject, objectName);
				}
			} 
		}

	}
}