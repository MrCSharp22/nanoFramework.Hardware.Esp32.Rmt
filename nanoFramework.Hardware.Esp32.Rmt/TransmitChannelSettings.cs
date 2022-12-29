using System;

namespace nanoFramework.Hardware.Esp32.Rmt
{
	/// <summary>
	/// <see cref="TransmitterChannel"/>'s settings class.
	/// </summary>
	/// <remarks>
	/// All changes made to properties of this class are ignored after the <see cref="TransmitterChannel"/> has been initialized.
	/// You must use the equivalent properties in the channel instance to make on-the-fly changes to RMT Channel configurations.
	/// </remarks>
	public sealed class TransmitChannelSettings : RmtChannelSettings
	{
		private bool enableCarrierWave;
		private int carrierWaveFrequency;
		private byte carrierWaveDutyPercentage;
		private bool enableLooping;
		private bool enableIdleLevelOutput;

		/// <summary>
		/// Enables or disables the carrier wave generator in the RMT Hardware.
		/// </summary>
		public bool EnableCarrierWave { get => enableCarrierWave; set => enableCarrierWave = value; }

		/// <summary>
		/// Gets or sets the carrier wave frequency.
		/// </summary>
		public int CarrierWaveFrequency { get => carrierWaveFrequency; set => carrierWaveFrequency = value; }

		/// <summary>
		/// Gets or sets the carrier wave duty cycle percentage.
		/// </summary>
		public byte CarrierWaveDutyPercentage { get => carrierWaveDutyPercentage; set => carrierWaveDutyPercentage = value; }

		/// <summary>
		/// Gets or sets a value indicating whether to enable or disable looping through the ring buffer when transmitting <see cref="RmtCommand"/>s.
		/// </summary>
		public bool EnableLooping { get => enableLooping; set => enableLooping = value; }

		/// <summary>
		/// Gets or sets a value indicating whether to enable or disable the idle level output.
		/// </summary>
		public bool EnableIdleLevelOutput { get => enableIdleLevelOutput; set => enableIdleLevelOutput = value; }

		/// <summary>
		/// Initializes a new instance of the <see cref="TransmitChannelSettings"/> class.
		/// </summary>
		/// <param name="channel">The channel number to use. Valid value range is 0 to 7 (inclusive).</param>
		/// <param name="pinNumber">The GPIO Pin number to use with the channel.</param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="channel"/> must be between 0 and 7.</exception>
		public TransmitChannelSettings(int channel, int pinNumber) : base(channel, pinNumber)
		{
			this.EnableCarrierWave = true;
			this.CarrierWaveFrequency = 38_000;
			this.CarrierWaveDutyPercentage = 33;

			this.EnableLooping = false;
			this.EnableIdleLevelOutput = true;
		}
	}
}
