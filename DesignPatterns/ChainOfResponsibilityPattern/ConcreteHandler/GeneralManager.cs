using System;
using ChainOfResponsibilityPattern.Handler;
using ChainOfResponsibilityPattern.Model;

namespace ChainOfResponsibilityPattern.ConcreteHandler
{
    public class GeneralManager : Approver
    {
        private static readonly decimal MaxTotal = 10000;

        public GeneralManager(Approver approver) : base(approver) { }

        public override void ProcessRequest(PurchaseOrder purchaseOrder)
        {
            if (purchaseOrder.Total < MaxTotal)
                purchaseOrder.Approver = this;
            else
            {
                throw new Exception($"Purchase request {purchaseOrder.Id} for {purchaseOrder.Name} requires an excutive meeting!");
            }
        }
    }
}