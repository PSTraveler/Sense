// GENERATED AUTOMATICALLY FROM 'Assets/Character_Input.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Character_Input : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Character_Input()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Character_Input"",
    ""maps"": [
        {
            ""name"": ""MoveControl"",
            ""id"": ""3328d396-b4ed-4af8-af13-38f4cf664881"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""40cc7a87-c62a-47a9-a18e-f523ae09d0d9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate_Horizontal"",
                    ""type"": ""Value"",
                    ""id"": ""41476869-3278-4aa8-8b27-254aebef5d46"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": ""Scale(factor=0.1)"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate_Vertical"",
                    ""type"": ""Value"",
                    ""id"": ""bc4b16ff-6064-4519-a887-d23194746f7e"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": ""Scale(factor=0.1)"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Value"",
                    ""id"": ""77397c29-a3af-41d4-8235-de20205d4287"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""43ab4873-60e7-4c7e-948f-2fe010df8a17"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""82ce582d-d4cb-4c4f-86d9-f0d3a97386aa"",
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
                    ""id"": ""7f27f64c-8f50-40aa-931a-2e9386265e81"",
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
                    ""id"": ""9638166c-b029-471b-8790-801760fb4c30"",
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
                    ""id"": ""6ecf8eee-5257-4fb7-b7fa-b79f3a8c3a08"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""0a70742c-37da-4d43-b95d-05aba63ed9e3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""255d4cb3-bae4-4d68-8203-380e04e23570"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7417e7e7-8f5d-48e8-8ed9-67d67aaefc3a"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bf9b96dc-e127-456d-9a55-487fe1f6c881"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b8478d82-f755-410a-96cf-aa1f9de1c0cb"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""eafa3baa-e6dc-470b-ae2c-21077d91f885"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate_Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""90358006-7658-4deb-b1c8-a5e58ff5127c"",
                    ""path"": ""<Gamepad>/rightStick/y"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=0.3)"",
                    ""groups"": """",
                    ""action"": ""Rotate_Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4c6fa3f-8515-4359-823e-32aceff5a12b"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate_Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2aa7afa8-0ff6-4403-bc24-b20e726e63ec"",
                    ""path"": ""<Gamepad>/rightStick/x"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=0.3)"",
                    ""groups"": """",
                    ""action"": ""Rotate_Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe308da4-0deb-4675-a554-d11cb4b8a2af"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de64bd46-f291-40dc-a8d8-87ba14176e50"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""ActionControl"",
            ""id"": ""ec8e8151-5c4b-4bce-9fb4-6b8b45d2e67e"",
            ""actions"": [
                {
                    ""name"": ""Touch"",
                    ""type"": ""Button"",
                    ""id"": ""f6c15941-0d09-4cc7-9383-3f835e870f45"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Step"",
                    ""type"": ""Button"",
                    ""id"": ""fc0db933-d9d5-431b-9135-bd7f6a8194f4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Use"",
                    ""type"": ""Button"",
                    ""id"": ""53fe86da-9701-40cf-bc4e-95c770acc5e7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1a915249-4c77-4e49-bd70-e5c9286b39bb"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f876b4a-508d-4791-bb2c-ef6d6a889750"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""08e64aad-bb04-4b77-acc2-751ad95c3bf9"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Step"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""184daf8b-27ea-4784-9390-85c4cfcda6db"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Step"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57ae882b-428a-44c3-842e-7f026fbf8253"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62eefecc-4b8e-4688-b82b-ebc87a7d83eb"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""VoiceAction"",
            ""id"": ""5f928498-22ce-44e2-92ff-ea8021b2cd9a"",
            ""actions"": [
                {
                    ""name"": ""Accept"",
                    ""type"": ""Button"",
                    ""id"": ""f1592028-cb43-4abc-92a6-faa88927f1ee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1201fd3a-8f9a-4006-9175-e8af1fe1f3bf"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accept"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96f460da-d2f3-4b04-81db-673106f2cd69"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accept"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PauseGame"",
            ""id"": ""50d72e46-5577-4c7c-9f4a-c0465e14e2f7"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""5ee977fc-7b9e-4e5f-83ff-ad82c46aa9e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""35796422-3844-41ad-9068-58ff7b95fceb"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5fefecdc-ff61-4a20-8401-220328d16aaa"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""SenseChange"",
            ""id"": ""c9cffe26-a261-4e4b-8afd-0576f62861cf"",
            ""actions"": [
                {
                    ""name"": ""Eye"",
                    ""type"": ""Button"",
                    ""id"": ""16a9da06-4405-46e3-8a11-cd63e25dc04d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ear"",
                    ""type"": ""Button"",
                    ""id"": ""2998f709-4d61-405a-8eea-452152fa4fba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Hand"",
                    ""type"": ""Button"",
                    ""id"": ""414eb5b4-0a35-419a-8890-e52b97cef36b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""be5843f2-f9bf-4ac2-92ca-e8d943124ef6"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Eye"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""33356ba8-ff61-4c46-a33f-c8a9cfb796e7"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ear"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4276686-3099-4985-9d5b-57cabd59a98e"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hand"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MoveControl
        m_MoveControl = asset.FindActionMap("MoveControl", throwIfNotFound: true);
        m_MoveControl_Move = m_MoveControl.FindAction("Move", throwIfNotFound: true);
        m_MoveControl_Rotate_Horizontal = m_MoveControl.FindAction("Rotate_Horizontal", throwIfNotFound: true);
        m_MoveControl_Rotate_Vertical = m_MoveControl.FindAction("Rotate_Vertical", throwIfNotFound: true);
        m_MoveControl_Run = m_MoveControl.FindAction("Run", throwIfNotFound: true);
        // ActionControl
        m_ActionControl = asset.FindActionMap("ActionControl", throwIfNotFound: true);
        m_ActionControl_Touch = m_ActionControl.FindAction("Touch", throwIfNotFound: true);
        m_ActionControl_Step = m_ActionControl.FindAction("Step", throwIfNotFound: true);
        m_ActionControl_Use = m_ActionControl.FindAction("Use", throwIfNotFound: true);
        // VoiceAction
        m_VoiceAction = asset.FindActionMap("VoiceAction", throwIfNotFound: true);
        m_VoiceAction_Accept = m_VoiceAction.FindAction("Accept", throwIfNotFound: true);
        // PauseGame
        m_PauseGame = asset.FindActionMap("PauseGame", throwIfNotFound: true);
        m_PauseGame_Pause = m_PauseGame.FindAction("Pause", throwIfNotFound: true);
        // SenseChange
        m_SenseChange = asset.FindActionMap("SenseChange", throwIfNotFound: true);
        m_SenseChange_Eye = m_SenseChange.FindAction("Eye", throwIfNotFound: true);
        m_SenseChange_Ear = m_SenseChange.FindAction("Ear", throwIfNotFound: true);
        m_SenseChange_Hand = m_SenseChange.FindAction("Hand", throwIfNotFound: true);
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

    // MoveControl
    private readonly InputActionMap m_MoveControl;
    private IMoveControlActions m_MoveControlActionsCallbackInterface;
    private readonly InputAction m_MoveControl_Move;
    private readonly InputAction m_MoveControl_Rotate_Horizontal;
    private readonly InputAction m_MoveControl_Rotate_Vertical;
    private readonly InputAction m_MoveControl_Run;
    public struct MoveControlActions
    {
        private @Character_Input m_Wrapper;
        public MoveControlActions(@Character_Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_MoveControl_Move;
        public InputAction @Rotate_Horizontal => m_Wrapper.m_MoveControl_Rotate_Horizontal;
        public InputAction @Rotate_Vertical => m_Wrapper.m_MoveControl_Rotate_Vertical;
        public InputAction @Run => m_Wrapper.m_MoveControl_Run;
        public InputActionMap Get() { return m_Wrapper.m_MoveControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MoveControlActions set) { return set.Get(); }
        public void SetCallbacks(IMoveControlActions instance)
        {
            if (m_Wrapper.m_MoveControlActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_MoveControlActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MoveControlActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MoveControlActionsCallbackInterface.OnMove;
                @Rotate_Horizontal.started -= m_Wrapper.m_MoveControlActionsCallbackInterface.OnRotate_Horizontal;
                @Rotate_Horizontal.performed -= m_Wrapper.m_MoveControlActionsCallbackInterface.OnRotate_Horizontal;
                @Rotate_Horizontal.canceled -= m_Wrapper.m_MoveControlActionsCallbackInterface.OnRotate_Horizontal;
                @Rotate_Vertical.started -= m_Wrapper.m_MoveControlActionsCallbackInterface.OnRotate_Vertical;
                @Rotate_Vertical.performed -= m_Wrapper.m_MoveControlActionsCallbackInterface.OnRotate_Vertical;
                @Rotate_Vertical.canceled -= m_Wrapper.m_MoveControlActionsCallbackInterface.OnRotate_Vertical;
                @Run.started -= m_Wrapper.m_MoveControlActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_MoveControlActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_MoveControlActionsCallbackInterface.OnRun;
            }
            m_Wrapper.m_MoveControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Rotate_Horizontal.started += instance.OnRotate_Horizontal;
                @Rotate_Horizontal.performed += instance.OnRotate_Horizontal;
                @Rotate_Horizontal.canceled += instance.OnRotate_Horizontal;
                @Rotate_Vertical.started += instance.OnRotate_Vertical;
                @Rotate_Vertical.performed += instance.OnRotate_Vertical;
                @Rotate_Vertical.canceled += instance.OnRotate_Vertical;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
            }
        }
    }
    public MoveControlActions @MoveControl => new MoveControlActions(this);

    // ActionControl
    private readonly InputActionMap m_ActionControl;
    private IActionControlActions m_ActionControlActionsCallbackInterface;
    private readonly InputAction m_ActionControl_Touch;
    private readonly InputAction m_ActionControl_Step;
    private readonly InputAction m_ActionControl_Use;
    public struct ActionControlActions
    {
        private @Character_Input m_Wrapper;
        public ActionControlActions(@Character_Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Touch => m_Wrapper.m_ActionControl_Touch;
        public InputAction @Step => m_Wrapper.m_ActionControl_Step;
        public InputAction @Use => m_Wrapper.m_ActionControl_Use;
        public InputActionMap Get() { return m_Wrapper.m_ActionControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionControlActions set) { return set.Get(); }
        public void SetCallbacks(IActionControlActions instance)
        {
            if (m_Wrapper.m_ActionControlActionsCallbackInterface != null)
            {
                @Touch.started -= m_Wrapper.m_ActionControlActionsCallbackInterface.OnTouch;
                @Touch.performed -= m_Wrapper.m_ActionControlActionsCallbackInterface.OnTouch;
                @Touch.canceled -= m_Wrapper.m_ActionControlActionsCallbackInterface.OnTouch;
                @Step.started -= m_Wrapper.m_ActionControlActionsCallbackInterface.OnStep;
                @Step.performed -= m_Wrapper.m_ActionControlActionsCallbackInterface.OnStep;
                @Step.canceled -= m_Wrapper.m_ActionControlActionsCallbackInterface.OnStep;
                @Use.started -= m_Wrapper.m_ActionControlActionsCallbackInterface.OnUse;
                @Use.performed -= m_Wrapper.m_ActionControlActionsCallbackInterface.OnUse;
                @Use.canceled -= m_Wrapper.m_ActionControlActionsCallbackInterface.OnUse;
            }
            m_Wrapper.m_ActionControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Touch.started += instance.OnTouch;
                @Touch.performed += instance.OnTouch;
                @Touch.canceled += instance.OnTouch;
                @Step.started += instance.OnStep;
                @Step.performed += instance.OnStep;
                @Step.canceled += instance.OnStep;
                @Use.started += instance.OnUse;
                @Use.performed += instance.OnUse;
                @Use.canceled += instance.OnUse;
            }
        }
    }
    public ActionControlActions @ActionControl => new ActionControlActions(this);

    // VoiceAction
    private readonly InputActionMap m_VoiceAction;
    private IVoiceActionActions m_VoiceActionActionsCallbackInterface;
    private readonly InputAction m_VoiceAction_Accept;
    public struct VoiceActionActions
    {
        private @Character_Input m_Wrapper;
        public VoiceActionActions(@Character_Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Accept => m_Wrapper.m_VoiceAction_Accept;
        public InputActionMap Get() { return m_Wrapper.m_VoiceAction; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(VoiceActionActions set) { return set.Get(); }
        public void SetCallbacks(IVoiceActionActions instance)
        {
            if (m_Wrapper.m_VoiceActionActionsCallbackInterface != null)
            {
                @Accept.started -= m_Wrapper.m_VoiceActionActionsCallbackInterface.OnAccept;
                @Accept.performed -= m_Wrapper.m_VoiceActionActionsCallbackInterface.OnAccept;
                @Accept.canceled -= m_Wrapper.m_VoiceActionActionsCallbackInterface.OnAccept;
            }
            m_Wrapper.m_VoiceActionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Accept.started += instance.OnAccept;
                @Accept.performed += instance.OnAccept;
                @Accept.canceled += instance.OnAccept;
            }
        }
    }
    public VoiceActionActions @VoiceAction => new VoiceActionActions(this);

    // PauseGame
    private readonly InputActionMap m_PauseGame;
    private IPauseGameActions m_PauseGameActionsCallbackInterface;
    private readonly InputAction m_PauseGame_Pause;
    public struct PauseGameActions
    {
        private @Character_Input m_Wrapper;
        public PauseGameActions(@Character_Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_PauseGame_Pause;
        public InputActionMap Get() { return m_Wrapper.m_PauseGame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PauseGameActions set) { return set.Get(); }
        public void SetCallbacks(IPauseGameActions instance)
        {
            if (m_Wrapper.m_PauseGameActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_PauseGameActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PauseGameActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PauseGameActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_PauseGameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public PauseGameActions @PauseGame => new PauseGameActions(this);

    // SenseChange
    private readonly InputActionMap m_SenseChange;
    private ISenseChangeActions m_SenseChangeActionsCallbackInterface;
    private readonly InputAction m_SenseChange_Eye;
    private readonly InputAction m_SenseChange_Ear;
    private readonly InputAction m_SenseChange_Hand;
    public struct SenseChangeActions
    {
        private @Character_Input m_Wrapper;
        public SenseChangeActions(@Character_Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Eye => m_Wrapper.m_SenseChange_Eye;
        public InputAction @Ear => m_Wrapper.m_SenseChange_Ear;
        public InputAction @Hand => m_Wrapper.m_SenseChange_Hand;
        public InputActionMap Get() { return m_Wrapper.m_SenseChange; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SenseChangeActions set) { return set.Get(); }
        public void SetCallbacks(ISenseChangeActions instance)
        {
            if (m_Wrapper.m_SenseChangeActionsCallbackInterface != null)
            {
                @Eye.started -= m_Wrapper.m_SenseChangeActionsCallbackInterface.OnEye;
                @Eye.performed -= m_Wrapper.m_SenseChangeActionsCallbackInterface.OnEye;
                @Eye.canceled -= m_Wrapper.m_SenseChangeActionsCallbackInterface.OnEye;
                @Ear.started -= m_Wrapper.m_SenseChangeActionsCallbackInterface.OnEar;
                @Ear.performed -= m_Wrapper.m_SenseChangeActionsCallbackInterface.OnEar;
                @Ear.canceled -= m_Wrapper.m_SenseChangeActionsCallbackInterface.OnEar;
                @Hand.started -= m_Wrapper.m_SenseChangeActionsCallbackInterface.OnHand;
                @Hand.performed -= m_Wrapper.m_SenseChangeActionsCallbackInterface.OnHand;
                @Hand.canceled -= m_Wrapper.m_SenseChangeActionsCallbackInterface.OnHand;
            }
            m_Wrapper.m_SenseChangeActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Eye.started += instance.OnEye;
                @Eye.performed += instance.OnEye;
                @Eye.canceled += instance.OnEye;
                @Ear.started += instance.OnEar;
                @Ear.performed += instance.OnEar;
                @Ear.canceled += instance.OnEar;
                @Hand.started += instance.OnHand;
                @Hand.performed += instance.OnHand;
                @Hand.canceled += instance.OnHand;
            }
        }
    }
    public SenseChangeActions @SenseChange => new SenseChangeActions(this);
    public interface IMoveControlActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotate_Horizontal(InputAction.CallbackContext context);
        void OnRotate_Vertical(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
    }
    public interface IActionControlActions
    {
        void OnTouch(InputAction.CallbackContext context);
        void OnStep(InputAction.CallbackContext context);
        void OnUse(InputAction.CallbackContext context);
    }
    public interface IVoiceActionActions
    {
        void OnAccept(InputAction.CallbackContext context);
    }
    public interface IPauseGameActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
    public interface ISenseChangeActions
    {
        void OnEye(InputAction.CallbackContext context);
        void OnEar(InputAction.CallbackContext context);
        void OnHand(InputAction.CallbackContext context);
    }
}
