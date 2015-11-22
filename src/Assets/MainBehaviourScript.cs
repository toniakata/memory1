using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainBehaviourScript : MonoBehaviour {

	public GameObject canvas;
	public GameObject button;
	public int index;
	Vector3[] positionArray = new [] { 	
		new Vector3(60,60,0),
		new Vector3(120,60,0),
		new Vector3(180,60,0),
		new Vector3(240,60,0),
		new Vector3(60,120,0),
		new Vector3(120,120,0),
		new Vector3(180,120,0),
		new Vector3(240,120,0),
		new Vector3(60,180,0),
		new Vector3(120,180,0),
		new Vector3(180,180,0),
		new Vector3(240,180,0),
	};
	static int number = 4 ;
	static int[] postions = new int[number];
	static int[] value = new int[number];
	// Use this for initialization
	void Start () {
		startgame ();
		
	}
	
	// Update is called once per frame
	void Update () {	
				
	}
	
	void getrandom(int[] value, int num, int max)
	{
		for (int i = 0; i < num; i++) {
			int next = 1;
			while (next > 0) {
				value [i] = Random.Range (0, max);
				next = 0;
				for (int j=0; j < i; j++) {
					if (value [i] == value [j])
						next++;
				}	
			}
		}
	}
	void arrangement(int[] a)
	{
		int i, j, n, tg;
		n = a.Length;
		for(i=0;i<n;i++) 
			for(j=i+1;j<n;j++) 
				if(a[i]>a[j]) 
			{ 
				tg=a[i];a[i]=a[j];a[j]=tg; 
			} 
	}

	IEnumerator timeout() {
		GameObject[] iteams;
		yield return new WaitForSeconds (3);
		iteams = GameObject.FindGameObjectsWithTag ("Tagbutton");
		foreach (GameObject iteam in iteams) {
			iteam.GetComponentInChildren<Text>().gameObject.SetActive(false);
		}
	}
	void startgame(){

		getrandom(postions,number,11);
		getrandom(value,number,9);
		arrangement (value);
		for (int i = 0; i< number; i++) {
			GameObject newButton = Instantiate (button);
			newButton.transform.SetParent (canvas.transform, false);
			newButton.transform.position = positionArray[postions[i]];
			newButton.GetComponentInChildren<Text>().text = value[i].ToString();
			newButton.gameObject.GetComponent<Button>().onClick.AddListener(() => checkposition(newButton));
		}
		//StartCoroutine(timeout());

	}
	public void checkposition(GameObject button_click){
		if ( button_click.gameObject.GetComponentInChildren<Text>().text == value[1].ToString())
					Debug.Log (value[1].ToString());
	}
}
