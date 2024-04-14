using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Practice1
{
    public class ChainConnection : MonoBehaviour
    {
        [SerializeField] private GameObject _chainPrefab; // 線描画用Prefab
        private LineRenderer[] _chainLines = new LineRenderer[4];
        private ColorPointController _selectingPoint;
        private ColorPointController[] _colorPoints;

        public enum PointColor
        {
            Red,
            Blue,
            Yellow,
            Green,
            None,
        }

        private void Start()
        {
            _colorPoints = this.gameObject.GetComponentsInChildren<ColorPointController>();
            foreach (var point in _colorPoints)
            {
                // 全てのポイントを初期化
                point.Init();
            }
        }

        private void Update()
        {
            // ドラッグ開始時の処理
            if (Input.GetMouseButtonDown(0))
            {
                var colorPoint = GetClickedObj()?.GetComponent<ColorPointController>();

                // 線がつながれていない色の点がタップされたのか判定
                if (colorPoint && !colorPoint.IsSelected)
                {
                    ChainUpdate(colorPoint.myColor, colorPoint.transform.position, colorPoint.transform.position);
                    _selectingPoint = colorPoint;
                }
            }
            // ドロップ時の処理
            else if (Input.GetMouseButtonUp(0) && _selectingPoint)
            {
                if (!_selectingPoint) return;

                var colorPoint = GetClickedObj()?.GetComponent<ColorPointController>();

                // 対になる色の点上でドロップされたか判定
                if (colorPoint && colorPoint != _selectingPoint && colorPoint.myColor == _selectingPoint.myColor)
                {
                    ChainUpdate(_selectingPoint.myColor, _selectingPoint.transform.position, colorPoint.transform.position);
                    _selectingPoint.IsSelected = true;
                    colorPoint.IsSelected = true;
                }
                else
                {
                    HideChain(_selectingPoint.myColor);
                }
                _selectingPoint = null;
            }
            // ドラッグ中の処理
            else if (Input.GetMouseButton(0))
            {
                if (!_selectingPoint) return;

                Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _selectingPoint.transform.position.z);
                Vector3 endPosition = Camera.main.ScreenToWorldPoint(mousePosition);
                ChainUpdate(_selectingPoint.myColor, _selectingPoint.transform.position, endPosition);
            }

            // Escキーで押下時の処理
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _selectingPoint = null;
                foreach (PointColor color in System.Enum.GetValues(typeof(PointColor)) )
                {
                    HideChain(color);
                }
                foreach (var point in _colorPoints)
                {
                    point.IsSelected = false;
                }
            }
        }

        // クリックした位置にあるオブジェクトを取得
        private GameObject GetClickedObj()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            GameObject clickedGameObject = null;
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                clickedGameObject = hit.collider.gameObject;
            }

            return clickedGameObject;
        }

        // 線の位置を更新
        private void ChainUpdate(PointColor updateColor, Vector3 startPosition, Vector3 endPosition)
        {
            if (updateColor == PointColor.None) return;

            // 未生成の場合は生成
            if (_chainLines[(int)updateColor] == null)
            {
                _chainLines[(int)updateColor] = Instantiate(_chainPrefab).GetComponent<LineRenderer>();

                // 線の色を設定
                Color color = Color.white;
                switch (updateColor)
                {
                    case PointColor.Red:
                        color = Color.red;
                        break;
                    case PointColor.Blue:
                        color = Color.blue;
                        break;
                    case PointColor.Yellow:
                        color = Color.yellow;
                        break;
                    case PointColor.Green:
                        color = Color.green;
                        break;
                    default:
                        break;
                }
                _chainLines[(int)updateColor].startColor = color;
                _chainLines[(int)updateColor].endColor = color;
            }

            LineRenderer updateLine = _chainLines[(int)updateColor];

            // 非表示の場合は表示
            if (!updateLine.gameObject.activeSelf)
            {
                updateLine.gameObject.SetActive(true);
            }

            // 線を描画
            updateLine.SetPosition(0, startPosition);
            updateLine.SetPosition(1, endPosition);
        }

        // 線を非表示
        private void HideChain(PointColor hideColor)
        {
            if (hideColor == PointColor.None) return;

            if (_chainLines[(int)hideColor] != null)
            {
                _chainLines[(int)hideColor].gameObject.SetActive(false);
            }
        }
    }
}
