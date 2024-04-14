using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Practice1
{
    public class ColorPointController : MonoBehaviour
    {
        public ChainConnection.PointColor myColor;

        private bool _isSelected = false;
        public bool IsSelected { get => _isSelected; set => _isSelected = value; }

        // 初期化処理
        public void Init()
        {
            var mat = this.GetComponent<MeshRenderer>().material;
            Color color = Color.white;
            switch (myColor)
            {
                case ChainConnection.PointColor.Red:
                    color = Color.red;
                    break;
                case ChainConnection.PointColor.Blue:
                    color = Color.blue;
                    break;
                case ChainConnection.PointColor.Yellow:
                    color = Color.yellow;
                    break;
                case ChainConnection.PointColor.Green:
                    color = Color.green;
                    break;
                default:
                    break;
            }

            mat.SetColor("_Color", color);
            _isSelected = false;
        }
    }
}
