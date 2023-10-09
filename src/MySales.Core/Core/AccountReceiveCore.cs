using MySales.Core.Contracts;
using MySales.Model.Entities;

namespace MySales.Core.Core;

public class AccountReceiveCore : IAccountReceiveCore
{
    public List<AccountReceive> GenerateParcels(decimal total, int numberOfInstallments, int dayOfMonth)
    {
        List<AccountReceive> parcels = new List<AccountReceive>();

        decimal parcelAmount = total / numberOfInstallments;
        DateTime dueDate = CalculateInitialDueDate(dayOfMonth);

        for (int i = 1; i <= numberOfInstallments; i++)
        {
            parcels.Add(new AccountReceive
            {
                NumberParcel = i,
                Total = parcelAmount,
                DatePay = dueDate

            });

            dueDate = dueDate.AddMonths(1);
        }

        return parcels;
    }

    private DateTime CalculateInitialDueDate(int dayOfMonth)
    {
        DateTime today = DateTime.Now;
        DateTime initialDueDate = new DateTime(today.Year, today.Month, dayOfMonth);

        if (today.Day > dayOfMonth)
        {
            initialDueDate = initialDueDate.AddMonths(1);
        }

        return initialDueDate;
    }
}
