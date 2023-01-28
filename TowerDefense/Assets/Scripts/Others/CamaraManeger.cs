using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 主鏡頭控制
/// </summary>
public class CamaraManeger : MonoBehaviour
{
    private bool switchCameraMovement = true; // 切換鏡頭移動

    [Header("Attribute")]
    public float scrollSpeed = 5f; // 滾動速度
    public float panSpeed = 30f; // 平移速度
    public float panBorderThickness = 10f; // 邊界厚度

    public float panCameraMinX = -30f; // 平移鏡頭的X軸最小值
    public float panCameraMaxX = 70f; // 平移鏡頭的X軸最大值
    public float panCameraMinZ = -30f; // 平移鏡頭的Z軸最小值
    public float panCameraMaxZ = 70f; // 平移鏡頭的Z軸最大值

    public float scrollCamaraMinY = 10f; // 縮放鏡頭的Y軸最小值
    public float scrollCamaraMaxY = 100f; // 縮放鏡頭的Y軸最大值

    void Update()
    {
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }


        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            switchCameraMovement = !switchCameraMovement; // 不直接設置成true或false是因為這樣可以更靈活切換, 而不是只能動一次
        }

        if (!switchCameraMovement)
        {
            return;
        }


        if (Input.GetKey("w") || (Input.mousePosition.y >= Screen.height - panBorderThickness))
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World); // 加上Space.World, 確保移動時是沒有經過旋轉鏡頭後的
        }
        if (Input.GetKey("s") || (Input.mousePosition.y <= panBorderThickness))
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World); // 加上Space.World, 確保移動時是沒有經過旋轉鏡頭後的
        }
        if (Input.GetKey("a") || (Input.mousePosition.x <= panBorderThickness))
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World); // 加上Space.World, 確保移動時是沒有經過旋轉鏡頭後的
        }
        if (Input.GetKey("d") || (Input.mousePosition.x >= Screen.width - panBorderThickness))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World); // 加上Space.World, 確保移動時是沒有經過旋轉鏡頭後的
        }
        
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 currentPosition = transform.position;
        currentPosition.y -= scroll * scrollSpeed * Time.deltaTime * 1000; // 乘以1000是因為數值只會在-1到1之間浮動

        currentPosition.y = Mathf.Clamp(currentPosition.y, scrollCamaraMinY, scrollCamaraMaxY);
        currentPosition.x = Mathf.Clamp(currentPosition.x, panCameraMinX, panCameraMaxX);
        currentPosition.z = Mathf.Clamp(currentPosition.z, panCameraMinZ, panCameraMaxZ);

        transform.position = currentPosition;
    }
}
