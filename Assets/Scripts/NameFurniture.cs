using UnityEngine;
using System.Collections.Generic;

public class NameFurniture : MonoBehaviour {


	//setup product names before initializing game objects
	void Start() {

		//name any furniture objects this script is called on
		if (gameObject.tag == "Furniture") {

			//remove product name from list
			int listLength =ImportNameFile.productNameList.Count;
			int randomIndex = (int)Mathf.Floor (Random.Range (0, listLength));
			string objectName = ImportNameFile.productNameList [randomIndex];
			ImportNameFile.productNameList.Remove (objectName);
			ImportNameFile.usedNameList.Add (objectName);

			//add product name & id to product catalog
			ImportNameFile.productCatalog.Add (objectName, gameObject);
			ImportNameFile.inverseProductCatalog.Add (gameObject, objectName);


		}
	}		
}

