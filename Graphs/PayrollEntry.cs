using PayrollApp.Models;
using PX.Data;

public class PayrollEntry : PXGraph<PayrollEntry, PayrollDetails>
{
    public PXSelect<PayrollDetails> Payrolls;

    public PXAction<PayrollDetails> RecalculatePayroll;
    [PXButton]
    [PXUIField(DisplayName = "Recalculate Payroll")]
    protected void recalculatePayroll()
    {
        foreach (PayrollDetails record in Payrolls.Select())
        {
            if (record.GrossPay.HasValue && record.Deductions.HasValue)
            {
                record.NetPay = record.GrossPay - record.Deductions;
                if (record.TaxRate.HasValue)
                {
                    record.TaxAmount = record.GrossPay * (record.TaxRate / 100);
                    record.Deductions += record.TaxAmount; // Include tax in total deductions
                    record.NetPay = record.GrossPay - record.Deductions;
                }
                Payrolls.Update(record);
            }
        }
        Actions.PressSave();
    }

    // Validation for Gross Pay
    protected void _(Events.FieldVerifying<PayrollDetails.grossPay> e)
    {
        if ((decimal?)e.NewValue <= 0)
        {
            throw new PXSetPropertyException("Gross Pay must be greater than 0.");
        }
    }

    // Validation for Deductions
    protected void _(Events.FieldVerifying<PayrollDetails.deductions> e)
    {
        PayrollDetails record = (PayrollDetails)e.Row;
        if ((decimal?)e.NewValue > record.GrossPay)
        {
            throw new PXSetPropertyException("Deductions cannot exceed Gross Pay.");
        }
    }
}
