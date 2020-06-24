using ChainOfResponsibilityPattern.Handler;
using ChainOfResponsibilityPattern.Model;

namespace ChainOfResponsibilityPattern.ConcreteHandler
{
    public class PurchasingManager : Approver
    {
        private static readonly decimal MaxPrice = 2500;

        public PurchasingManager(Approver approver) : base(approver) {}
        
        public override void ProcessRequest(PurchaseOrder purchaseOrder)
        {
            if(purchaseOrder.Price < MaxPrice)
                purchaseOrder.Approver = this;

            if(Supervisor != null)
                Supervisor.ProcessRequest(purchaseOrder);
        }
    }
}