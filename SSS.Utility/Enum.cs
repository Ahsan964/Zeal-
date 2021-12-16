using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Utility
{

    public enum AdjustmentType
    {
        Fuel = 1,
        OtherExpence = 2,
        Excess = 3,
        Shortage = 4
        //Excess=2
        //Shortage=1,

    }

    public enum ClosingType
    {
        NORMAL_CLOSE = 1,
        DAY_OFF = 2
    }

    public enum PostingStatus
    {
        Posted = 1,
        Unposted = 2,
    }

    public enum AccessType
    {
        View = 1,
        Edit = 2,
        Delete = 3,
        Block = 4,
        Unblock = 5,
        Insert = 6
    }

    public enum RecordStatus
    {
        Active,
        Blocked,
        Deleted,
        Pending,
        Cancel
    }

    public enum MessageType
    {
        Confirmation,
        Error,
        Question,
        Normal,
        Custom,
        Success
    }

    public enum SaleType
    {
        Active = 1,
        Expiry = 3,
        Damage = 2
    }

    public enum DocumentType
    {
        Cash_Memo = 1,
        STOCK_RECEIPT = 2,
        STOCK_TRANSFER_IN = 3,
        STOCK_TRANSFER_OUT = 4,
        STOCK_ADJUSTMENT_IN = 5,
        STOCK_ADJUSTMENT_OUT = 6,
        SCHEME = 7,
        GOODS_ISSUE_NOTE = 8,
        STOCK_RETURN = 9,
        TRADE_OFFER = 10,
        GOODS_RETURN_NOTE = 11,
        DELIVERY_ORDER_REPORT = 13,
        RETURN_TO_GODAM = 14,
        Cashmemo_Return_Without = 15,
        Purchase_Order = 16,
        GOOD_ISSUE_NOTE_SPOT_SELLER = 17,
        CASHMEMO_SPOT_SELLER = 19,
        GIN_CASHMEMO_SPOT_SELLER = 20,
        SPOT_SELLER_REQUEST=21,
        INVOICE=22
    }

    public enum Operation
    {
        Insert,
        Update,
        Block,
        UnBlock,
        Delete
    }

    public enum DiscountCategory
    {
        Free_Sku = 1,
        Percntage = 2,
        Discount_Amount = 3
    }

    public enum DiscountType
    {
        Free_SKU = 1,
        Discount_Percent = 2,
        Discount_Amount = 3,
        Discount_Weight_Amount = 4,
        Discount_Weight_Percent = 5
    }

    public enum SaleApply
    {
        Cotton = 1,
        Dozen = 2,
        Unit = 3
    }

    public enum GSTSchedule
    {
        AfterDeductingDiscount = 1,
        NoDeductingDiscount = 2
    }

    public enum TAXApplicable
    {
        SalePrice = 1,
        RetailPrice = 2
    }


    public enum ChequeStatus
    {
        UnReleased = 1,
        Released = 2,
        Bounce = 3,
        Pending = 4
    }

    public enum CashMemoType
    {
        Normal  = 1,
        Replace = 2,
        Special = 3,
        Invoice = 4
        
    }

    public enum ClaimType
    {
        Trade_Offer = 1,
        Replacement_Stock  =2
    }
    public enum DamageClaimType
    {
        Damage = 2,
        Expiry = 3
    }

    public enum ClaimStatus
    {
        ALL = 1,
        Processed = 2,
        UnProcessed = 3
    }

    public enum PersonnelType
    {
        OrderBooker = 1,
        DeliveryMan = 2,
        SoptSeller = 3
    }

    public enum FunctionalityEnum
    {
        Stock_Visibility,
        Stock_Position,
        Discount_Limit
    }

    public enum PrintOption
    {
        FullPage = 1,
        HalfPage = 2,

    }
    
}
