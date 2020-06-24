using ChainOfResponsibilityPattern.Handler;
using ChainOfResponsibilityPattern.Model;

namespace ChainOfResponsibilityPattern.ConcreteHandler
{
    public class HeadChef : Approver
    {
        private static readonly decimal MaxTotal = 1000;

        public HeadChef(Approver approver) : base(approver) {}
        
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