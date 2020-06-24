using System;
using ChainOfResponsibilityPattern.Handler;
using ChainOfResponsibilityPattern.Model;

namespace ChainOfResponsibilityPattern.ConcreteHandler
{
    public class GeneralManager : Approver
    {
        private static readonly decimal MaxPrice = 10000;

        public GeneralManager(Approver approver) : base(approver) {}
        
        public override void ProcessRequest(PurchaseOrder purchaseOrder)
        {
            if(purchaseOrder.Price < MaxPrice)
                purchaseOrder.Approver = this;

            throw new Exception($"Purchase request {purchaseOrder.Id} requires an excutive meeting!");
        }
    }
}