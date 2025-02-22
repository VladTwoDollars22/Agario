﻿using AgarioGame.Engine.Core.Input.KeyBind;
using AgarioGame.Engine;
using AgarioGame;
using AgarioGame.Engine.Conrollers;

public class PlayerController : Controller, IInputHandler
{
    public KeyBindManager KeyBindManager;

    public PlayerController(){
        {
            
        }
    }

    public void SetKeyBindManager(KeyBindManager kb)
    {
        KeyBindManager = kb;
    }

    public void RegisterPlayerController(GameLoop loop)
    {
        loop.UpdateEvent += InputProcess;
    }

    public override void Update() { }
    public virtual void InputProcess() { }
    public virtual void InitializekeyBinds() { }
}
