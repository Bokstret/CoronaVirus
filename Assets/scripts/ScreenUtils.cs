using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides screen utilities
/// </summary>
public static class ScreenUtils
{
	static float screenLeft;
	static float screenRight;
	static float screenTop;
	static float screenBottom;

	public static float ScreenLeft
    {
		get { return screenLeft; }
	}

	public static float ScreenRight
    {
		get { return screenRight; }
	}

	public static float ScreenTop
    {
		get { return screenTop; }
	}

	public static float ScreenBottom
    {
		get { return screenBottom; }
	}

	public static void Initialize()
    {
	
		float screenZ = -Camera.main.transform.position.z;
		Vector3 lowerLeftCornerScreen = new Vector3(0, 0, screenZ);
		Vector3 upperRightCornerScreen = new Vector3(
			Screen.width, Screen.height, screenZ);
		Vector3 lowerLeftCornerWorld = 
			Camera.main.ScreenToWorldPoint(lowerLeftCornerScreen);
		Vector3 upperRightCornerWorld = 
			Camera.main.ScreenToWorldPoint(upperRightCornerScreen);
		screenLeft = lowerLeftCornerWorld.x;
		screenRight = upperRightCornerWorld.x;
		screenTop = upperRightCornerWorld.y;
		screenBottom = lowerLeftCornerWorld.y;
	}
}
