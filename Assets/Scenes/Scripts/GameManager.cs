using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public List<List<int>> matrix = new List<List<int>>(-1);
	public List<int> machines;
	public float tickTime;
	private float time;
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
		if (time < tickTime)
		{
			time += Time.deltaTime;
		}
		else
        {
			time -= tickTime;
			Tick();
        }
	}
	void Tick()
    {

    }
}
