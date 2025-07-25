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
	[StructLayout(LayoutKind.Sequential)]
	public struct DeviceCaps
	{
		int dwSize;
		int dwFlags;
		int dwDevType;
		int dwAxes;
		int dwButtons;
		int dwPOVs;
		int dwFFSamplePeriod;
		int dwFFMinTimeResolution;
		int dwFirmwareRevision;
		int dwHardwareRevision;
		int dwFFDriverVersion;

		public bool Hidden {
			
			get {
				return (dwFlags & 0x40000) != 0;
			}
		}

		public bool Phantom {
			
			get {
				return (dwFlags & 0x20000) != 0;
			}
		}

		public unsafe bool Alias {
			
			get {
				return (dwFlags & 0x10000) != 0;
			}
		}

		public bool StartDelay {
			
			get {
				return (dwFlags & 0x8000) != 0;
			}
		}

		public bool DeadBand {
			
			get {
				return (dwFlags & 0x4000) != 0;
			}
		}

		public bool PosNegSaturation {
			
			get {
				return (dwFlags & 0x2000) != 0;
			}
		}

		public bool PosNegCoefficients {
			
			get {
				return (dwFlags & 0x1000) != 0;
			}
		}

		public bool Saturation {
			
			get {
				return (dwFlags & 0x800) != 0;
			}
		}

		public bool Fade {
			
			get {
				return (dwFlags & 0x400) != 0;
			}
		}

		public bool Attack {
			
			get {
				return (dwFlags & 0x200) != 0;
			}
		}

		public bool ForceFeedback {
			
			get {
				return (dwFlags & 0x100) != 0;
			}
		}

		public bool PolledDataFormat {
			
			get {
				return (dwFlags & 0x8) != 0;
			}
		}

		public bool Emulated {
			
			get {
				return (dwFlags & 0x4) != 0;
			}
		}

		public bool PolledDevice {
			
			get {
				return (dwFlags & 0x2) != 0;
			}
		}

		public bool Attatched {
			
			get {
				return (dwFlags & 0x1) != 0;
			}
		}

		public int FFDriverVersion {
			get {
				return dwFFDriverVersion;
			}
		}

		public int HardwareRevision {
			get {
				return dwHardwareRevision;
			}
		}

		public int FirmwareRevision {
			get {
				return dwFirmwareRevision;
			}
		}

		public int FFMinTimeResolution {
			get {
				return dwFFMinTimeResolution;
			}
		}

		public int FFSamplePeriod {
			get {
				return dwFFSamplePeriod;
			}
		}

		public int NumberPointOfViews {
			get {
				return dwPOVs;
			}
		}

		public int NumberButtons {
			get {
				return dwButtons;
			}
		}

		public int NumberAxes {
			get {
				return dwAxes;
			}
		}

		public int DeviceSubType {
			get {
				return (dwDevType >> 8) & 0xff;
			}
		}

		public DeviceType DeviceType {
			get {
				return (DeviceType)(dwDevType & 0xff);
			}
		}

		public override string ToString ()
		{
			throw new NotImplementedException ();
		}
	}
}

