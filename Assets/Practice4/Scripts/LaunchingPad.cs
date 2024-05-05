using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Practice4
{
    public class LaunchingPad : MonoBehaviour
    {
        [SerializeField] private GameObject _fireworkPrefab;
        [SerializeField] private float _sideRange;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // X軸をカメラ枠内のランダムな値とすることで発射位置をずらす
                float sidePosition = Random.Range(-_sideRange, _sideRange);
                Vector3 launchiPosition = new Vector3(sidePosition, 0, 0);

                // 花火を発射
                Instantiate(_fireworkPrefab, launchiPosition, Quaternion.identity, null);
            }
        }
    }
}
