using UnityEngine;

public class DragAndSnap : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;
    public float gridSize = 1.0f; // ����Ĵ�С

    void OnMouseDown()
    {
        // ��¼�����ʱ��ƫ����
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mousePoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        offset = transform.position - Camera.main.ScreenToWorldPoint(mousePoint);
        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            // ��ȡ��굱ǰλ��
            Vector3 screenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z);
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(screenPoint) + offset;

            // ����ǰλ�ö��뵽����
            float x = Mathf.Round(currentPosition.x / gridSize) * gridSize;
            float z = Mathf.Round(currentPosition.z / gridSize) * gridSize;

            // ���������λ��
            transform.position = new Vector3(x, transform.position.y, z);
        }
    }

    void OnMouseUp()
    {
        // ֹͣ�϶�
        isDragging = false;
    }
}
