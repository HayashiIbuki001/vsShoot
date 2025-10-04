using UnityEngine;

public class PlayerPoint : MonoBehaviour
{
    private int point = 0;

    private void AddPoint(int getPoint)
    {
        point += getPoint;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PointItem pointItem = collision.GetComponent<PointItem>();
        if (pointItem != null)
        {
            AddPoint(pointItem.pointValue);
            Destroy(pointItem.gameObject);
        }
    }
}
