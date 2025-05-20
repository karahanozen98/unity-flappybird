using UnityEngine;

public static class CameraUtils
{
    public static float LeftEdge()
    {
        return Camera.main.transform.position.x - (Camera.main.orthographicSize * Camera.main.aspect);
    }

    public static float RightEdge()
    {
        return Camera.main.transform.position.x + (Camera.main.orthographicSize * Camera.main.aspect);
    }

    public static float TopEdge()
    {
        return Camera.main.transform.position.y + Camera.main.orthographicSize;
    }

    public static float BottomEdge()
    {
        return Camera.main.transform.position.y - Camera.main.orthographicSize;
    }
}