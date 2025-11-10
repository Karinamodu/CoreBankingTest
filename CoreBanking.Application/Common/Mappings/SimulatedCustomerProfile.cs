namespace CoreBanking.Application.Common.Mappings
{
    public record SimulatedCustomerProfile(
        int BaseScore,
        decimal TotalDebt,
        int ActiveAccounts,
        int LatePayments,
        decimal CreditUtilization,
        int OldestAccountAgeMonths,
        string[] CreditFactors
    );
}
