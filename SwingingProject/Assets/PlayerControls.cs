// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""8f0e3679-949e-4923-9a2c-5539de93288b"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""c888a2f4-5d74-43ee-8da3-471a14064348"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""68327a67-63d3-436a-9c62-aead67b08dd3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""7a80e61d-51c2-4e2f-8ea6-6ae3402b0cfc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FireHook"",
                    ""type"": ""Button"",
                    ""id"": ""7ad9b479-e005-470a-ab62-74ae11f16cec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""GroundPound"",
                    ""type"": ""Button"",
                    ""id"": ""e479a381-402d-4092-899c-5384bb442e8b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TestSpawn"",
                    ""type"": ""Button"",
                    ""id"": ""cc7b0aba-daef-41a9-8441-a788a3bdab3f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0605b292-691d-49e3-ba72-70039ba71892"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bfd9a4fd-1b64-4e49-b657-eec0c314bc12"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e3d0cd71-5ff1-42db-8751-cbb7a0deac96"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""65be42a8-e7f8-45ec-967b-7d6f71688df1"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireHook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e66c9a89-8d13-4fe0-b9ae-f2d24c7dcfd7"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GroundPound"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8e211edf-b00a-4c9b-8386-e176365ea5ab"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TestSpawn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Move = m_Movement.FindAction("Move", throwIfNotFound: true);
        m_Movement_Aim = m_Movement.FindAction("Aim", throwIfNotFound: true);
        m_Movement_Jump = m_Movement.FindAction("Jump", throwIfNotFound: true);
        m_Movement_FireHook = m_Movement.FindAction("FireHook", throwIfNotFound: true);
        m_Movement_GroundPound = m_Movement.FindAction("GroundPound", throwIfNotFound: true);
        m_Movement_TestSpawn = m_Movement.FindAction("TestSpawn", throwIfNotFound: true);
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

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_Move;
    private readonly InputAction m_Movement_Aim;
    private readonly InputAction m_Movement_Jump;
    private readonly InputAction m_Movement_FireHook;
    private readonly InputAction m_Movement_GroundPound;
    private readonly InputAction m_Movement_TestSpawn;
    public struct MovementActions
    {
        private @PlayerControls m_Wrapper;
        public MovementActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Movement_Move;
        public InputAction @Aim => m_Wrapper.m_Movement_Aim;
        public InputAction @Jump => m_Wrapper.m_Movement_Jump;
        public InputAction @FireHook => m_Wrapper.m_Movement_FireHook;
        public InputAction @GroundPound => m_Wrapper.m_Movement_GroundPound;
        public InputAction @TestSpawn => m_Wrapper.m_Movement_TestSpawn;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @Aim.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnAim;
                @Jump.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                @FireHook.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnFireHook;
                @FireHook.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnFireHook;
                @FireHook.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnFireHook;
                @GroundPound.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnGroundPound;
                @GroundPound.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnGroundPound;
                @GroundPound.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnGroundPound;
                @TestSpawn.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnTestSpawn;
                @TestSpawn.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnTestSpawn;
                @TestSpawn.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnTestSpawn;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @FireHook.started += instance.OnFireHook;
                @FireHook.performed += instance.OnFireHook;
                @FireHook.canceled += instance.OnFireHook;
                @GroundPound.started += instance.OnGroundPound;
                @GroundPound.performed += instance.OnGroundPound;
                @GroundPound.canceled += instance.OnGroundPound;
                @TestSpawn.started += instance.OnTestSpawn;
                @TestSpawn.performed += instance.OnTestSpawn;
                @TestSpawn.canceled += instance.OnTestSpawn;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);
    public interface IMovementActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnFireHook(InputAction.CallbackContext context);
        void OnGroundPound(InputAction.CallbackContext context);
        void OnTestSpawn(InputAction.CallbackContext context);
    }
}
