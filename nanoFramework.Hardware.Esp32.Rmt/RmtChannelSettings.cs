namespace nanoFramework.Hardware.Esp32.Rmt
{
	public abstract class RmtChannelSettings
	{
		private int channel;
		private int pinNumber;
		private byte clockDivider;
		private byte numberOfMemoryBlocks;
		private int bufferSize;

		public int Channel { get => channel; set => channel = value; }

		public int PinNumber { get => pinNumber; set => pinNumber = value; }

		public byte ClockDivider { get => clockDivider; set => clockDivider = value; }

		public byte NumberOfMemoryBlocks { get => numberOfMemoryBlocks; set => numberOfMemoryBlocks = value; }

		public int BufferSize { get => bufferSize; set => bufferSize = value; }

		public RmtChannelSettings(int pinNumber)
			: this(channel: -1, pinNumber)
		{
		}

		public RmtChannelSettings(int channel, int pinNumber)
		{
			this.Channel = channel;
			this.PinNumber = pinNumber;

			this.ClockDivider = 80; // 80Mhz (80_000_000) / 80 = 1Mhz (1_000_000) = 1us clock
			this.NumberOfMemoryBlocks = 1; // default as per ESP32 IDF docs
			this.BufferSize = 100;
		}
	}

	public sealed class ReceiverChannelSettings : RmtChannelSettings
	{
		private ushort idleThreshold;
		private bool enableFilter;
		private byte filterThreshold;

		public ushort IdleThreshold { get => idleThreshold; set => idleThreshold = value; }

		public bool EnableFilter { get => enableFilter; set => enableFilter = value; }

		public byte FilterThreshold { get => filterThreshold; set => filterThreshold = value; }

		public ReceiverChannelSettings(int channel, int pinNumber) : base(channel, pinNumber)
		{
			this.IdleThreshold = 12_000; //12ms
			this.EnableFilter = true;
			this.FilterThreshold = 100;
		}
	}

	public sealed class TransmitChannelSettings : RmtChannelSettings
	{
		private bool enableCarrierWave;
		private int carrierWaveFrequency;
		private byte carrierWaveDutyPercentage;
		private bool enableLooping;
		private bool enableIdeLevelOutput;

		public bool EnableCarrierWave { get => enableCarrierWave; set => enableCarrierWave = value; }

		public int CarrierWaveFrequency { get => carrierWaveFrequency; set => carrierWaveFrequency = value; }

		public byte CarrierWaveDutyPercentage { get => carrierWaveDutyPercentage; set => carrierWaveDutyPercentage = value; }

		public bool EnableLooping { get => enableLooping; set => enableLooping = value; }

		public bool EnableIdeLevelOutput { get => enableIdeLevelOutput; set => enableIdeLevelOutput = value; }

		public TransmitChannelSettings(int channel, int pinNumber) : base(channel, pinNumber)
		{
			this.EnableCarrierWave = true;
			this.CarrierWaveFrequency = 38_000;
			this.CarrierWaveDutyPercentage = 33;

			this.EnableLooping = false;
			this.EnableIdeLevelOutput = true;
		}
	}
}
