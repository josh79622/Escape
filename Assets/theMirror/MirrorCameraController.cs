using UnityEngine;

[ExecuteAlways]
public class MirrorCameraController : MonoBehaviour
{
    public Transform mainCamera;     // 主攝影機 Transform
    public Camera mirrorCamera;      // 鏡子攝影機（注意是 Camera 類別）
    public Transform mirrorPlane;    // 鏡面 Transform（例如 Quad 或 Plane
    public float nearPointOffset = 0;

    void LateUpdate()
    {
        if (mainCamera == null || mirrorCamera == null || mirrorPlane == null)
            return;

        Vector3 mirrorNormal = mirrorPlane.forward.normalized;
        Vector3 mirrorPosition = mirrorPlane.position;

        // -------- 1. 計算鏡像位置 --------
        Vector3 camToMirror = mainCamera.position - mirrorPosition;
        float distanceToPlane = Vector3.Dot(camToMirror, mirrorNormal);
        Vector3 reflectedPos = mainCamera.position - 2 * distanceToPlane * mirrorNormal;
        mirrorCamera.transform.position = reflectedPos;

        // -------- 2. 鏡射方向 --------
        Vector3 reflectedForward = Vector3.Reflect(mainCamera.forward, mirrorNormal);
        Vector3 reflectedUp = Vector3.Reflect(mainCamera.up, mirrorNormal);
        mirrorCamera.transform.rotation = Quaternion.LookRotation(reflectedForward, reflectedUp);

        // -------- 3. 計算鏡面距離 --------
        float mirrorToCameraDist = Vector3.Dot(mirrorPosition - mirrorCamera.transform.position, mirrorNormal);

        // -------- 4. 計算夾角 a --------
        Vector3 dirToMainCam = (mainCamera.position - mirrorCamera.transform.position).normalized;
        Vector3 lookDir = mirrorCamera.transform.forward.normalized;
        float angleRad = Vector3.Angle(dirToMainCam, lookDir) * Mathf.Deg2Rad;

        // -------- 5. 計算 LookAt 點到鏡子中心距離（x）--------
        Vector3 lookAtPoint = mirrorCamera.transform.position + mirrorCamera.transform.forward;
        float x = Vector3.Distance(lookAtPoint, mirrorPosition);

        // -------- 6. 設定 nearClipPlane --------
        float extraOffset = Mathf.Tan(angleRad) * x;
        float near = Mathf.Max(0.01f, mirrorToCameraDist + extraOffset + nearPointOffset);
        mirrorCamera.nearClipPlane = near;

        // -------- 7. 計算鏡子的世界寬高 --------
        float mirrorWidth = 1f;
        float mirrorHeight = 1f;
        MeshFilter mf = mirrorPlane.GetComponent<MeshFilter>();
        if (mf != null && mf.sharedMesh != null)
        {
            Vector3 size = Vector3.Scale(mf.sharedMesh.bounds.size, mirrorPlane.lossyScale);
            mirrorWidth = size.x;
            mirrorHeight = size.y;
        }

        // -------- 8. 設定 FoV & Aspect，使視口剛好覆蓋鏡面 --------
        mirrorCamera.fieldOfView = Mathf.Atan(mirrorHeight / (2f * near)) * Mathf.Rad2Deg * 2f;
        mirrorCamera.aspect = mirrorWidth / mirrorHeight;
    }
}