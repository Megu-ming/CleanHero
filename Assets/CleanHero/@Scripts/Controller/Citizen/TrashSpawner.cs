using System.Collections;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public GameObject[] trashPrefabs; // 떨어뜨릴 쓰레기 프리팹
    public float interval = 5f;    // 몇 초마다 쓰레기 버릴지

    GameObject PickRandomTrash()
    {
        int index = Random.Range(0, trashPrefabs.Length);
        return trashPrefabs[index];
    }

    void Start()
    {
        StartCoroutine(DropTrashRoutine());
    }

    IEnumerator DropTrashRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            DropTrash();
        }
    }

    void DropTrash()
    {
        Instantiate(PickRandomTrash(), transform.position, Quaternion.identity);
    }
}
