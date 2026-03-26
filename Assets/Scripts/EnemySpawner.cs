using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _forceValue;
    [SerializeField] private int _prefabCount;
    [SerializeField] private Transform _target;

    private void Awake()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        for (var i = 0; i < _prefabCount; i++)
        {
            var enemy = Instantiate(_prefab);
            yield return new WaitForSeconds(1);
            enemy.GetComponent<Rigidbody>().AddForce(Vector3.right * _forceValue);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
