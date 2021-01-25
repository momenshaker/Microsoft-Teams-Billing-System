using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BillingPortal.NotificationModel
{
    public class Records
    {
        [Key]
        public Guid RecordId { get; set; }


        [JsonProperty("@odata.context")]
        public Uri OdataContext { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("version")]
        public long Version { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }


        [JsonProperty("lastModifiedDateTime")]
        public DateTimeOffset LastModifiedDateTime { get; set; }

        [JsonProperty("startDateTime")]
        public DateTimeOffset StartDateTime { get; set; }

        [JsonProperty("endDateTime")]
        public DateTimeOffset EndDateTime { get; set; }



        [JsonProperty("organizer")]
        public Organizer Organizer { get; set; }

        [JsonProperty("participants")]
        public List<Organizer> Participants { get; set; }

        [JsonProperty("sessions@odata.context")]
        public Uri SessionsOdataContext { get; set; }

        [JsonProperty("sessions")]
        public List<Session> Sessions { get; set; }
    }

    public partial class Organizer
    {
        [Key]
        public Guid Organizerid { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
        public Phone Phone { get; set; }
    }

    public partial class User
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("tenantId")]
        public Guid TenantId { get; set; }
    }
    public partial class Phone
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("tenantId")]
        public string TenantId { get; set; }
    }
    public partial class Session
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }



        [JsonProperty("startDateTime")]
        public DateTimeOffset StartDateTime { get; set; }

        [JsonProperty("endDateTime")]
        public DateTimeOffset EndDateTime { get; set; }



        [JsonProperty("caller")]
        public Calle Caller { get; set; }

        [JsonProperty("callee")]
        public Calle Callee { get; set; }

        [JsonProperty("Segments")]
        public List<Segment> Segments { get; set; }


    }

    public partial class Calle
    {
        [Key]
        public Guid Calleid { get; set; }
        [JsonProperty("@odata.type")]
        public string OdataType { get; set; }

        [JsonProperty("feedback")]

        public string Feedback { get; set; }

        [JsonProperty("userAgent")]
        public UserAgent UserAgent { get; set; }

        [JsonProperty("identity")]
        public Organizer Identity { get; set; }
    }

    public partial class UserAgent
    {
        [Key]
        public Guid UserAgentid { get; set; }
        [JsonProperty("@odata.type")]
        public string OdataType { get; set; }

        [JsonProperty("headerValue")]
        public string HeaderValue { get; set; }

        [JsonProperty("applicationVersion")]
        public string ApplicationVersion { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("productFamily")]
        public string ProductFamily { get; set; }
    }

    public partial class Segment
    {


        [JsonProperty("media")]
        public List<Media> Media { get; set; }
    }

    public partial class Media
    {
        [Key]
        public Guid Mediaid { get; set; }
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("callerNetwork")]
        public CalleNetwork CallerNetwork { get; set; }

        [JsonProperty("calleeNetwork")]
        public CalleNetwork CalleeNetwork { get; set; }

        [JsonProperty("callerDevice")]
        public CalleDevice CallerDevice { get; set; }

        [JsonProperty("calleeDevice")]
        public CalleDevice CalleeDevice { get; set; }

        [JsonProperty("streams")]
        public List<Stream> Streams { get; set; }
    }

    public partial class CalleDevice
    {
        [Key]
        public Guid CalleDeviceid { get; set; }
        [JsonProperty("captureDeviceName")]
        public string CaptureDeviceName { get; set; }

        [JsonProperty("captureDeviceDriver")]
        public string CaptureDeviceDriver { get; set; }

        [JsonProperty("renderDeviceName")]
        public string RenderDeviceName { get; set; }

        [JsonProperty("renderDeviceDriver")]
        public string RenderDeviceDriver { get; set; }

        [JsonProperty("sentSignalLevel")]
        public string SentSignalLevel { get; set; }

        [JsonProperty("receivedSignalLevel")]
        public long? ReceivedSignalLevel { get; set; }
        [JsonProperty("sentNoiseLevel")]
        public string SentNoiseLevel { get; set; }

        [JsonProperty("receivedNoiseLevel")]
        public long? ReceivedNoiseLevel { get; set; }

        [JsonProperty("initialSignalLevelRootMeanSquare")]
        public string InitialSignalLevelRootMeanSquare { get; set; }

        [JsonProperty("cpuInsufficentEventRatio")]
        public long? CpuInsufficentEventRatio { get; set; }

        [JsonProperty("renderNotFunctioningEventRatio")]
        public long? RenderNotFunctioningEventRatio { get; set; }

        [JsonProperty("captureNotFunctioningEventRatio")]
        public long? CaptureNotFunctioningEventRatio { get; set; }

        [JsonProperty("deviceGlitchEventRatio")]
        public long? DeviceGlitchEventRatio { get; set; }

        [JsonProperty("lowSpeechToNoiseEventRatio")]
        public long? LowSpeechToNoiseEventRatio { get; set; }

        [JsonProperty("lowSpeechLevelEventRatio")]
        public long? LowSpeechLevelEventRatio { get; set; }

        [JsonProperty("deviceClippingEventRatio")]
        public long? DeviceClippingEventRatio { get; set; }

        [JsonProperty("howlingEventCount")]
        public long? HowlingEventCount { get; set; }

        [JsonProperty("renderZeroVolumeEventRatio")]
        public long? RenderZeroVolumeEventRatio { get; set; }

        [JsonProperty("renderMuteEventRatio")]
        public long? RenderMuteEventRatio { get; set; }

        [JsonProperty("micGlitchRate")]

        public string MicGlitchRate { get; set; }

        [JsonProperty("speakerGlitchRate")]

        public string SpeakerGlitchRate { get; set; }
    }

    public partial class CalleNetwork
    {
        [Key]
        public Guid CalleNetworkid { get; set; }

        [JsonProperty("ipAddress")]
        public string IpAddress { get; set; }

        [JsonProperty("subnet")]
        public string Subnet { get; set; }

        [JsonProperty("linkSpeed")]
        public long? LinkSpeed { get; set; }

        [JsonProperty("connectionType")]
        public string ConnectionType { get; set; }

        [JsonProperty("port")]
        public long? Port { get; set; }

        [JsonProperty("reflexiveIPAddress")]
        public string ReflexiveIpAddress { get; set; }

        [JsonProperty("relayIPAddress")]
        public string RelayIpAddress { get; set; }

        [JsonProperty("relayPort")]
        public long? RelayPort { get; set; }

        [JsonProperty("macAddress")]
        public string MacAddress { get; set; }

        [JsonProperty("wifiMicrosoftDriver")]
        public string WifiMicrosoftDriver { get; set; }

        [JsonProperty("wifiMicrosoftDriverVersion")]
        public string WifiMicrosoftDriverVersion { get; set; }

        [JsonProperty("wifiVendorDriver")]
        public string WifiVendorDriver { get; set; }

        [JsonProperty("wifiVendorDriverVersion")]
        public string WifiVendorDriverVersion { get; set; }

        [JsonProperty("wifiChannel")]
        public long? WifiChannel { get; set; }

        [JsonProperty("wifiBand")]
        public string WifiBand { get; set; }

        [JsonProperty("basicServiceSetIdentifier")]
        public string BasicServiceSetIdentifier { get; set; }

        [JsonProperty("wifiRadioType")]
        public string WifiRadioType { get; set; }

        [JsonProperty("wifiSignalStrength")]
        public long? WifiSignalStrength { get; set; }

        [JsonProperty("wifiBatteryCharge")]
        public long? WifiBatteryCharge { get; set; }

        [JsonProperty("dnsSuffix")]
        public string DnsSuffix { get; set; }

        [JsonProperty("sentQualityEventRatio")]
        public long? SentQualityEventRatio { get; set; }

        [JsonProperty("receivedQualityEventRatio")]
        public long? ReceivedQualityEventRatio { get; set; }

        [JsonProperty("delayEventRatio")]
        public long? DelayEventRatio { get; set; }

        [JsonProperty("bandwidthLowEventRatio")]

        public string BandwidthLowEventRatio { get; set; }
    }

    public partial class Stream
    {

        [JsonProperty("startDateTime")]
        public DateTime? StartDateTime { get; set; }

        [JsonProperty("endDateTime")]
        public DateTime? EndDateTime { get; set; }

        [JsonProperty("streamDirection")]
        public string StreamDirection { get; set; }

        [JsonProperty("averageAudioDegradation")]
        public string AverageAudioDegradation { get; set; }

        [JsonProperty("averageJitter")]
        public string AverageJitter { get; set; }

        [JsonProperty("maxJitter")]
        public string MaxJitter { get; set; }

        [JsonProperty("averagePacketLossRate")]
        public long? AveragePacketLossRate { get; set; }

        [JsonProperty("maxPacketLossRate")]
        public long? MaxPacketLossRate { get; set; }

        [JsonProperty("averageRatioOfConcealedSamples")]
        public string AverageRatioOfConcealedSamples { get; set; }

        [JsonProperty("maxRatioOfConcealedSamples")]
        public string MaxRatioOfConcealedSamples { get; set; }

        [JsonProperty("averageRoundTripTime")]
        public string AverageRoundTripTime { get; set; }

        [JsonProperty("maxRoundTripTime")]
        public string MaxRoundTripTime { get; set; }

        [JsonProperty("packetUtilization")]
        public long? PacketUtilization { get; set; }

        [JsonProperty("averageBandwidthEstimate")]
        public long? AverageBandwidthEstimate { get; set; }


        [JsonProperty("postForwardErrorCorrectionPacketLossRate")]
        public string PostForwardErrorCorrectionPacketLossRate { get; set; }

        [JsonProperty("averageVideoFrameLossPercentage")]
        public string AverageVideoFrameLossPercentage { get; set; }

        [JsonProperty("averageReceivedFrameRate")]
        public string AverageReceivedFrameRate { get; set; }

        [JsonProperty("lowFrameRateRatio")]
        public string LowFrameRateRatio { get; set; }

        [JsonProperty("averageVideoPacketLossRate")]
        public string AverageVideoPacketLossRate { get; set; }

        [JsonProperty("averageVideoFrameRate")]
        public string AverageVideoFrameRate { get; set; }

        [JsonProperty("lowVideoProcessingCapabilityRatio")]
        public string LowVideoProcessingCapabilityRatio { get; set; }

        [JsonProperty("averageAudioNetworkJitter")]
        public string AverageAudioNetworkJitter { get; set; }

        [JsonProperty("maxAudioNetworkJitter")]
        public string MaxAudioNetworkJitter { get; set; }
    }
}
