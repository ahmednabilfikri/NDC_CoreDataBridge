using System;
using System.Collections.Generic;

namespace NDC_Core_DataBridge.Models;

public partial class TtTsFbSegmentDetail
{
    public int Id { get; set; }

    public string FbBookingRefNo { get; set; } = null!;

    public int SegmentNo { get; set; }

    public string Origin { get; set; } = null!;

    public string Destination { get; set; } = null!;

    public int? SegmentTripType { get; set; }

    public DateTime TravelDate { get; set; }

    public DateTime BookingDate { get; set; }

    public string BookingClass { get; set; } = null!;

    public string? JourneyDuration { get; set; }

    public int? CabinClass { get; set; }

    public int? BookingStatus { get; set; }

    public int? SearchPcc { get; set; }

    public int? TicketingPcc { get; set; }

    public int? VendorType { get; set; }

    public int? BookerId { get; set; }

    public string? BookerCity { get; set; }

    public string? BookerCountry { get; set; }

    public string? AirlinePnr { get; set; }

    public string SpPnr { get; set; }

    public string? InclCheckinBagAllowance { get; set; }

    public int? CancelledBy { get; set; }

    public DateTime? CancellationDate { get; set; }

    public string? CancellationRemark { get; set; }

    public string? DealCode { get; set; }

    public string? MarketingCarrier { get; set; }

    public string? OperatingCarrier { get; set; }

    public float? AdultBaseFare { get; set; }

    public float? ChildBaseFare { get; set; }

    public float? InfantBaseFare { get; set; }

    public float? AdultFeeNTaxes { get; set; }

    public float? ChildFeeNTaxes { get; set; }

    public float? InfantFeeNTaxes { get; set; }

    public float? SsrTotalAmount { get; set; }

    public float? TotalAmount { get; set; }

    public float? TotalBaseFare { get; set; }

    public float? TotalFeeNTaxes { get; set; }

    public float? OdeysysDiscount { get; set; }

    public float? OdeysysServiceCharge { get; set; }

    public float? OdeysysAmount { get; set; }

    public string? Currency { get; set; }

    public float? UsdConverationRate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastModTime { get; set; }

    public string? TransactionId { get; set; }

    public string? QueuePcc { get; set; }

    public string? QueueRef { get; set; }

    public float? FlightFare { get; set; }

    public float? BaseFare { get; set; }

    public float? FeeNTaxes { get; set; }

    public string? PlatingCarrier { get; set; }

    public string? ChildInclCheckinBagAllowance { get; set; }

    public string? InfantInclCheckinBagAllowance { get; set; }

    public string? AdultCabinBaggageAllowance { get; set; }

    public string? ChildCabinBaggageAllowance { get; set; }

    public string? InfantCabinBaggageAllowance { get; set; }

    public string? JourneySellKey { get; set; }

    public string? FareSellKey { get; set; }

    public string? UniversalRecordLocator { get; set; }

    public string? ReservationRecordLocator { get; set; }

    public string? ManualDealCode { get; set; }
}
