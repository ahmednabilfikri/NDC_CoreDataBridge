using System;
using System.Collections.Generic;

namespace NDC_Core_DataBridge.Models;

public partial class TtTsFlightBook
{
    public int Id { get; set; }

    public string FbBookingRefNo { get; set; } = null!;

    public string OrderId { get; set; } = null!;

    public string AgencyId { get; set; } = null!;

    public string BranchId { get; set; } = null!;

    public string Origin { get; set; } = null!;

    public string Destination { get; set; } = null!;

    public int? NoOfSegment { get; set; }

    public int? NoOfPassenger { get; set; }

    public int? TripType { get; set; }

    public int? BookingStatus { get; set; }

    public int? BookingType { get; set; }

    public int? TransactionStatus { get; set; }

    public int? FareMismatch { get; set; }

    public int? UpgradedBooking { get; set; }

    public float? TotalAmount { get; set; }

    public float? TotalFeeNTaxes { get; set; }

    public float? OdeysysAmount { get; set; }

    public float? OdeysysDiscount { get; set; }

    public float? OdeysysServiceCharge { get; set; }

    public float? BspCommissionPer { get; set; }

    public string? QueuePcc { get; set; }

    public string? QueueRef { get; set; }

    public DateTime CreationTime { get; set; }

    public int? CreatedBy { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastModTime { get; set; }

    public string? TravelAgentName { get; set; }

    public string? AgencyClientName { get; set; }

    public float? TotalBaseFare { get; set; }

    public float? TotalFlightFare { get; set; }

    public float? TotalOdeysysMarkup { get; set; }

    public float? TotalOdeysysFare { get; set; }

    public float? TotalOdeysysServiceCharge { get; set; }

    public float? TotalOdeysysDiscount { get; set; }

    public float? TotalOdeysysBspCommision { get; set; }

    public float? OdeysysBspCommissionPer { get; set; }

    public int? OdeysysBspCommisionOn { get; set; }

    public float? TotalOdeysysAgencyMarkup { get; set; }

    public float? TotalOdeysysAgentOnflyMarkup { get; set; }

    public float? TotalAgentAmtToReceive { get; set; }

    public float? TotalSupplierAmtToPay { get; set; }

    public float? TotalOdeysysStaffMarkdown { get; set; }

    public float? TotalAgencyInvoiceAmt { get; set; }

    public float? UccfTransactionCharge { get; set; }

    public int? UccfTransactionOn { get; set; }

    public string? Currency { get; set; }

    public DateTime? LastTicketingDate { get; set; }

    public int? IsMarkdownCase { get; set; }

    public int? ImportPnrCase { get; set; }

    public int? SupplierPaymentMode { get; set; }

    public float? UsdExchangeRate { get; set; }

    public string? SupplierCurrency { get; set; }

    public float? CurrExchangeRate { get; set; }

    public int? IsMulticarrier { get; set; }

    public float? AgencyToSupplierRoe { get; set; }

    public int? SyncPnrMode { get; set; }

    public int? LoginId { get; set; }

    public int? IsAmendment { get; set; }

    public string? SupplierName { get; set; }

    public double? RefundAmount { get; set; }

    public double? PenaltyAmount { get; set; }

    public double? AmendmentPenalty { get; set; }

    public int? EmailNotification { get; set; }

    public int? OnlyBaggageFare { get; set; }

    public int? ManualImportPricing { get; set; }

    public decimal? TotalOdeysysBranchOnflyMarkup { get; set; }

    public int? AutoTicketingDisabled { get; set; }

    public bool? IsTwoOneWay { get; set; }

    public int? SplitPnrCase { get; set; }

    public string? FlightDocUrl { get; set; }

    public DateTime? LastTicketingDateZone { get; set; }

    public double? TotalSurchargeAmount { get; set; }

    public string? Responseid { get; set; }

    public string? Responseorderid { get; set; }
}
