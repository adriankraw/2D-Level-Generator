//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Player/Input/MainChar.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @MainChar : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainChar()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainChar"",
    ""maps"": [
        {
            ""name"": ""Game"",
            ""id"": ""6ad5f41e-d6b3-4bf1-b48a-223242f9e6ad"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""9720d68e-faf6-4fc5-a962-ec3d43023bac"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Value"",
                    ""id"": ""c14146f0-0257-42a8-a9e3-cc6a19ccdfbb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""b7406ac0-e275-4eaa-9ebd-993e474ab58a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""66395d78-0c2c-48e2-b302-e1df0cd93cbd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MouseClick"",
                    ""type"": ""Button"",
                    ""id"": ""c0967f05-4e0d-4855-bdf1-3c38f7b0a8ce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""68d3ea96-3779-4aec-9dbc-5d474fdd9ad7"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""764d329e-0acd-4bac-bcbe-8518f5c80837"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""124cd68e-2b09-4914-b575-cb9e3b4df357"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""80416b09-6180-4e87-8086-e67dc94a14b8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a611422f-e8c6-4a6c-8ceb-0373295db116"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e8918abf-07a0-4868-8b69-8290e561060d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""642a5779-2f29-48cd-9dde-136a6f9f441c"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8336771e-b828-453f-9c18-726baeb9a9be"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""38d2c73e-37bb-4a3a-9683-1ffaf07c8357"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Screen"",
            ""id"": ""cc4ad13c-abb1-4040-b4ea-59690d4857b5"",
            ""actions"": [
                {
                    ""name"": ""Screen_Inv_1"",
                    ""type"": ""Button"",
                    ""id"": ""d51f1dc2-48b0-48bd-b95f-edcdd42948e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Screen_Inv_2"",
                    ""type"": ""Button"",
                    ""id"": ""9f8137be-3e01-411f-99dc-be42779d6394"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Screen_Inv_3"",
                    ""type"": ""Button"",
                    ""id"": ""614c1e87-e937-4d4b-a466-a26f5429c013"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Screen_Inv_4"",
                    ""type"": ""Button"",
                    ""id"": ""d8c664ad-0e86-444f-87e7-90bccc027295"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Screen_Inv_5"",
                    ""type"": ""Button"",
                    ""id"": ""7048b725-3b83-427d-9576-badae3ff1478"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Screen_Inv_6"",
                    ""type"": ""Button"",
                    ""id"": ""834ba343-89fe-4ea7-885a-b27ce9ec944f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Screen_Inv_7"",
                    ""type"": ""Button"",
                    ""id"": ""7c0b2420-2ee4-45d9-91e4-a5c16f165f08"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Screen_Inv_8"",
                    ""type"": ""Button"",
                    ""id"": ""51a99216-d8b1-4f27-9f14-525db43c1c90"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Screen_Inv_9"",
                    ""type"": ""Button"",
                    ""id"": ""ab24560d-56ad-41b5-9a9c-b5c4bc17c984"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Screen_Inv_0"",
                    ""type"": ""Button"",
                    ""id"": ""0b2a1c8b-89c6-4d54-8ff4-9880d7739352"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fd9e1988-3f92-40af-9c25-f8fbb2d8ef96"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Screen_Inv_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51b3ae2f-b89f-4fb3-9c95-36af13c34f4e"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Screen_Inv_2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""81a4b553-3a7d-4252-8c2b-c1b63f43791a"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Screen_Inv_3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ad6d336-6c49-4ea9-a010-f67bf2a18e48"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Screen_Inv_4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c9474bf4-48ee-4653-8664-eb42d06cbd40"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Screen_Inv_5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c6adac5-4eb8-4bd8-a02c-fff66d0ea252"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Screen_Inv_6"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""234d2f0d-0690-45fb-bd39-c3b8d337ce5b"",
                    ""path"": ""<Keyboard>/7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Screen_Inv_7"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6541560e-48f6-47a4-80fd-cd057ae230ec"",
                    ""path"": ""<Keyboard>/8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Screen_Inv_8"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1bf13bec-f0a5-4673-b67e-4b6970ad414a"",
                    ""path"": ""<Keyboard>/9"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Screen_Inv_9"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5f77ba3c-8508-4a74-ab0c-75ff4464ed3d"",
                    ""path"": ""<Keyboard>/0"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Screen_Inv_0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Game
        m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
        m_Game_Move = m_Game.FindAction("Move", throwIfNotFound: true);
        m_Game_Jump = m_Game.FindAction("Jump", throwIfNotFound: true);
        m_Game_Interact = m_Game.FindAction("Interact", throwIfNotFound: true);
        m_Game_MousePosition = m_Game.FindAction("MousePosition", throwIfNotFound: true);
        m_Game_MouseClick = m_Game.FindAction("MouseClick", throwIfNotFound: true);
        // Screen
        m_Screen = asset.FindActionMap("Screen", throwIfNotFound: true);
        m_Screen_Screen_Inv_1 = m_Screen.FindAction("Screen_Inv_1", throwIfNotFound: true);
        m_Screen_Screen_Inv_2 = m_Screen.FindAction("Screen_Inv_2", throwIfNotFound: true);
        m_Screen_Screen_Inv_3 = m_Screen.FindAction("Screen_Inv_3", throwIfNotFound: true);
        m_Screen_Screen_Inv_4 = m_Screen.FindAction("Screen_Inv_4", throwIfNotFound: true);
        m_Screen_Screen_Inv_5 = m_Screen.FindAction("Screen_Inv_5", throwIfNotFound: true);
        m_Screen_Screen_Inv_6 = m_Screen.FindAction("Screen_Inv_6", throwIfNotFound: true);
        m_Screen_Screen_Inv_7 = m_Screen.FindAction("Screen_Inv_7", throwIfNotFound: true);
        m_Screen_Screen_Inv_8 = m_Screen.FindAction("Screen_Inv_8", throwIfNotFound: true);
        m_Screen_Screen_Inv_9 = m_Screen.FindAction("Screen_Inv_9", throwIfNotFound: true);
        m_Screen_Screen_Inv_0 = m_Screen.FindAction("Screen_Inv_0", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Game
    private readonly InputActionMap m_Game;
    private IGameActions m_GameActionsCallbackInterface;
    private readonly InputAction m_Game_Move;
    private readonly InputAction m_Game_Jump;
    private readonly InputAction m_Game_Interact;
    private readonly InputAction m_Game_MousePosition;
    private readonly InputAction m_Game_MouseClick;
    public struct GameActions
    {
        private @MainChar m_Wrapper;
        public GameActions(@MainChar wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Game_Move;
        public InputAction @Jump => m_Wrapper.m_Game_Jump;
        public InputAction @Interact => m_Wrapper.m_Game_Interact;
        public InputAction @MousePosition => m_Wrapper.m_Game_MousePosition;
        public InputAction @MouseClick => m_Wrapper.m_Game_MouseClick;
        public InputActionMap Get() { return m_Wrapper.m_Game; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
        public void SetCallbacks(IGameActions instance)
        {
            if (m_Wrapper.m_GameActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_GameActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnJump;
                @Interact.started -= m_Wrapper.m_GameActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnInteract;
                @MousePosition.started -= m_Wrapper.m_GameActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnMousePosition;
                @MouseClick.started -= m_Wrapper.m_GameActionsCallbackInterface.OnMouseClick;
                @MouseClick.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnMouseClick;
                @MouseClick.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnMouseClick;
            }
            m_Wrapper.m_GameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @MouseClick.started += instance.OnMouseClick;
                @MouseClick.performed += instance.OnMouseClick;
                @MouseClick.canceled += instance.OnMouseClick;
            }
        }
    }
    public GameActions @Game => new GameActions(this);

    // Screen
    private readonly InputActionMap m_Screen;
    private IScreenActions m_ScreenActionsCallbackInterface;
    private readonly InputAction m_Screen_Screen_Inv_1;
    private readonly InputAction m_Screen_Screen_Inv_2;
    private readonly InputAction m_Screen_Screen_Inv_3;
    private readonly InputAction m_Screen_Screen_Inv_4;
    private readonly InputAction m_Screen_Screen_Inv_5;
    private readonly InputAction m_Screen_Screen_Inv_6;
    private readonly InputAction m_Screen_Screen_Inv_7;
    private readonly InputAction m_Screen_Screen_Inv_8;
    private readonly InputAction m_Screen_Screen_Inv_9;
    private readonly InputAction m_Screen_Screen_Inv_0;
    public struct ScreenActions
    {
        private @MainChar m_Wrapper;
        public ScreenActions(@MainChar wrapper) { m_Wrapper = wrapper; }
        public InputAction @Screen_Inv_1 => m_Wrapper.m_Screen_Screen_Inv_1;
        public InputAction @Screen_Inv_2 => m_Wrapper.m_Screen_Screen_Inv_2;
        public InputAction @Screen_Inv_3 => m_Wrapper.m_Screen_Screen_Inv_3;
        public InputAction @Screen_Inv_4 => m_Wrapper.m_Screen_Screen_Inv_4;
        public InputAction @Screen_Inv_5 => m_Wrapper.m_Screen_Screen_Inv_5;
        public InputAction @Screen_Inv_6 => m_Wrapper.m_Screen_Screen_Inv_6;
        public InputAction @Screen_Inv_7 => m_Wrapper.m_Screen_Screen_Inv_7;
        public InputAction @Screen_Inv_8 => m_Wrapper.m_Screen_Screen_Inv_8;
        public InputAction @Screen_Inv_9 => m_Wrapper.m_Screen_Screen_Inv_9;
        public InputAction @Screen_Inv_0 => m_Wrapper.m_Screen_Screen_Inv_0;
        public InputActionMap Get() { return m_Wrapper.m_Screen; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ScreenActions set) { return set.Get(); }
        public void SetCallbacks(IScreenActions instance)
        {
            if (m_Wrapper.m_ScreenActionsCallbackInterface != null)
            {
                @Screen_Inv_1.started -= m_Wrapper.m_ScreenActionsCallbackInterface.OnScreen_Inv_1;
                @Screen_Inv_1.performed -= m_Wrapper.m_ScreenActionsCallbackInterface.OnScreen_Inv_1;
                @Screen_Inv_1.canceled -= m_Wrapper.m_ScreenActionsCallbackInterface.OnScreen_Inv_1;
                @Screen_Inv_2.started -= m_Wrapper.m_ScreenActionsCallbackInterface.OnScreen_Inv_2;
                @Screen_Inv_2.performed -= m_Wrapper.m_ScreenActionsCallbackInterface.OnScreen_Inv_2;
                @Screen_Inv_2.canceled -= m_Wrapper.m_ScreenActionsCallbackInterface.OnScreen_Inv_2;
                @Screen_Inv_3.started -= m_Wrapper.m_ScreenActionsCallbackInterface.OnScreen_Inv_3;
                @Screen_Inv_3.performed -= m_Wrapper.m_ScreenActionsCallbackInterface.OnScreen_Inv_3;
                @Screen_Inv_3.canceled -= m_Wrapper.m_ScreenActionsCallbackInterface.OnScreen_Inv_3;
                @Screen_Inv_4.started -= m_Wrapper.m_ScreenActionsCallbackInterface.OnScreen_Inv_4;
                @Screen_Inv_4.performed -= m_Wrapper.m_ScreenActionsCallbackInterface.OnScreen_Inv_4;
                @Screen_Inv_4.canceled -= m_Wrapper.m_ScreenActionsCallbackInterface.OnScreen_Inv_4;
                @Screen_Inv_5.started -= m_Wrapper.m_ScreenActionsCallbackInterface.OnScreen_Inv_5;
                @Screen_Inv_5.performed -= m_Wrapper.m_ScreenActionsCallbackInterface.OnScreen_Inv_5;
                @Screen_Inv_5.canceled -= m_Wrapper.m_ScreenActionsCallbackInterface.OnScreen_Inv_5;
                @Screen_Inv_6.started -= m_Wrapper.m_ScreenActionsCallbackInterface.OnScreen_Inv_6;
                @Screen_Inv_6.performed -= m_Wrapper.m_ScreenActionsCallbackInterface.OnScreen_Inv_6;
                @Screen_Inv_6.canceled -= m_Wrapper.m_ScreenActionsCallbackInterface.OnScreen_Inv_6;
                @Screen_Inv_7.started -= m_Wrapper.m_ScreenActionsCallbackInterface.OnScreen_Inv_7;
                @Screen_Inv_7.performed -= m_Wrapper.m_ScreenActionsCallbackInterface.OnScreen_Inv_7;
                @Screen_Inv_7.canceled -= m_Wrapper.m_ScreenActionsCallbackInterface.OnScreen_Inv_7;
                @Screen_Inv_8.started -= m_Wrapper.m_ScreenActionsCallbackInterface.OnScreen_Inv_8;
                @Screen_Inv_8.performed -= m_Wrapper.m_ScreenActionsCallbackInterface.OnScreen_Inv_8;
                @Screen_Inv_8.canceled -= m_Wrapper.m_ScreenActionsCallbackInterface.OnScreen_Inv_8;
                @Screen_Inv_9.started -= m_Wrapper.m_ScreenActionsCallbackInterface.OnScreen_Inv_9;
                @Screen_Inv_9.performed -= m_Wrapper.m_ScreenActionsCallbackInterface.OnScreen_Inv_9;
                @Screen_Inv_9.canceled -= m_Wrapper.m_ScreenActionsCallbackInterface.OnScreen_Inv_9;
                @Screen_Inv_0.started -= m_Wrapper.m_ScreenActionsCallbackInterface.OnScreen_Inv_0;
                @Screen_Inv_0.performed -= m_Wrapper.m_ScreenActionsCallbackInterface.OnScreen_Inv_0;
                @Screen_Inv_0.canceled -= m_Wrapper.m_ScreenActionsCallbackInterface.OnScreen_Inv_0;
            }
            m_Wrapper.m_ScreenActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Screen_Inv_1.started += instance.OnScreen_Inv_1;
                @Screen_Inv_1.performed += instance.OnScreen_Inv_1;
                @Screen_Inv_1.canceled += instance.OnScreen_Inv_1;
                @Screen_Inv_2.started += instance.OnScreen_Inv_2;
                @Screen_Inv_2.performed += instance.OnScreen_Inv_2;
                @Screen_Inv_2.canceled += instance.OnScreen_Inv_2;
                @Screen_Inv_3.started += instance.OnScreen_Inv_3;
                @Screen_Inv_3.performed += instance.OnScreen_Inv_3;
                @Screen_Inv_3.canceled += instance.OnScreen_Inv_3;
                @Screen_Inv_4.started += instance.OnScreen_Inv_4;
                @Screen_Inv_4.performed += instance.OnScreen_Inv_4;
                @Screen_Inv_4.canceled += instance.OnScreen_Inv_4;
                @Screen_Inv_5.started += instance.OnScreen_Inv_5;
                @Screen_Inv_5.performed += instance.OnScreen_Inv_5;
                @Screen_Inv_5.canceled += instance.OnScreen_Inv_5;
                @Screen_Inv_6.started += instance.OnScreen_Inv_6;
                @Screen_Inv_6.performed += instance.OnScreen_Inv_6;
                @Screen_Inv_6.canceled += instance.OnScreen_Inv_6;
                @Screen_Inv_7.started += instance.OnScreen_Inv_7;
                @Screen_Inv_7.performed += instance.OnScreen_Inv_7;
                @Screen_Inv_7.canceled += instance.OnScreen_Inv_7;
                @Screen_Inv_8.started += instance.OnScreen_Inv_8;
                @Screen_Inv_8.performed += instance.OnScreen_Inv_8;
                @Screen_Inv_8.canceled += instance.OnScreen_Inv_8;
                @Screen_Inv_9.started += instance.OnScreen_Inv_9;
                @Screen_Inv_9.performed += instance.OnScreen_Inv_9;
                @Screen_Inv_9.canceled += instance.OnScreen_Inv_9;
                @Screen_Inv_0.started += instance.OnScreen_Inv_0;
                @Screen_Inv_0.performed += instance.OnScreen_Inv_0;
                @Screen_Inv_0.canceled += instance.OnScreen_Inv_0;
            }
        }
    }
    public ScreenActions @Screen => new ScreenActions(this);
    public interface IGameActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnMouseClick(InputAction.CallbackContext context);
    }
    public interface IScreenActions
    {
        void OnScreen_Inv_1(InputAction.CallbackContext context);
        void OnScreen_Inv_2(InputAction.CallbackContext context);
        void OnScreen_Inv_3(InputAction.CallbackContext context);
        void OnScreen_Inv_4(InputAction.CallbackContext context);
        void OnScreen_Inv_5(InputAction.CallbackContext context);
        void OnScreen_Inv_6(InputAction.CallbackContext context);
        void OnScreen_Inv_7(InputAction.CallbackContext context);
        void OnScreen_Inv_8(InputAction.CallbackContext context);
        void OnScreen_Inv_9(InputAction.CallbackContext context);
        void OnScreen_Inv_0(InputAction.CallbackContext context);
    }
}
