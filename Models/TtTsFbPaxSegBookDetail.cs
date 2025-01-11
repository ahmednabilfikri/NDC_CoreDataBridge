using System;
using System.Collections.Generic;

namespace NDC_Core_DataBridge.Models;

public partial class TtTsFbPaxSegBookDetail
{
    public int Id { get; set; }

    public string FbBookingRefNo { get; set; } = null!;

    public int SegmentRefNo { get; set; }

    public int PassengerNo { get; set; }

    public string? TicketNo { get; set; }

    public int? TicketBookingStatus { get; set; }

    public string? FrequentFlyerNo { get; set; }

    public string? PreferredMeal { get; set; }

    public string? PreferredSeat { get; set; }

    public DateTime CreationTime { get; set; }

    public DateTime? LastModTime { get; set; }

    public float? PaxBaseFare { get; set; }

    public float? PaxFeeNTaxes { get; set; }

    public float? PaxFlightFare { get; set; }

    public float? PaxOdeysysMarkup { get; set; }

    public float? PaxOdeysysServiceCharge { get; set; }

    public float? PaxOdeysysDiscount { get; set; }

    public float? PaxOdeysysFare { get; set; }

    public float? UpdatedPaxBaseFare { get; set; }

    public float? UpdatedPaxFeeNTaxes { get; set; }

    public float? UpdatedPaxFlightFare { get; set; }

    public float? UpdatedPaxOdeysysFare { get; set; }

    public float? TtPaxBranchOnflyMarkup { get; set; }

    public string? TicketSupplierCarrierCode { get; set; }
}
