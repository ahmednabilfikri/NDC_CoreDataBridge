using Microsoft.EntityFrameworkCore;

namespace NDC_Core_DataBridge.Models.Context;

internal sealed partial class NdcCoreDbContext : DbContext
{
    private readonly string _connectionString;
    internal NdcCoreDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public  DbSet<TtTsFbPaxSegBookDetail> TtTsFbPaxSegBookDetails { get; set; }

    public  DbSet<TtTsFbSegmentDetail> TtTsFbSegmentDetails { get; set; }

    public DbSet<TtTsFlightBook> TtTsFlightBooks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_unicode_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<TtTsFbPaxSegBookDetail>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.FbBookingRefNo, e.PassengerNo, e.SegmentRefNo })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });

            entity.ToTable("TT_TS_FB_PAX_SEG_BOOK_DETAIL");

            entity.HasIndex(e => new { e.FbBookingRefNo, e.PassengerNo, e.TicketBookingStatus }, "TT_TS_FB_PAX_SEG_BOOK_DETAIL_FBRN_PN_TBS");

            entity.HasIndex(e => e.TicketNo, "TT_TS_FB_PAX_SEG_BOOK_DETAIL_TN").HasAnnotation("MySql:IndexPrefixLength", new[] { 13 });

            entity.HasIndex(e => new { e.FbBookingRefNo, e.SegmentRefNo, e.PassengerNo }, "TT_TS_FB_PAX_SEG_BOOK_DETAIL_UK").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.FbBookingRefNo)
                .HasMaxLength(50)
                .HasColumnName("FB_BOOKING_REF_NO");
            entity.Property(e => e.PassengerNo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("PASSENGER_NO");
            entity.Property(e => e.SegmentRefNo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("SEGMENT_REF_NO");
            entity.Property(e => e.CreationTime)
                .HasColumnType("datetime")
                .HasColumnName("CREATION_TIME");
            entity.Property(e => e.FrequentFlyerNo)
                .HasMaxLength(100)
                .HasColumnName("FREQUENT_FLYER_NO");
            entity.Property(e => e.LastModTime)
                .HasColumnType("datetime")
                .HasColumnName("LAST_MOD_TIME");
            entity.Property(e => e.PaxBaseFare)
                .HasColumnType("float(10,2)")
                .HasColumnName("PAX_BASE_FARE");
            entity.Property(e => e.PaxFeeNTaxes)
                .HasColumnType("float(10,2)")
                .HasColumnName("PAX_FEE_N_TAXES");
            entity.Property(e => e.PaxFlightFare)
                .HasColumnType("float(10,2)")
                .HasColumnName("PAX_FLIGHT_FARE");
            entity.Property(e => e.PaxOdeysysDiscount)
                .HasColumnType("float(10,2)")
                .HasColumnName("PAX_ODEYSYS_DISCOUNT");
            entity.Property(e => e.PaxOdeysysFare)
                .HasColumnType("float(10,2)")
                .HasColumnName("PAX_ODEYSYS_FARE");
            entity.Property(e => e.PaxOdeysysMarkup)
                .HasColumnType("float(10,2)")
                .HasColumnName("PAX_ODEYSYS_MARKUP");
            entity.Property(e => e.PaxOdeysysServiceCharge)
                .HasColumnType("float(10,2)")
                .HasColumnName("PAX_ODEYSYS_SERVICE_CHARGE");
            entity.Property(e => e.PreferredMeal)
                .HasMaxLength(50)
                .HasColumnName("PREFERRED_MEAL");
            entity.Property(e => e.PreferredSeat)
                .HasMaxLength(50)
                .HasColumnName("PREFERRED_SEAT");
            entity.Property(e => e.TicketBookingStatus)
                .HasDefaultValueSql("'0'")
                .HasColumnName("TICKET_BOOKING_STATUS");
            entity.Property(e => e.TicketNo)
                .HasMaxLength(50)
                .HasColumnName("TICKET_NO");
            entity.Property(e => e.TicketSupplierCarrierCode)
                .HasMaxLength(10)
                .HasColumnName("TICKET_SUPPLIER_CARRIER_CODE");
            entity.Property(e => e.TtPaxBranchOnflyMarkup)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("float(10,2)")
                .HasColumnName("TT_PAX_BRANCH_ONFLY_MARKUP");
            entity.Property(e => e.UpdatedPaxBaseFare)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("float(10,2)")
                .HasColumnName("UPDATED_PAX_BASE_FARE");
            entity.Property(e => e.UpdatedPaxFeeNTaxes)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("float(10,2)")
                .HasColumnName("UPDATED_PAX_FEE_N_TAXES");
            entity.Property(e => e.UpdatedPaxFlightFare)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("float(10,2)")
                .HasColumnName("UPDATED_PAX_FLIGHT_FARE");
            entity.Property(e => e.UpdatedPaxOdeysysFare)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("float(10,2)")
                .HasColumnName("UPDATED_PAX_ODEYSYS_FARE");
        });

        modelBuilder.Entity<TtTsFbSegmentDetail>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.SegmentNo, e.FbBookingRefNo })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("TT_TS_FB_SEGMENT_DETAIL");

            entity.HasIndex(e => new { e.AirlinePnr, e.TravelDate }, "TT_TS_FB_SEGMENT_DETAIL_AP_TD").HasAnnotation("MySql:IndexPrefixLength", new[] { 10, 0 });

            entity.HasIndex(e => new { e.Origin, e.Destination, e.FbBookingRefNo, e.TravelDate, e.BookingDate }, "TT_TS_FB_SEGMENT_DETAIL_O_D_FBF_TD_BD").IsDescending(false, false, false, false, true);

            entity.HasIndex(e => e.SpPnr, "TT_TS_FB_SEGMENT_DETAIL_SP");

            entity.HasIndex(e => new { e.FbBookingRefNo, e.SegmentNo }, "TT_TS_FB_SEGMENT_DETAIL_UK").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.SegmentNo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("SEGMENT_NO");
            entity.Property(e => e.FbBookingRefNo)
                .HasMaxLength(50)
                .HasColumnName("FB_BOOKING_REF_NO");
            entity.Property(e => e.AdultBaseFare)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("ADULT_BASE_FARE");
            entity.Property(e => e.AdultCabinBaggageAllowance)
                .HasMaxLength(150)
                .HasColumnName("ADULT_CABIN_BAGGAGE_ALLOWANCE");
            entity.Property(e => e.AdultFeeNTaxes)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("ADULT_FEE_N_TAXES");
            entity.Property(e => e.AirlinePnr)
                .HasMaxLength(50)
                .HasColumnName("AIRLINE_PNR");
            entity.Property(e => e.BaseFare)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("BASE_FARE");
            entity.Property(e => e.BookerCity)
                .HasMaxLength(50)
                .HasColumnName("BOOKER_CITY");
            entity.Property(e => e.BookerCountry)
                .HasMaxLength(50)
                .HasColumnName("BOOKER_COUNTRY");
            entity.Property(e => e.BookerId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BOOKER_ID");
            entity.Property(e => e.BookingClass)
                .HasMaxLength(20)
                .HasColumnName("BOOKING_CLASS");
            entity.Property(e => e.BookingDate)
                .HasColumnType("datetime")
                .HasColumnName("BOOKING_DATE");
            entity.Property(e => e.BookingStatus)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BOOKING_STATUS");
            entity.Property(e => e.CabinClass)
                .HasDefaultValueSql("'0'")
                .HasColumnName("CABIN_CLASS");
            entity.Property(e => e.CancellationDate)
                .HasColumnType("datetime")
                .HasColumnName("CANCELLATION_DATE");
            entity.Property(e => e.CancellationRemark)
                .HasMaxLength(250)
                .HasColumnName("CANCELLATION_REMARK");
            entity.Property(e => e.CancelledBy)
                .HasDefaultValueSql("'0'")
                .HasColumnName("CANCELLED_BY");
            entity.Property(e => e.ChildBaseFare)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("CHILD_BASE_FARE");
            entity.Property(e => e.ChildCabinBaggageAllowance)
                .HasMaxLength(150)
                .HasColumnName("CHILD_CABIN_BAGGAGE_ALLOWANCE");
            entity.Property(e => e.ChildFeeNTaxes)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("CHILD_FEE_N_TAXES");
            entity.Property(e => e.ChildInclCheckinBagAllowance)
                .HasMaxLength(150)
                .HasColumnName("CHILD_INCL_CHECKIN_BAG_ALLOWANCE");
            entity.Property(e => e.Currency)
                .HasMaxLength(50)
                .HasColumnName("CURRENCY");
            entity.Property(e => e.DealCode)
                .HasMaxLength(50)
                .HasColumnName("DEAL_CODE");
            entity.Property(e => e.Destination)
                .HasMaxLength(50)
                .HasColumnName("DESTINATION");
            entity.Property(e => e.FareSellKey)
                .HasMaxLength(500)
                .HasColumnName("FARE_SELL_KEY");
            entity.Property(e => e.FeeNTaxes)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("FEE_N_TAXES");
            entity.Property(e => e.FlightFare)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("FLIGHT_FARE");
            entity.Property(e => e.InclCheckinBagAllowance)
                .HasMaxLength(150)
                .HasColumnName("INCL_CHECKIN_BAG_ALLOWANCE");
            entity.Property(e => e.InfantBaseFare)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("INFANT_BASE_FARE");
            entity.Property(e => e.InfantCabinBaggageAllowance)
                .HasMaxLength(150)
                .HasColumnName("INFANT_CABIN_BAGGAGE_ALLOWANCE");
            entity.Property(e => e.InfantFeeNTaxes)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("INFANT_FEE_N_TAXES");
            entity.Property(e => e.InfantInclCheckinBagAllowance)
                .HasMaxLength(150)
                .HasColumnName("INFANT_INCL_CHECKIN_BAG_ALLOWANCE");
            entity.Property(e => e.JourneyDuration)
                .HasMaxLength(30)
                .HasColumnName("JOURNEY_DURATION");
            entity.Property(e => e.JourneySellKey)
                .HasMaxLength(500)
                .HasColumnName("JOURNEY_SELL_KEY");
            entity.Property(e => e.LastModTime)
                .HasColumnType("datetime")
                .HasColumnName("LAST_MOD_TIME");
            entity.Property(e => e.LastUpdatedBy)
                .HasDefaultValueSql("'0'")
                .HasColumnName("LAST_UPDATED_BY");
            entity.Property(e => e.ManualDealCode)
                .HasMaxLength(45)
                .HasColumnName("MANUAL_DEAL_CODE");
            entity.Property(e => e.MarketingCarrier)
                .HasMaxLength(50)
                .HasColumnName("MARKETING_CARRIER");
            entity.Property(e => e.OdeysysAmount)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("ODEYSYS_AMOUNT");
            entity.Property(e => e.OdeysysDiscount)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("ODEYSYS_DISCOUNT");
            entity.Property(e => e.OdeysysServiceCharge)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("ODEYSYS_SERVICE_CHARGE");
            entity.Property(e => e.OperatingCarrier)
                .HasMaxLength(50)
                .HasColumnName("OPERATING_CARRIER");
            entity.Property(e => e.Origin)
                .HasMaxLength(50)
                .HasColumnName("ORIGIN");
            entity.Property(e => e.PlatingCarrier)
                .HasMaxLength(50)
                .HasColumnName("PLATING_CARRIER");
            entity.Property(e => e.QueuePcc)
                .HasMaxLength(50)
                .HasColumnName("QUEUE_PCC");
            entity.Property(e => e.QueueRef)
                .HasMaxLength(50)
                .HasColumnName("QUEUE_REF");
            entity.Property(e => e.ReservationRecordLocator)
                .HasMaxLength(45)
                .HasColumnName("RESERVATION_RECORD_LOCATOR");
            entity.Property(e => e.SearchPcc)
                .HasDefaultValueSql("'0'")
                .HasColumnName("SEARCH_PCC");
            entity.Property(e => e.SegmentTripType)
                .HasDefaultValueSql("'0'")
                .HasColumnName("SEGMENT_TRIP_TYPE");
            entity.Property(e => e.SpPnr)
                .HasMaxLength(50)
                .HasColumnName("SP_PNR");
            entity.Property(e => e.SsrTotalAmount)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("SSR_TOTAL_AMOUNT");
            entity.Property(e => e.TicketingPcc)
                .HasDefaultValueSql("'0'")
                .HasColumnName("TICKETING_PCC");
            entity.Property(e => e.TotalAmount)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("TOTAL_AMOUNT");
            entity.Property(e => e.TotalBaseFare)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("TOTAL_BASE_FARE");
            entity.Property(e => e.TotalFeeNTaxes)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("TOTAL_FEE_N_TAXES");
            entity.Property(e => e.TransactionId)
                .HasMaxLength(50)
                .HasColumnName("TRANSACTION_ID");
            entity.Property(e => e.TravelDate)
                .HasColumnType("datetime")
                .HasColumnName("TRAVEL_DATE");
            entity.Property(e => e.UniversalRecordLocator)
                .HasMaxLength(45)
                .HasColumnName("UNIVERSAL_RECORD_LOCATOR");
            entity.Property(e => e.UsdConverationRate)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("USD_CONVERATION_RATE");
            entity.Property(e => e.VendorType)
                .HasDefaultValueSql("'0'")
                .HasColumnName("VENDOR_TYPE");
        });

        modelBuilder.Entity<TtTsFlightBook>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("TT_TS_FLIGHT_BOOK");

            entity.HasIndex(e => new { e.AgencyId, e.OrderId }, "TT_TS_FLIGHT_BOOK_AGENCYID_INDX");

            entity.HasIndex(e => new { e.CreationTime, e.AgencyId, e.BookingStatus }, "TT_TS_FLIGHT_BOOK_AI_CT_BS");

            entity.HasIndex(e => new { e.BookingStatus, e.BookingType, e.CreationTime }, "TT_TS_FLIGHT_BOOK_BS_BT_CT").IsDescending(false, false, true);

            entity.HasIndex(e => e.CreationTime, "TT_TS_FLIGHT_BOOK_CRTTIME_INDX");

            entity.HasIndex(e => new { e.OrderId, e.BookingStatus }, "TT_TS_FLIGHT_BOOK_INDX");

            entity.HasIndex(e => new { e.LastModTime, e.BookingStatus }, "TT_TS_FLIGHT_BOOK_LMT_BS");

            entity.HasIndex(e => e.LoginId, "TT_TS_FLIGHT_BOOK_LOGINID_INDX");

            entity.HasIndex(e => new { e.OrderId, e.FbBookingRefNo, e.CreatedBy, e.BookingStatus }, "TT_TS_FLIGHT_BOOK_OI_FBRN_CB_BS");

            entity.HasIndex(e => e.OrderId, "TT_TS_FLIGHT_BOOK_ORDERID_INDX");

            entity.HasIndex(e => e.FbBookingRefNo, "TT_TS_FLIGHT_BOOK_UK").IsUnique();

            entity.HasIndex(e => new { e.BranchId, e.AgencyId }, "TT_TS_FLIGHT_BOOK_branch_id");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AgencyClientName)
                .HasMaxLength(100)
                .HasColumnName("AGENCY_CLIENT_NAME");
            entity.Property(e => e.AgencyId)
                .HasMaxLength(50)
                .HasColumnName("AGENCY_ID");
            entity.Property(e => e.AgencyToSupplierRoe)
                .HasDefaultValueSql("'1.000000'")
                .HasColumnType("float(10,6)")
                .HasColumnName("AGENCY_TO_SUPPLIER_ROE");
            entity.Property(e => e.AmendmentPenalty)
                .HasDefaultValueSql("'0'")
                .HasColumnName("AMENDMENT_PENALTY");
            entity.Property(e => e.AutoTicketingDisabled)
                .HasDefaultValueSql("'0'")
                .HasColumnName("AUTO_TICKETING_DISABLED");
            entity.Property(e => e.BookingStatus)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BOOKING_STATUS");
            entity.Property(e => e.BookingType)
                .HasDefaultValueSql("'0'")
                .HasColumnName("BOOKING_TYPE");
            entity.Property(e => e.BranchId)
                .HasMaxLength(50)
                .HasColumnName("BRANCH_ID");
            entity.Property(e => e.BspCommissionPer)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("BSP_COMMISSION_PER");
            entity.Property(e => e.CreatedBy)
                .HasDefaultValueSql("'0'")
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreationTime)
                .HasColumnType("datetime")
                .HasColumnName("CREATION_TIME");
            entity.Property(e => e.CurrExchangeRate)
                .HasDefaultValueSql("'1.000000'")
                .HasColumnType("float(10,6)")
                .HasColumnName("CURR_EXCHANGE_RATE");
            entity.Property(e => e.Currency)
                .HasMaxLength(50)
                .HasColumnName("CURRENCY");
            entity.Property(e => e.Destination)
                .HasMaxLength(50)
                .HasColumnName("DESTINATION");
            entity.Property(e => e.EmailNotification)
                .HasDefaultValueSql("'0'")
                .HasColumnName("EMAIL_NOTIFICATION");
            entity.Property(e => e.FareMismatch)
                .HasDefaultValueSql("'0'")
                .HasColumnName("FARE_MISMATCH");
            entity.Property(e => e.FbBookingRefNo)
                .HasMaxLength(50)
                .HasColumnName("FB_BOOKING_REF_NO");
            entity.Property(e => e.FlightDocUrl)
                .HasMaxLength(200)
                .HasColumnName("FLIGHT_DOC_URL");
            entity.Property(e => e.ImportPnrCase)
                .HasDefaultValueSql("'0'")
                .HasColumnName("IMPORT_PNR_CASE");
            entity.Property(e => e.IsAmendment)
                .HasDefaultValueSql("'0'")
                .HasColumnName("IS_AMENDMENT");
            entity.Property(e => e.IsMarkdownCase)
                .HasDefaultValueSql("'0'")
                .HasColumnName("IS_MARKDOWN_CASE");
            entity.Property(e => e.IsMulticarrier)
                .HasDefaultValueSql("'0'")
                .HasColumnName("IS_MULTICARRIER");
            entity.Property(e => e.IsTwoOneWay)
                .HasDefaultValueSql("'0'")
                .HasColumnName("IS_TWO_ONE_WAY");
            entity.Property(e => e.LastModTime)
                .HasColumnType("datetime")
                .HasColumnName("LAST_MOD_TIME");
            entity.Property(e => e.LastTicketingDate)
                .HasColumnType("datetime")
                .HasColumnName("LAST_TICKETING_DATE");
            entity.Property(e => e.LastTicketingDateZone)
                .HasColumnType("datetime")
                .HasColumnName("LAST_TICKETING_DATE_ZONE");
            entity.Property(e => e.LastUpdatedBy)
                .HasDefaultValueSql("'0'")
                .HasColumnName("LAST_UPDATED_BY");
            entity.Property(e => e.LoginId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("LOGIN_ID");
            entity.Property(e => e.ManualImportPricing).HasColumnName("MANUAL_IMPORT_PRICING");
            entity.Property(e => e.NoOfPassenger)
                .HasDefaultValueSql("'0'")
                .HasColumnName("NO_OF_PASSENGER");
            entity.Property(e => e.NoOfSegment)
                .HasDefaultValueSql("'0'")
                .HasColumnName("NO_OF_SEGMENT");
            entity.Property(e => e.OdeysysAmount)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("ODEYSYS_AMOUNT");
            entity.Property(e => e.OdeysysBspCommisionOn)
                .HasDefaultValueSql("'0'")
                .HasColumnName("ODEYSYS_BSP_COMMISION_ON");
            entity.Property(e => e.OdeysysBspCommissionPer)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("ODEYSYS_BSP_COMMISSION_PER");
            entity.Property(e => e.OdeysysDiscount)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("ODEYSYS_DISCOUNT");
            entity.Property(e => e.OdeysysServiceCharge)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("ODEYSYS_SERVICE_CHARGE");
            entity.Property(e => e.OnlyBaggageFare)
                .HasDefaultValueSql("'0'")
                .HasColumnName("ONLY_BAGGAGE_FARE");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasColumnName("ORDER_ID");
            entity.Property(e => e.Origin)
                .HasMaxLength(50)
                .HasColumnName("ORIGIN");
            entity.Property(e => e.PenaltyAmount)
                .HasDefaultValueSql("'0'")
                .HasColumnName("PENALTY_AMOUNT");
            entity.Property(e => e.QueuePcc)
                .HasMaxLength(50)
                .HasColumnName("QUEUE_PCC");
            entity.Property(e => e.QueueRef)
                .HasMaxLength(50)
                .HasColumnName("QUEUE_REF");
            entity.Property(e => e.RefundAmount)
                .HasDefaultValueSql("'0'")
                .HasColumnName("REFUND_AMOUNT");
            entity.Property(e => e.Responseid)
                .HasMaxLength(50)
                .HasColumnName("RESPONSEID");
            entity.Property(e => e.Responseorderid)
                .HasMaxLength(50)
                .HasColumnName("RESPONSEORDERID");
            entity.Property(e => e.SplitPnrCase)
                .HasDefaultValueSql("'0'")
                .HasColumnName("SPLIT_PNR_CASE");
            entity.Property(e => e.SupplierCurrency)
                .HasMaxLength(20)
                .HasColumnName("SUPPLIER_CURRENCY");
            entity.Property(e => e.SupplierName)
                .HasMaxLength(100)
                .HasColumnName("SUPPLIER_NAME");
            entity.Property(e => e.SupplierPaymentMode)
                .HasDefaultValueSql("'1'")
                .HasColumnName("SUPPLIER_PAYMENT_MODE");
            entity.Property(e => e.SyncPnrMode)
                .HasDefaultValueSql("'0'")
                .HasColumnName("SYNC_PNR_MODE");
            entity.Property(e => e.TotalAgencyInvoiceAmt)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("TOTAL_AGENCY_INVOICE_AMT");
            entity.Property(e => e.TotalAgentAmtToReceive)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("TOTAL_AGENT_AMT_TO_RECEIVE");
            entity.Property(e => e.TotalAmount)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("TOTAL_AMOUNT");
            entity.Property(e => e.TotalBaseFare)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("TOTAL_BASE_FARE");
            entity.Property(e => e.TotalFeeNTaxes)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("TOTAL_FEE_N_TAXES");
            entity.Property(e => e.TotalFlightFare)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("TOTAL_FLIGHT_FARE");
            entity.Property(e => e.TotalOdeysysAgencyMarkup)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("TOTAL_ODEYSYS_AGENCY_MARKUP");
            entity.Property(e => e.TotalOdeysysAgentOnflyMarkup)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("TOTAL_ODEYSYS_AGENT_ONFLY_MARKUP");
            entity.Property(e => e.TotalOdeysysBranchOnflyMarkup)
                .HasPrecision(10, 3)
                .HasDefaultValueSql("'0.000'")
                .HasColumnName("TOTAL_ODEYSYS_BRANCH_ONFLY_MARKUP");
            entity.Property(e => e.TotalOdeysysBspCommision)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("TOTAL_ODEYSYS_BSP_COMMISION");
            entity.Property(e => e.TotalOdeysysDiscount)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("TOTAL_ODEYSYS_DISCOUNT");
            entity.Property(e => e.TotalOdeysysFare)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("TOTAL_ODEYSYS_FARE");
            entity.Property(e => e.TotalOdeysysMarkup)
                .HasColumnType("float(10,3)")
                .HasColumnName("TOTAL_ODEYSYS_MARKUP");
            entity.Property(e => e.TotalOdeysysServiceCharge)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("TOTAL_ODEYSYS_SERVICE_CHARGE");
            entity.Property(e => e.TotalOdeysysStaffMarkdown)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("TOTAL_ODEYSYS_STAFF_MARKDOWN");
            entity.Property(e => e.TotalSupplierAmtToPay)
                .HasDefaultValueSql("'0.000'")
                .HasColumnType("float(10,3)")
                .HasColumnName("TOTAL_SUPPLIER_AMT_TO_PAY");
            entity.Property(e => e.TotalSurchargeAmount)
                .HasDefaultValueSql("'0'")
                .HasColumnName("TOTAL_SURCHARGE_AMOUNT");
            entity.Property(e => e.TransactionStatus)
                .HasDefaultValueSql("'0'")
                .HasColumnName("TRANSACTION_STATUS");
            entity.Property(e => e.TravelAgentName)
                .HasMaxLength(100)
                .HasColumnName("TRAVEL_AGENT_NAME");
            entity.Property(e => e.TripType)
                .HasDefaultValueSql("'0'")
                .HasColumnName("TRIP_TYPE");
            entity.Property(e => e.UccfTransactionCharge)
                .HasDefaultValueSql("'0.00'")
                .HasColumnType("float(10,2)")
                .HasColumnName("UCCF_TRANSACTION_CHARGE");
            entity.Property(e => e.UccfTransactionOn)
                .HasDefaultValueSql("'0'")
                .HasColumnName("UCCF_TRANSACTION_ON");
            entity.Property(e => e.UpgradedBooking)
                .HasDefaultValueSql("'0'")
                .HasColumnName("UPGRADED_BOOKING");
            entity.Property(e => e.UsdExchangeRate)
                .HasDefaultValueSql("'1.000000'")
                .HasColumnType("float(10,6)")
                .HasColumnName("USD_EXCHANGE_RATE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
