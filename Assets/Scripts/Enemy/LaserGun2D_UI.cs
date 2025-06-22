using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserGun2D : MonoBehaviour
{
    public Transform originPoint;
    public float laserWidth = 0.1f;
    public float maxLaserDistance = 100f;
    public Material defaultMaterial;
    public Material hitMaterial;
    public bool rotateTowardMouse = true;
    public int laserDamage = 1;

    private LineRenderer lineRenderer;
    private Camera mainCam;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        mainCam = Camera.main;
        if (originPoint == null) originPoint = transform;
    }

    void Start()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.useWorldSpace = true;
        lineRenderer.startWidth = laserWidth;
        lineRenderer.endWidth = laserWidth;
        lineRenderer.widthCurve = AnimationCurve.Constant(0f, 1f, 1f);
        lineRenderer.material = defaultMaterial;
        Physics2D.queriesHitTriggers = true;
    }

    void Update()
    {
        if (mainCam == null) return;

        lineRenderer.startWidth = laserWidth;
        lineRenderer.endWidth = laserWidth;

        Vector3 mouseWorld = mainCam.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0f;

        if (rotateTowardMouse)
        {
            Vector2 dir = mouseWorld - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        Vector2 direction = (mouseWorld - originPoint.position).normalized;
        float distance = Mathf.Min(Vector2.Distance(originPoint.position, mouseWorld), maxLaserDistance);

        RaycastHit2D hit = Physics2D.Raycast(originPoint.position, direction, distance);
        Vector3 endPoint = hit.collider ? (Vector3)hit.point : originPoint.position + (Vector3)direction * distance;

        lineRenderer.material = (hit.collider != null && hit.collider.CompareTag("Hit")) ? hitMaterial : defaultMaterial;

        if (hit.collider != null)
        {
            var target = hit.collider.GetComponent<DestroyableObj>();
            if (target != null) target.takeDamage(laserDamage);
        }

        lineRenderer.SetPosition(0, originPoint.position);
        lineRenderer.SetPosition(1, endPoint);
    }
}
