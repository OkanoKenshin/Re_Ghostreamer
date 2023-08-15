using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEditor;
using UnityEditor.Purchasing;
using UnityEngine;

public class test : MonoBehaviour
{
    private Re_Ghostreamer _ghostReamer;
    public interface IStomachState
    {
        void Start();
        void Update();
    }

    public class Player : IStomachState
    {
        private Re_Ghostreamer _ghostReamer;
        public void Start() 
        {
            _ghostReamer = new Re_Ghostreamer();
            _ghostReamer.Enable();
        }

        public void Update()
        {
            var look = _ghostReamer.Player.Look.ReadValue<Vector2>();
            var select = _ghostReamer.Player.Select.ReadValue<bool>();
        }
    }

    public class Streamer : IStomachState
    {
        private Re_Ghostreamer _ghostReamer;
        public void Start()
        {
            _ghostReamer = new Re_Ghostreamer();
            _ghostReamer.Enable();
        }

        public void Update()
        {
            var move = _ghostReamer.Streamer.Move.ReadValue<Vector2>();
            var look = _ghostReamer.Streamer.Look.ReadValue<Vector2>();
            var select = _ghostReamer.Streamer.Select.ReadValue<bool>();
            var dash = _ghostReamer.Streamer.Dash.ReadValue<bool>();
            var ghAttack = _ghostReamer.Streamer.StAttack.ReadValue<bool>();
        }
    }

    public class Ghost1 : IStomachState
    {
        private Re_Ghostreamer _ghostReamer;
        public void Start()
        {
            _ghostReamer = new Re_Ghostreamer();
            _ghostReamer.Enable();
        }

        public void Update()
        {
            var move = _ghostReamer.Ghost1.Move.ReadValue<Vector2>();
            var look = _ghostReamer.Ghost1.Look.ReadValue<Vector2>();
            var ability = _ghostReamer.Ghost1.Ability.ReadValue<bool>();
            var Attack = _ghostReamer.Ghost1.GhAttack.ReadValue<bool>();
        }
    }

    public class Ghost2 : IStomachState
    {
        private Re_Ghostreamer _ghostReamer;
        public void Start()
        {
            _ghostReamer = new Re_Ghostreamer();
            _ghostReamer.Enable();
        }

        public void Update()
        {
            var move = _ghostReamer.Ghost2.Move.ReadValue<Vector2>();
            var look = _ghostReamer.Ghost2.Look.ReadValue<Vector2>();
            var ability = _ghostReamer.Ghost2.Ability.ReadValue<bool>();
            var Attack = _ghostReamer.Ghost2.GhAttack.ReadValue<bool>();
        }
    }

    public class Ghost3 : IStomachState
    {
        private Re_Ghostreamer _ghostReamer;
        public void Start()
        {
            _ghostReamer = new Re_Ghostreamer();
            _ghostReamer.Enable();
        }

        public void Update()
        {
            var move = _ghostReamer.Ghost3.Move.ReadValue<Vector2>();
            var look = _ghostReamer.Ghost3.Look.ReadValue<Vector2>();
            var ability = _ghostReamer.Ghost3.Ability.ReadValue<bool>();
            var Attack = _ghostReamer.Ghost3.GhAttack.ReadValue<bool>();
        }
    }

    public class Human
    {
        private IStomachState _state;
        private Type.CharacterType _type;

        public Human(IStomachState state)
        {
            SetStatus(state);
        }

        public void SetStatus(IStomachState state)
        {
            _state = state;
        }

        public void Start()
        {
            _state.Start();
        }

        public void Update()
        {
            _state.Update();
        }
    }

}
