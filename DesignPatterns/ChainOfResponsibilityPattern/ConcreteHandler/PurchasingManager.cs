using ChainOfResponsibilityPattern.Handler;
using ChainOfResponsibilityPattern.Model;

namespace ChainOfResponsibilityPattern.ConcreteHandler
{
    public class PurchasingManager : Approver
    {
        private static readonly decimal MaxTotal = 2500;

        public PurchasingManager(Approver approver) : base(approver) {}
        
        public override void ProcessRequest(PurchaseOrder purchaseOrder)
        {
            if(purchaseOrder.Total < MaxTotal)
            {
                purchaseOrder.Approver = this;
                return;
            }

            if(Supervisor != null)
                Supervisor.ProcessRequest(purchaseOrder);
        }
    }
}