using ChainOfResponsibilityPattern.Model;

namespace ChainOfResponsibilityPattern.Handler
{
    public abstract class Approver
    {
        protected Approver Supervisor;

        public Approver(Approver supervisor)
        {
            Supervisor = supervisor;
        }

        public void SetSupervisor(Approver approver)
        {
            Supervisor = approver;
        }

        public abstract void ProcessRequest(PurchaseOrder purchaseOrder);
    }
}