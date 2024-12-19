<px:PXGrid ID="grid" runat="server" DataSourceID="ds">
    <Levels>
        <px:PXGridLevel DataMember="Payrolls">
            <Columns>
                <px:PXGridColumn DataField="PayrollID" DisplayName="Payroll ID" />
                <px:PXGridColumn DataField="EmployeeName" DisplayName="Employee Name" />
                <px:PXGridColumn DataField="GrossPay" DisplayName="Gross Pay" />
                <px:PXGridColumn DataField="TaxRate" DisplayName="Tax Rate (%)" />
                <px:PXGridColumn DataField="TaxAmount" DisplayName="Tax Amount" />
                <px:PXGridColumn DataField="Deductions" DisplayName="Deductions" />
                <px:PXGridColumn DataField="NetPay" DisplayName="Net Pay" />
            </Columns>
        </px:PXGridLevel>
    </Levels>
</px:PXGrid>

<px:PXDataSource ID="ds" runat="server" TypeName="Payroll.PayrollEntry" />
