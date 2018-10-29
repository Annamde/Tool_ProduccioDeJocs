using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ToolScript : EditorWindow {

	string tag;
	Vector3 position;
	GameObject itemRandom;
	GameObject [] objects;

	[MenuItem("Window/Random")]

	public static void ShowWindow()
	{
		GetWindow<ToolScript> ("Random");
	}

	void OnGUI()
	{
		GUILayout.Label ("TOOL: Random GameObject with the same tag");

		tag = EditorGUILayout.TextField ("Tag", tag);
		position = EditorGUILayout.Vector3Field ("Position", position);

		if (GUILayout.Button ("Save")) {
			objects = GameObject.FindGameObjectsWithTag (tag);
		}

		if (GUILayout.Button ("Remove")) {
			for (int i = 0; i <= objects.Length; i++) {
				DestroyImmediate (objects [i].gameObject);
			}
		}

		if (GUILayout.Button ("Print Lenght")) {
			Debug.Log (objects.Length);
		}

		if (GUILayout.Button ("Random Item")) {

			if (objects.Length > 1) {
				int num = Random.Range (0, objects.Length);
				Debug.Log ("numero:  "+num);
				itemRandom = Instantiate (objects[num]);
				itemRandom.transform.position = position;
			}
				
		}
	}
		
}
