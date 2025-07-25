/*
 * The MIT License (MIT)
 *
 * Copyright (c) 2013 Alistair Leslie-Hughes
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy of
 * this software and associated documentation files (the "Software"), to deal in
 * the Software without restriction, including without limitation the rights to
 * use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
 * the Software, and to permit persons to whom the Software is furnished to do so,
 * subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
 * FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
 * COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
 * IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
 * CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;

namespace Microsoft.DirectX.DirectInput
{
	public sealed class Device : MarshalByRefObject, IDisposable
	{
		private IntPtr _device;

		[DllImport("monodx.dll", CallingConvention=CallingConvention.Cdecl)]
		internal static extern void dinput_device_Release(IntPtr device);

		[DllImport("monodx.dll", CallingConvention=CallingConvention.Cdecl)]
		internal static extern int dinput_device_Acquire(IntPtr device);

		[DllImport("monodx.dll", CallingConvention=CallingConvention.Cdecl)]
		internal static extern int dinput_device_GetCapabilities(IntPtr device, out DeviceCaps caps);

		[DllImport("monodx.dll", CallingConvention=CallingConvention.Cdecl)]
		internal static extern int dinput_device_GetDeviceInfo(IntPtr device, out DIDEVICEINSTANCE info);

		[DllImport("monodx.dll", CallingConvention=CallingConvention.Cdecl)]
		internal static extern int dinput_device_GetDeviceState(IntPtr device, int buffer_size, [Out] byte[] state);

		[DllImport("monodx.dll", CallingConvention=CallingConvention.Cdecl)]
		internal static extern int dinput_device_GetDeviceState(IntPtr device, int buffer_size, out DIJOYSTATE2 state);

		[DllImport("monodx.dll", CallingConvention=CallingConvention.Cdecl)]
		internal static extern int dinput_device_Poll(IntPtr device);

		[DllImport("monodx.dll", CallingConvention=CallingConvention.Cdecl)]
		internal static extern int dinput_device_RunControlPanel(IntPtr device, IntPtr hwnd);

		[DllImport("monodx.dll", CallingConvention=CallingConvention.Cdecl)]
		internal static extern int dinput_device_SetCooperativeLevel(IntPtr device, IntPtr hwnd, int flags);

		[DllImport("monodx.dll", CallingConvention=CallingConvention.Cdecl)]
		internal static extern int dinput_device_SetDataFormatPredefined(IntPtr device, int df);

		[DllImport("monodx.dll", CallingConvention=CallingConvention.Cdecl)]
		internal static extern int dinput_device_Unacquire(IntPtr device);

		private void CheckDisposed()
		{
			if (_device == IntPtr.Zero)
			{
				throw new ObjectDisposedException("Microsoft.DirectX.DirectInput.Device");
			}
		}

		public DeviceImageInformationHeader ImageInformation
		{
			get
			{
				throw new NotImplementedException ();
			}
		}
		public EffectList CreatedEffects
		{
			get
			{
				throw new NotImplementedException ();
			}
		}
		public ForceFeedbackStates ForceFeedbackState
		{
			get
			{
				throw new NotImplementedException ();
			}
		}
		public DeviceInstance DeviceInformation
		{
			get
			{
				CheckDisposed();
				Marshal.ThrowExceptionForHR(dinput_device_GetDeviceInfo(_device, out var info));
				return new DeviceInstance(info);
			}
		}
		public JoystickState CurrentJoystickState
		{
			get
			{
				Marshal.ThrowExceptionForHR(dinput_device_GetDeviceState(_device, Marshal.SizeOf<DIJOYSTATE2>(), out DIJOYSTATE2 state));
				return new JoystickState(state);
			}
		}
		public MouseState CurrentMouseState
		{
			get
			{
				throw new NotImplementedException ();
			}
		}
		public DeviceObjectList Objects
		{
			get
			{
				throw new NotImplementedException ();
			}
		}
		public DeviceProperties Properties
		{
			get
			{
				throw new NotImplementedException ();
			}
		}
		public DeviceCaps Caps
		{
			get
			{
				CheckDisposed();
				Marshal.ThrowExceptionForHR(dinput_device_GetCapabilities(_device, out DeviceCaps caps));
				return caps;
			}
		}

		public Device(Guid deviceGuid)
		{
			_device = Manager.CreateDevice(deviceGuid);
		}

		~Device()
		{
			Dispose();
		}

		public override bool Equals(object compare)
		{
			var right = compare as Device;
			if ((Object)right == null)
				return false;

			return _device == right._device;
		}

		public static bool operator ==(Device left, Device right)
		{
			if ((Object)left == null || (Object)right == null)
			{
				return ((Object)left == (Object)right);
			}

			return left._device == right._device;
		}

		public static bool operator !=(Device left, Device right)
		{
			return ! (left == right);
		}

		public override int GetHashCode()
		{
			return  _device.GetHashCode();
		}
		public void Dispose()
		{
			if (_device != IntPtr.Zero)
			{
				dinput_device_Release(_device);
				_device = IntPtr.Zero;
			}
		}
		public DeviceObjectList GetObjects(DeviceObjectTypeFlags flags)
		{
			throw new NotImplementedException ();
		}
		public void Acquire()
		{
			CheckDisposed();
			Marshal.ThrowExceptionForHR(dinput_device_Acquire(_device));
		}
		public void Unacquire()
		{
			CheckDisposed();
			Marshal.ThrowExceptionForHR(dinput_device_Unacquire(_device));
		}
		public object GetDeviceState(Type customFormatType)
		{
			throw new NotImplementedException ();
		}
		public KeyboardState GetCurrentKeyboardState()
		{
			byte[] state = new byte[256];
			Marshal.ThrowExceptionForHR(dinput_device_GetDeviceState(_device, 256, state));
			return new KeyboardState(state);
		}
		public Key[] GetPressedKeys()
		{
			throw new NotImplementedException ();
		}
		public BufferedDataCollection GetBufferedData()
		{
			throw new NotImplementedException ();
		}
		public void SetDataFormat(DeviceDataFormat df)
		{
			CheckDisposed();
			Marshal.ThrowExceptionForHR(dinput_device_SetDataFormatPredefined(_device, (int)df));
		}
		public void SetDataFormat(DataFormat df)
		{
			throw new NotImplementedException ();
		}
		public void SetEventNotification(WaitHandle deviceEvent)
		{
			throw new NotImplementedException ();
		}

		public void SetCooperativeLevel(Control parent, CooperativeLevelFlags flags)
		{
			SetCooperativeLevel(parent.Handle, flags);
		}
		public void SetCooperativeLevel(IntPtr hwnd, CooperativeLevelFlags flags)
		{
			CheckDisposed();
			Marshal.ThrowExceptionForHR(dinput_device_SetCooperativeLevel(_device, hwnd, (int)flags));
		}
		public DeviceObjectInstance GetObjectInformation(int obj, ParameterHow how)
		{
			throw new NotImplementedException ();
		}
		public void RunControlPanel()
		{
			RunControlPanel(IntPtr.Zero);
		}
		public void RunControlPanel(Control owner)
		{
			RunControlPanel(owner.Handle);
		}
		private void RunControlPanel(IntPtr hwnd)
		{
			CheckDisposed();
			Marshal.ThrowExceptionForHR(dinput_device_RunControlPanel(_device, hwnd));
		}

		public EffectList GetEffects(string fileName, FileEffectsFlags flags)
		{
			throw new NotImplementedException ();
		}
		public EffectList GetEffects(EffectType effType)
		{
			throw new NotImplementedException ();
		}
		public EffectInformation GetEffectInformation(Guid rguid)
		{
			throw new NotImplementedException ();
		}
		public void SendForceFeedbackCommand(ForceFeedbackCommand command)
		{
			throw new NotImplementedException ();
		}
		public byte[] SendHardwareCommand(int command, byte[] data)
		{
			throw new NotImplementedException ();
		}
		public void Poll()
		{
			CheckDisposed();
			Marshal.ThrowExceptionForHR(dinput_device_Poll(_device));
		}
		public void WriteEffect(Stream stream, FileEffect[] fileEffect)
		{
			throw new NotImplementedException ();
		}
		public void WriteEffect(Stream stream, FileEffect[] fileEffect, FileEffectsFlags flags)
		{
			throw new NotImplementedException ();
		}
		public void WriteEffect(string fileName, FileEffect[] fileEffect)
		{
			throw new NotImplementedException ();
		}
		public void WriteEffect(string fileName, FileEffect[] fileEffect, FileEffectsFlags flags)
		{
			throw new NotImplementedException ();
		}

		public void BuildActionMap(ActionFormat af, ActionMapControl flags)
		{
			throw new NotImplementedException ();
		}
		public void BuildActionMap(ActionFormat af, string userName, ActionMapControl flags)
		{
			throw new NotImplementedException ();
		}

		public SetActionMapReturnCodes SetActionMap(ActionFormat af, ApplyActionMap flags)
		{
			throw new NotImplementedException ();
		}
		public SetActionMapReturnCodes SetActionMap(ActionFormat af, string userName, ApplyActionMap flags)
		{
			throw new NotImplementedException ();
		}
	}
}

