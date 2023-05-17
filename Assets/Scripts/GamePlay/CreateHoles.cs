using UnityEngine;

public class CreateHoles : MonoBehaviour
{
    public GameObject holePrefab;
    public float jointDistance = 1f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(holePrefab, mousePosition, Quaternion.identity);

            // Liên kết lỗ mới tạo với lỗ trước đó (nếu có)
            ConnectHoles();
        }
    }

    private void ConnectHoles()
    {
        GameObject[] holes = GameObject.FindGameObjectsWithTag("Hole");

        if (holes.Length < 2)
            return;

        int lastIndex = holes.Length - 1;
        var previousHole = holes[lastIndex - 1].GetComponent<Rigidbody2D>();
        var currentHole = holes[lastIndex].GetComponent<Rigidbody2D>();

        var distanceJoint = currentHole.gameObject.AddComponent<DistanceJoint2D>();
        distanceJoint.connectedBody = previousHole;
        distanceJoint.distance = jointDistance;
    }
}
