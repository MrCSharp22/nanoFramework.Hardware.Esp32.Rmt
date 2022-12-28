//
// Copyright (c) 2020 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System.Runtime.CompilerServices;

namespace nanoFramework.Hardware.Esp32.Rmt
{
	/// <summary>
	/// Base class for a RMT channel
	/// </summary>
	public class RmtChannel
	{
		#region Fields

		/// <summary>
		/// Assigned RMT channel, assigned when channel created.
		/// </summary>
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		protected int _channel;

		/// <summary>
		/// Clock divider used on channel
		/// </summary>
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		protected byte _clockDivider = 80;

		/// <summary>
		/// RMT channel source clock
		/// </summary>
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		protected SourceClock _sourceClock = SourceClock.APB;

		/// <summary>
		/// The number of 64x32bit memory blocks to assign to the channel.
		/// </summary>
		/// <remarks>
		/// Every RMT channel by default has one memory block available to it. Each memory block 
		/// can hold 64 <see cref="RmtCommand"/>s.
		/// </remarks>
		[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		protected byte _numberOfMemoryBlocks = 1;

		/// <summary>
		/// The number of RMT channels available.
		/// </summary>
		protected const byte _NumberRmtChannels = 8;

		/// <summary>
		/// The largest channel number. Channel numbers start at 0.
		/// </summary>
		protected const byte _MaxChannelNumber = _NumberRmtChannels - 1;

		#endregion Fields

		/// <summary>
		/// The channel number we are using
		/// </summary>
		public int Channel
		{
			get => _channel;
			private set => _channel = value;
		}

		/// <summary>
		/// The value can be between 1 and 255.
		/// </summary>
		public byte ClockDivider
		{
			get => _clockDivider;
			set
			{
				_clockDivider = value;
				NativeSetClockDivider(_clockDivider);
			}
		}

		/// <summary>
		/// The source clock. Only the 80MHz APB clock is currently supported.
		/// </summary>
		public SourceClock SourceClock
		{
			get => _sourceClock;
			set => _sourceClock = value;
		}

		/// <summary>
		/// Gets or sets the number of memory blocks dedicated to this channel.
		/// </summary>
		/// <remarks>
		/// Every RMT channel by default has one memory block available to it. Each memory block 
		/// can hold 64 <see cref="RmtCommand"/>s.
		/// </remarks>
		public byte NumberOfMemoryBlocks
		{
			get => _numberOfMemoryBlocks;
			set
			{
				NativeSetNumberOfMemoryBlocks(value);
				_numberOfMemoryBlocks = value;
			}
		}

		#region native calls

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void NativeSetClockDivider(byte value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void NativeSetNumberOfMemoryBlocks(byte value);

		#endregion native calls
	}
}
