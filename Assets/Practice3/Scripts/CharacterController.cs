using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Practice3
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private Transform _character;
        private float _maxRange = 8;
        private float _moveSpeed = 0.02f;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (_character.position.x < _maxRange)
                {
                    _character.position += Vector3.right * _moveSpeed;
                }
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (_character.position.x > -_maxRange)
                {
                    _character.position += Vector3.left * _moveSpeed;
                }
            }
        }
    }
}
