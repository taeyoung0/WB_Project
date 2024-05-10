using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] 
    private GameObject[] pos;
    private Camera cameraController;
    private int viewState = 0;
    private bool isMoving = false;
    private Vector3 targetPosition;
    private float moveSpeed = 10f;
    private float currentSpeed = 0.2f;
    private float targetOrthographicSize;
    void Start()
    {
        cameraController = GetComponent<Camera>();
        if (cameraController != null)
        {
            cameraController.orthographicSize = 10.5f;
        }
        transform.position = pos[viewState].transform.position;
    }

    void Update()
    {
        if (!isMoving)
        {
            viewState = (viewState) % pos.Length;
            targetPosition = pos[viewState].transform.position;
            targetOrthographicSize = viewState != 0 ? 5f : 10.5f;
            StartCoroutine(MoveCameraAndZoom(targetPosition, targetOrthographicSize));
        }
    }

    IEnumerator MoveCameraAndZoom(Vector3 targetPos, float targetSize)
    {
        isMoving = true;
        float elapsedTime = 0;

        Vector3 startingPos = transform.position;
        float startingOrthoSize = cameraController.orthographicSize;
        currentSpeed *= 1.2f;
        if(moveSpeed < currentSpeed)
        {
            currentSpeed = moveSpeed;
        }
        while (elapsedTime < 1f)
        {
            transform.position = Vector3.Lerp(startingPos, targetPos, elapsedTime);
            cameraController.orthographicSize = Mathf.Lerp(startingOrthoSize, targetSize, elapsedTime);

            elapsedTime += Time.deltaTime * moveSpeed;
            yield return null;
        }

        transform.position = targetPos;
        cameraController.orthographicSize = targetSize;
        isMoving = false;
    }

    public void SetViewState(int i)
    {
        viewState = i;
    }
}
