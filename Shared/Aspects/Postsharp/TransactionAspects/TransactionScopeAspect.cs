using System;
using System.Transactions;
using PostSharp.Aspects;

namespace Shared.Aspects.Postsharp.TransactionAspects
{

    [Serializable]
    public class TransactionScopeAspect : OnMethodBoundaryAspect
    {
        private TransactionScopeOption _transactionScopeOption;
        public TransactionScopeAspect(TransactionScopeOption transactionScopeOption)
        {
            _transactionScopeOption = transactionScopeOption;
        }

        public TransactionScopeAspect()
        {
            
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            args.MethodExecutionTag = new TransactionScope(_transactionScopeOption);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Complete();
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Dispose();
        }
    }
}
