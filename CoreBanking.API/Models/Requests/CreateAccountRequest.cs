using CoreBanking.Core.Enums;
using CoreBanking.Core.ValueObjects;

namespace CoreBanking.API.Models.Requests;

public record CreateAccountRequest
{
    public CustomerId CustomerId { get; init; }
    public AccountType AccountType { get; init; }
    public Money InitialDeposit { get; init; }
    public string Currency { get; init; } = "NGN";
}