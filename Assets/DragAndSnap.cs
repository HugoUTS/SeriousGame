using UnityEngine;

public class DragAndSnap : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;
    public float gridSize = 1.0f; // 网格的大小

    void OnMouseDown()
    {
        // 记录鼠标点击时的偏移量
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mousePoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        offset = transform.position - Camera.main.ScreenToWorldPoint(mousePoint);
        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            // 获取鼠标当前位置
            Vector3 screenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z);
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(screenPoint) + offset;

            // 将当前位置对齐到网格
            float x = Mathf.Round(currentPosition.x / gridSize) * gridSize;
            float z = Mathf.Round(currentPosition.z / gridSize) * gridSize;

            // 更新物体的位置
            transform.position = new Vector3(x, transform.position.y, z);
        }
    }

    void OnMouseUp()
    {
        // 停止拖动
        isDragging = false;
    }
}
