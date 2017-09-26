using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace Lumix
{
	public class Camera : NativeComponent
	{
		int componentId_;
		IntPtr scene_;

		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		extern static string getCameraSlot(IntPtr scene, int cmp);

		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		extern static void setCameraSlot(IntPtr scene, int cmp, string value);

		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		extern static float getCameraOrthoSize(IntPtr scene, int cmp);

		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		extern static void setCameraOrthoSize(IntPtr scene, int cmp, float value);

		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		extern static bool isCameraOrtho(IntPtr scene, int cmp);

		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		extern static void setCameraOrtho(IntPtr scene, int cmp, bool value);

		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		extern static float getCameraNearPlane(IntPtr scene, int cmp);

		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		extern static void setCameraNearPlane(IntPtr scene, int cmp, float value);

		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		extern static float getCameraFarPlane(IntPtr scene, int cmp);

		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		extern static void setCameraFarPlane(IntPtr scene, int cmp, float value);


		public static string GetCmpType{ get { return "camera"; } }


		public Camera(Entity _entity, int _componenId)
		{
			entity_ = _entity;
			componentId_ = _componenId;
			scene_ = getScene(entity_.instance_, "camera");
		}

		public Camera(Entity _entity)
		{
			entity_ = _entity;
			componentId_ = create(entity_.instance_, entity_.entity_Id_, "camera");
			if (componentId_ < 0) throw new Exception("Failed to create component");
			scene_ = getScene(entity_.instance_, "camera");
		}

		/// <summary>
		/// Gets or sets the Slot
		/// </summary>
		public string Slot
		{
			get { return getCameraSlot(scene_, componentId_); }
			set { setCameraSlot(scene_, componentId_, value); }
		}

		/// <summary>
		/// Gets or sets the OrthographicSize
		/// </summary>
		public float OrthographicSize
		{
			get { return getCameraOrthoSize(scene_, componentId_); }
			set { setCameraOrthoSize(scene_, componentId_, value); }
		}

		/// <summary>
		/// Gets or sets the Orthographic
		/// </summary>
		public bool IsOrthographic
		{
			get { return isCameraOrtho(scene_, componentId_); }
			set { setCameraOrtho(scene_, componentId_, value); }
		}

		/// <summary>
		/// Gets or sets the Near
		/// </summary>
		public float Near
		{
			get { return getCameraNearPlane(scene_, componentId_); }
			set { setCameraNearPlane(scene_, componentId_, value); }
		}

		/// <summary>
		/// Gets or sets the Far
		/// </summary>
		public float Far
		{
			get { return getCameraFarPlane(scene_, componentId_); }
			set { setCameraFarPlane(scene_, componentId_, value); }
		}

	}//end class

}//end namespace