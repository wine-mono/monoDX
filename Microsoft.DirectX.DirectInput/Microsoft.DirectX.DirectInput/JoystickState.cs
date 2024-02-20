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
using System.Runtime.InteropServices;

namespace Microsoft.DirectX.DirectInput
{
	[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
	internal struct DIJOYSTATE2
	{
		public int lX;
		public int lY;
		public int lZ;
		public int lRx;
		public int lRy;
		public int lRz;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=2)]
		public int[] rglSlider;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=4)]
		public int[] rgdwPOV;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=128)]
		public byte[] rgbButtons;
		public int lVX;
		public int lVY;
		public int lVZ;
		public int lVRx;
		public int lVRy;
		public int lVRz;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=2)]
		public int[] rglVSlider;
		public int lAX;
		public int lAY;
		public int lAZ;
		public int lARx;
		public int lARy;
		public int lARz;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=2)]
		public int[] rglASlider;
		public int lFX;
		public int lFY;
		public int lFZ;
		public int lFRx;
		public int lFRy;
		public int lFRz;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=2)]
		public int[] rglFSlider;
	}

	public struct JoystickState
	{
		private DIJOYSTATE2 _state;

		internal JoystickState(DIJOYSTATE2 state)
		{
			_state = state;
		}

		public int FRz {
			get {
				return _state.lFRz;
			}
		}

		public int FRy {
			get {
				return _state.lFRy;
			}
		}

		public int FRx {
			get {
				return _state.lFRx;
			}
		}

		public int FZ {
			get {
				return _state.lFZ;
			}
		}

		public int FY {
			get {
				return _state.lFY;
			}
		}

		public int FX {
			get {
				return _state.lFX;
			}
		}

		public int ARz {
			get {
				return _state.lARz;
			}
		}

		public int ARy {
			get {
				return _state.lARy;
			}
		}

		public int ARx {
			get {
				return _state.lARx;
			}
		}

		public int AZ {
			get {
				return _state.lAZ;
			}
		}

		public int AY {
			get {
				return _state.lAY;
			}
		}

		public int AX {
			get {
				return _state.lAX;
			}
		}

		public int VRz {
			get {
				return _state.lVRz;
			}
		}

		public int VRy {
			get {
				return _state.lVRy;
			}
		}

		public int VRx {
			get {
				return _state.lVRx;
			}
		}

		public int VZ {
			get {
				return _state.lVZ;
			}
		}

		public int VY {
			get {
				return _state.lVY;
			}
		}

		public int VX {
			get {
				return _state.lVX;
			}
		}

		public int Rz {
			get {
				return _state.lRz;
			}
		}

		public int Ry {
			get {
				return _state.lRy;
			}
		}

		public int Rx {
			get {
				return _state.lRx;
			}
		}

		public int Z {
			get {
				return _state.lZ;
			}
		}

		public int Y {
			get {
				return _state.lY;
			}
		}

		public int X {
			get {
				return _state.lX;
			}
		}

		public override string ToString ()
		{
			throw new NotImplementedException ();
		}

		public int[] GetSlider ()
		{
			return _state.rglSlider;
		}

		public int[] GetPointOfView ()
		{
			return _state.rgdwPOV;
		}

		public byte[] GetButtons ()
		{
			return _state.rgbButtons;
		}

		public int[] GetVSlider ()
		{
			return _state.rglVSlider;
		}

		public int[] GetASlider ()
		{
			return _state.rglASlider;
		}

		public int[] GetFSlider ()
		{
			return _state.rglFSlider;
		}
	}
}

