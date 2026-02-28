using System.Runtime.CompilerServices;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cube;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            var newCube = Instantiate(cube);
            newCube.transform.position = new Vector3 (Random.Range(-15, 15), 30, Random.Range(-15, 15));
        }
    }
}
