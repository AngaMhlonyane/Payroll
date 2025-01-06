namespace PayrollApp.Models
{
    using PX.Data;

    [Serializable]
    [PXCacheName("Payroll")]
    public class PayrollDetails : IBqlTable
    {
        [PXDBIdentity(IsKey = true)]
        [PXUIField(DisplayName = "Payroll ID")]
        public virtual int? PayrollID { get; set; }
        public abstract class payrollID : PX.Data.BQL.BqlInt.Field<payrollID> { }

        [PXDBString(50, IsUnicode = true)]
        [PXUIField(DisplayName = "Employee Name")]
        public virtual string EmployeeName { get; set; }
        public abstract class employeeName : PX.Data.BQL.BqlString.Field<employeeName> { }

        [PXDBDecimal()]
        [PXUIField(DisplayName = "Gross Pay")]
        public virtual decimal? GrossPay { get; set; }
        public abstract class grossPay : PX.Data.BQL.BqlDecimal.Field<grossPay> { }

        [PXDBDecimal()]
        [PXUIField(DisplayName = "Deductions")]
        public virtual decimal? Deductions { get; set; }
        public abstract class deductions : PX.Data.BQL.BqlDecimal.Field<deductions> { }

        [PXDBDecimal()]
        [PXUIField(DisplayName = "Net Pay")]
        [PXFormula(typeof(Sub<grossPay, deductions>))]
        public virtual decimal? NetPay { get; set; }
        public abstract class netPay : PX.Data.BQL.BqlDecimal.Field<netPay> { }

        [PXDBDecimal()]
        [PXUIField(DisplayName = "Tax Rate (%)")]
        public virtual decimal? TaxRate { get; set; }
        public abstract class taxRate : PX.Data.BQL.BqlDecimal.Field<taxRate> { }

        [PXDBDecimal()]
        [PXUIField(DisplayName = "Tax Amount")]
        [PXFormula(typeof(Mult<grossPay, Div<taxRate, decimal100>>))]
        public virtual decimal? TaxAmount { get; set; }
        public abstract class taxAmount : PX.Data.BQL.BqlDecimal.Field<taxAmount> { }

        // Constant for decimal100
        public const decimal Decimal100 = 100m;

        public class decimal100 : PX.Data.BQL.BqlDecimal.Constant<decimal100>
        {
            public decimal100() : base(Decimal100) { }
        }
    }
}
