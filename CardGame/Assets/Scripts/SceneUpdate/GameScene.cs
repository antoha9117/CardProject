using UnityEngine;
using CardGame;

namespace CardGame.SceneUpdate
{
    class GameScene : MonoBehaviour
    {
        private void OnEnable()
        {
            Debug.Log("SingleGameScene:OnEnable");
        }

        private void Awake()
        {
            Debug.Log("SingleGameScene:Awake");
        }

        private void Start()
        {
            Debug.Log("SingleGameScene:Start");
        }

        private void Update()
        {
            Debug.Log("SingleGameScene:Update");
        }

        private void LateUpdate()
        {
            Debug.Log("SingleGameScene:LateUpdate");
        }

        private void OnDisable()
        {
            Debug.Log("SingleGameScene:OnDisable");
        }
    }
}
