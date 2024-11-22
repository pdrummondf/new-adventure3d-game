// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/Inputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Inputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Inputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Inputs"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""3141f542-de24-4cf3-ac89-199b34bbe7c9"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""506dfcb1-4536-47e1-bf29-a078cd15597e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Weapon1"",
                    ""type"": ""Button"",
                    ""id"": ""56e0c033-aa01-4d26-b395-349cc72b0e3e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Weapon2"",
                    ""type"": ""Button"",
                    ""id"": ""018111e2-fe18-486d-a0c0-082c038f1665"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c5a479b2-5073-478e-b0e7-6f08f60271be"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a03aca68-95cc-42c4-9152-7a18ec155f9d"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Weapon1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cdd6641b-5fde-4f2b-9dab-17f65beaa708"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Weapon2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Shoot = m_Gameplay.FindAction("Shoot", throwIfNotFound: true);
        m_Gameplay_Weapon1 = m_Gameplay.FindAction("Weapon1", throwIfNotFound: true);
        m_Gameplay_Weapon2 = m_Gameplay.FindAction("Weapon2", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Shoot;
    private readonly InputAction m_Gameplay_Weapon1;
    private readonly InputAction m_Gameplay_Weapon2;
    public struct GameplayActions
    {
        private @Inputs m_Wrapper;
        public GameplayActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_Gameplay_Shoot;
        public InputAction @Weapon1 => m_Wrapper.m_Gameplay_Weapon1;
        public InputAction @Weapon2 => m_Wrapper.m_Gameplay_Weapon2;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Shoot.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @Weapon1.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWeapon1;
                @Weapon1.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWeapon1;
                @Weapon1.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWeapon1;
                @Weapon2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWeapon2;
                @Weapon2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWeapon2;
                @Weapon2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnWeapon2;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Weapon1.started += instance.OnWeapon1;
                @Weapon1.performed += instance.OnWeapon1;
                @Weapon1.canceled += instance.OnWeapon1;
                @Weapon2.started += instance.OnWeapon2;
                @Weapon2.performed += instance.OnWeapon2;
                @Weapon2.canceled += instance.OnWeapon2;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnShoot(InputAction.CallbackContext context);
        void OnWeapon1(InputAction.CallbackContext context);
        void OnWeapon2(InputAction.CallbackContext context);
    }
}
