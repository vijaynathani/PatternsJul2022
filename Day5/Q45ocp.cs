namespace OOAD.p1
{
    //Suppose you are writing a module to approve personal loans and 
    //before doing that you want to validate the personal information.
    //Later on, its required to approve vehicle loans, consumer goods loans and what not. 
    internal class LoanApprovalHandler
    {
        public void ApprovePersonalLoan(PersonalLoanValidator validator)
        {
            if (validator.IsValid())
            {
                //Process the loan.
            }
        }

        public void ApproveVehicleLoan(VehicleLoanValidator validator)
        {
            if (validator.IsValid())
            {
                //Process the loan.
            }
        }

        // Methods for approving other loans.
    }

    internal class PersonalLoanValidator
    {
        public bool IsValid()
        {
            //Validation logic
            return false;
        }
    }

    internal class VehicleLoanValidator
    {
        public bool IsValid()
        {
            //Validation logic
            return false;
        }
    }
}