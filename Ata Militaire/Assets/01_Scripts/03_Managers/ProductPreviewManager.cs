using System.IO;
using UnityEngine;

public class ProductPreviewManager : Singleton<ProductPreviewManager>
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _autoRotationRate;
    [SerializeField] private float _manualRotationRate;

    private GameObject _currentProduct;

    private bool _manualRotation = false;

    private Vector3 _previousMousePosition;

    private void Awake()
    {
        _manualRotationRate = int.Parse(File.ReadAllText(System.IO.Path.Combine(Application.streamingAssetsPath, "Sensitivity.txt")));
    }

    private void Update()
    {
        HandleAutoRotation();
        HandleManualRotation();

        if (Input.GetMouseButtonDown(0))
        {
            _manualRotation = true;
            _previousMousePosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _manualRotation = false;
        }
    }

    public void SetCurrentProduct(ProductModel model)
    {
        if(_currentProduct != null)
        {
            Destroy(_currentProduct);   
        }

        _currentProduct = Instantiate(model.ProductAsset, _spawnPoint);
        _currentProduct.layer = LayerMask.NameToLayer("3D");
        _currentProduct.transform.localRotation = Quaternion.Euler(-20, 230, 0);
        _spawnPoint.transform.localEulerAngles = Vector3.zero;
        FitCameraToObject(_camera,_currentProduct);
    }

    private Bounds GetTotalBounds(GameObject obj)
    {
        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();

        if (renderers.Length == 0) return new Bounds(obj.transform.position, Vector3.zero);

        Bounds bounds = renderers[0].bounds;
        foreach (Renderer r in renderers)
            bounds.Encapsulate(r.bounds);

        return bounds;
    }

    void FitCameraToObject(Camera cam, GameObject target)
    {
        Bounds bounds = GetTotalBounds(target);

        float objectSize = Mathf.Max(bounds.size.x, bounds.size.y, bounds.size.z);
        float fov = cam.fieldOfView * Mathf.Deg2Rad;

        // Distance nécessaire pour voir tout l'objet
        float distance = (objectSize / 2f) / Mathf.Tan(fov / 2f);

        _spawnPoint.transform.localPosition = new Vector3(0, 0, distance);
    }

    private void HandleAutoRotation() 
    {
        if (_manualRotation)
        {
            return;
        }
        else
        {
            _spawnPoint.transform.Rotate(Vector3.up, _autoRotationRate * Time.deltaTime, Space.World);
        }
    }

    private void HandleManualRotation()
    {
        if (!_manualRotation) return;

        Vector2 delta = Input.mousePosition - _previousMousePosition;

        float rotX = delta.y * Time.deltaTime * _manualRotationRate;
        float rotY = delta.x * Time.deltaTime * _manualRotationRate;

        _spawnPoint.transform.Rotate(Vector3.up, -rotY, Space.World);

        _spawnPoint.transform.Rotate(Vector3.right, rotX, Space.World);

        _previousMousePosition = Input.mousePosition;
    }
}
