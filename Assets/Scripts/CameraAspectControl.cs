using UnityEngine;
using System.Collections;

public class CameraAspectControl : MonoBehaviour {

    public float orthographicSize = 5;
    public float aspectRatio = 9 / 16.0f;
	void Start () {
        Camera.main.projectionMatrix = Matrix4x4.Ortho(
            -orthographicSize * aspectRatio, orthographicSize * aspectRatio
            , -orthographicSize, orthographicSize
            , 0.3f, 1000
        );
	}
	
}
