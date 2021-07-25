using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Timer : MonoBehaviour
{
	private double state; // Current elapsed miliseconds, max of this.timer.

	public int percent;  // Phone percent displayed on timer. 
	public int timer;    // Maximum amount of time in *seconds*. 
	public int offset; 	 // Time to wait in *seconds* before starting the timer. 
	private bool gameState; // True means the game is happening, false means game has ended. 

    // Start is called before the first frame update
    void Start()
    {
		this.gameState = true;

		if (this.timer == null)
		{
			// Default value for timer is 60 seconds. (60000 milisecndos)
			this.timer = 60000;
		}
		else 
		{
			this.timer *= 1000; // Convert to milliseconds.
		}

		if (this.offset == null)
		{
			this.offset = 3000;
		}
		else
		{
			this.offset *= 1000; 
		}
    }

    // Update is called once per frame
    void Update()
    {
		if (Time.time * 1000 > this.offset + this.timer && this.gameState)
		{
			this.gameState = false;
			UnityEngine.Debug.Log(Time.time * 1000); 
			UnityEngine.Debug.Log("Game End!"); 
		}
		else if (Time.time * 1000 > this.offset && this.gameState) 
		{
			UnityEngine.Debug.Log(Time.time * 1000); 
			UnityEngine.Debug.Log("Game Begin!"); 
		}
    }
}
