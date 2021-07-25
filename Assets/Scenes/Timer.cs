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
		// Time since the game began.
		double elapsed = (Time.time * 1000) - this.offset; 
		if (elapsed > this.timer && this.gameState)
		{
			this.gameState = false;
			// UnityEngine.Debug.Log("Game End!"); 
			this.percent = 0;
			// UnityEngine.Debug.Log(this.percent); 
		}
		else if (elapsed > 0 && this.gameState) 
		{
			// This is true if the game is running. 
			// UnityEngine.Debug.Log("Game Begin!"); 

			if (elapsed < (this.timer * 0.75)) 
			{
				this.percent = 10 - Mathf.RoundToInt((float) (elapsed / (this.timer * 0.09375)));
			}
			else 
			{
				if (this.timer - elapsed > (0.125 * this.timer)) 
				{
					this.percent = 2; 
				}
				else 
				{
					this.percent = 1;
				}
			}
			// UnityEngine.Debug.Log(this.percent);
		}

    }
}
