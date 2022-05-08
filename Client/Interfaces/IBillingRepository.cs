using miltonProject.Client.Models;

namespace miltonProject.Client.Interfaces
{
    public interface IBillingRepository
    {
        Task<bool> UploadRequest(BillingRequest obj);
        Task<List<BillingRequest>> GetBillsByUserId(int id);
        Task<List<BillingRequest>> GetBills();
        Task<bool> DeleteBill(int id);
    }
}
