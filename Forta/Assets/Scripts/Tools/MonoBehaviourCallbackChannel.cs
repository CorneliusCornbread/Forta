using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

namespace Forta.Tools
{
    [DisallowMultipleComponent]
    public class MonoBehaviourCallbackChannel : MonoBehaviour
    {
        private static MonoBehaviourCallbackChannel _instance;
        public static MonoBehaviourCallbackChannel Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject pipeline = new GameObject("MonoBehaviour Callback Channel");
                    DontDestroyOnLoad(pipeline);
                    pipeline.AddComponent<MonoBehaviourCallbackChannel>();
                }

                return _instance;
            }
        }
        
        public UnityEvent OnUpdate { get; private set; }
        
        public UnityEvent OnFixedUpdate { get; private set; }
        
        private void Awake()
        {
            if (_instance == this) return;

            Assert.IsNull(_instance, $"Only one instance of MonoBehaviourCallbackChannel should be active at once \"{gameObject.name}\"");

            _instance = this;
            OnUpdate = new UnityEvent();
            OnFixedUpdate = new UnityEvent();
        }
        

        private void Update()
        {
            OnUpdate.Invoke();
        }

        private void FixedUpdate()
        {
            OnFixedUpdate.Invoke();
        }
    }
}
