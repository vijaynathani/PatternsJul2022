namespace OOAD.p1
{
    internal interface IValidator
    {
        bool IsValid();
    }

    internal class PersonalLoanValidator : IValidator
    {
        public bool IsValid()
        {
            //Validation logic.
            return false;
        }
    }

    internal class VehicleLoanValidator : IValidator
    {
        public bool IsValid()
        {
            //Validation logic.
            return false
        }
    }

    internal class LoanApprovalHandler
    {
        public void ApproveLoan(IValidator validator)
        {
            if (validator.IsValid())
            {
                //Process the loan.
            }
        }
    }
}