using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerNameTMP : MonoBehaviour
{
	/*--- Public Fields ---*/
	TextMeshProUGUI nameTMP;

	/*--- Protected Fields ---*/


	/*--- Private Fields ---*/


	/*--- MonoBehaviour Callbacks ---*/


	/*--- Public Methods ---*/
	public void SetName(string name)
    {
		nameTMP.text = name;
    }

	/*--- Protected Methods ---*/


	/*--- Private Methods ---*/
}