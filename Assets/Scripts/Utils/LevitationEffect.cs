using System;
using UnityEngine;

namespace Utils
{
    public class LevitationEffect : MonoBehaviour
    {
        public float speedBounce = 1f;
        public float bounceIntensity = 1f;
    
        [Space]
        public bool rotate = false;
        public float speedRotation = 1f;
    
        private Transform _transform;
        private Vector3 _initialPosition;
    
        // Start is called before the first frame update
        void Start()
        {
            _transform = gameObject.GetComponent<Transform>();

            _initialPosition = _transform.position;
        }

        private void OnDisable()
        {
            _transform.position = _initialPosition;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if(rotate)
                _transform.Rotate(0, speedRotation * Time.deltaTime, 0);
            
            Debug.Log(_initialPosition);

            _transform.position = new Vector3(_transform.position.x ,(float) (_initialPosition.y + Math.Sin(Time.time * speedBounce) * bounceIntensity), _transform.position.z);
        }
    }
}