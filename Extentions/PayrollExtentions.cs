using PayrollApp.Models;
using PX.Data;
namespace payroll
{
    public static class PayrollExtensions
    {
        public static decimal? CalculateNetPay(this PayrollDetails payroll)
        {
            if (payroll.GrossPay.HasValue && payroll.Deductions.HasValue)
            {
                return payroll.GrossPay - payroll.Deductions;
            }
            return null;
        }

        public static decimal? CalculateTaxAmount(this PayrollDetails payroll)
        {
            if (payroll.GrossPay.HasValue && payroll.TaxRate.HasValue)
            {
                return payroll.GrossPay * (payroll.TaxRate / 100);
            }
            return null;
        }
    }
}