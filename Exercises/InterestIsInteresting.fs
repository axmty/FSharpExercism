module InterestIsInteresting

let interestRate (balance: decimal) : single =
    if balance < 0m then single 3.213
    elif balance < 1000m then single 0.5
    elif balance < 5000m then single 1.621
    else single 2.475

let interest (balance: decimal) : decimal =
    balance * decimal (interestRate balance) / 100m

let annualBalanceUpdate (balance: decimal) : decimal = balance + interest balance

let amountToDonate (balance: decimal) (taxFreePercentage: float) : int =
    if balance > 0m then
        int (balance * decimal taxFreePercentage / 50m)
    else
        0
