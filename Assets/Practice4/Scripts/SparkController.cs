using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Practice4
{
    public class SparkController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            // 生成時にランダムな色を設定
            var spark = this.GetComponent<ParticleSystem>().main;
            var randomColor = Random.ColorHSV(0f ,1f, 0.8f, 1f, 0.8f, 1f); 
            spark.startColor = new ParticleSystem.MinMaxGradient(randomColor);
        }
    }
}
