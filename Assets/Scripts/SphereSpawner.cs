using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    [SerializeField] private GameObject sphere;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            var newCube = Instantiate(sphere);
            newCube.transform.position = new Vector3(9, 9, 47);
        }
    }
}
