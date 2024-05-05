using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Practice4
{
    public class FireworkController : MonoBehaviour
    {
        [SerializeField] private GameObject _sparkEffect;
        private float _riseTime = 0;
        private float _nowTime = 0;

        private static readonly float RISE_SPEED = 0.04f;

        // Start is called before the first frame update
        void Start()
        {
            _riseTime = Random.Range(2f, 3f);
        }

        // Update is called once per frame
        void Update()
        {
            // 2～3秒のランダムな時間Y軸正方向に上昇
            if (_nowTime < _riseTime)
            {
                _nowTime += Time.deltaTime;
                this.transform.position += Vector3.up * RISE_SPEED;
            }
            else
            {
                // 火花エフェクトを生成し自身を削除
                Instantiate(_sparkEffect, this.transform.position, this.transform.rotation, null);
                Destroy(this.gameObject);
            }
        }
    }
}
