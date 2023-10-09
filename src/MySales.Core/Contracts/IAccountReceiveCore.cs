using MySales.Model.Entities;

namespace MySales.Core.Contracts;

public interface IAccountReceiveCore
{
    List<AccountReceive> GenerateParcels(decimal total, int numberOfInstallments, int dayOfMonth);
}
