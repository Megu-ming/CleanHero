using System.Collections;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public GameObject[] trashPrefabs; // ����߸� ������ ������
    public float interval = 5f;    // �� �ʸ��� ������ ������

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
