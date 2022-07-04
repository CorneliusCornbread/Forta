using Forta.Tools;
using UnityEngine;
using UnityEngine.InputSystem;
using Ctx = UnityEngine.InputSystem.InputAction.CallbackContext;

namespace Forta
{
	[CreateAssetMenu(menuName = "Forta/Singleton/InputManager")]
	public class InputManager : SingletonScriptableObject<InputManager>
	{
		#region Fields/Properties
		public ControlScheme Controls { get; private set; }
		
		/// <summary>
		/// Movement input without smoothing applied, depends upon the Player input map
		/// </summary>
		public Vector2 MoveRaw { get; private set; }

		private Vector2 _move;
        
		/// <summary>
		/// Movement input with smoothing applied, depends upon the Player input map
		/// </summary>
		public Vector2 Move
		{
			get
			{
				//UpdateStaleCachedFields();
				return _move;
			}

			private set => _move = value;
		}
		
		private Vector2 _pointerScreenPos;
        
		/// <summary>
		/// The position of the mouse in screen space, use this for ScreenSpaceOverlay UI elements
		/// </summary>
		public Vector2 PointerScreenPos
		{
			get
			{
				//UpdateStaleCachedFields();
				return _pointerScreenPos;
			}

			private set => _pointerScreenPos = value;
		}

		private Vector2 _pointerWorldPos;
        
		/// <summary>
		/// The position of the mouse in world space
		/// </summary>
		public Vector2 PointerWorldPos
		{
			get
			{
				//UpdateStaleCachedFields();
				return _pointerWorldPos;
			}

			private set => _pointerWorldPos = value;
		}
		
		private Camera _mainCam;
		private Camera MainCam
		{
			get
			{
				if (_mainCam == null)
				{
					_mainCam = Camera.main;
				}

				return _mainCam;
			}
		}
		
		/// <summary>
		/// The "Velocity" on our input per se. It's a field because it's values are carried over multiple frames.
		/// </summary>
		private Vector2 _smooth;
		#endregion

		#region Constant Variables
		private const float SmoothSensitivity = 8f;
		private const float Dead = 0.001f;
		#endregion
		
		#region Unity Functions
		protected override void OnLoad()
		{
			Controls = new ControlScheme();

			Controls.Player.Move.performed += MovePerformed;
			Controls.Player.Move.canceled += MoveCanceled;

			MonoBehaviourCallbackChannel.Instance.OnUpdate.AddListener(OnUpdate);
            
#if UNITY_STANDALONE //Only compile for desktop platforms
			//Initialize mouse position, we do this so the pointer doesn't just default to (0, 0) until the mouse is moved
			PointerScreenPos = Mouse.current.position.ReadValue();
			PointerWorldPos = MainCam.ScreenToWorldPoint(PointerScreenPos);
#endif
		}

		
		#endregion

		#region Private Functions
		private void OnUpdate()
		{
			if (Application.isFocused)
			{
				//Update the pointer position every frame
				PointerScreenPos = Controls.Player.Pointer.ReadValue<Vector2>();
				PointerWorldPos = MainCam.ScreenToWorldPoint(PointerScreenPos);
			}
			
			Move = CalculateSmoothMove();
		}

		private Vector2 CalculateSmoothMove()
		{
			float targetX = MoveRaw.x;
			_smooth.x = Mathf.MoveTowards(_smooth.x, targetX, SmoothSensitivity * Time.deltaTime);
			_smooth.x = (Mathf.Abs(_smooth.x) < Dead) ? 0f : _smooth.x;

			float targetY = MoveRaw.y;
			_smooth.y = Mathf.MoveTowards(_smooth.y, targetY, SmoothSensitivity * Time.deltaTime);
			_smooth.y = (Mathf.Abs(_smooth.y) < Dead) ? 0f : _smooth.y;


			if (targetX > .01f)
			{
				_smooth.x = Mathf.Clamp(_smooth.x, 0, 1);
			}

			else if (targetX < -.01f)
			{
				_smooth.x = Mathf.Clamp(_smooth.x, -1, 0);
			}

			if (targetY > .01f)
			{
				_smooth.y = Mathf.Clamp(_smooth.y, 0, 1);
			}

			else if (targetY < -.01f)
			{
				_smooth.y = Mathf.Clamp(_smooth.y, -1, 0);
			}

			return _smooth;
		}

		private void MovePerformed(Ctx obj)
		{
			MoveRaw = obj.ReadValue<Vector2>().normalized;
		}

		private void MoveCanceled(Ctx obj)
		{
			MoveRaw = Vector2.zero;
		}
		#endregion
	}
}